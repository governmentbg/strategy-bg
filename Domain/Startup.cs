using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using DataTables.AspNet.AspNetCore;
using Microsoft.Extensions.Logging;
using Elastic.Models.Data;
using Rotativa.AspNetCore;
using reCAPTCHA.AspNetCore;

using Microsoft.AspNetCore.Authorization;
using PopForums.Configuration;
using PopForums.Extensions;
using PopForums.Mvc.Areas.Forums.Extensions;
using PopForums.Mvc.Areas.Forums.Authorization;
using Microsoft.AspNetCore.Localization;
using PopForums.Data.Sql;
using System.Globalization;
using WebCommon.ModelBinders;
using Models;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.HttpOverrides;

namespace Domain
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            // setup PopForums.json config file
            Config.SetPopForumsAppEnvironment(env.ContentRootPath);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(MainContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<MainContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MainDB"),
                                    opt =>
                                    {
                                        opt.MigrationsAssembly(migrationsAssembly);
                                    });
            });

            // Url Helper configured for injection 
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
                 {
                     options.AccessDeniedPath = "/Account/ErrorForbidden";
                     options.LoginPath = "/Account/Login";
                 })
                 .AddFacebook(options =>
                 {
                     options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                     options.AppId = Configuration.GetValue<string>("Facebook:AppId");
                     options.AppSecret = Configuration.GetValue<string>("Facebook:AppSecret");
                 }).AddTwitter(options =>
                 {
                     options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                     options.ConsumerKey = Configuration.GetValue<string>("Twitter:ConsumerKey");
                     options.ConsumerSecret = Configuration.GetValue<string>("Twitter:ConsumerSecret");
                     options.RetrieveUserDetails = true;
                 });

            // needed for social logins in POP Forums
            services.AddAuthentication(options => options.DefaultSignInScheme = PopForumsAuthorizationDefaults.AuthenticationScheme);

            services.Configure<AuthorizationOptions>(options =>
            {
                // sets claims policies for admin and moderator functions in POP Forums
                options.AddPopForumsPolicies();
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc(options =>
            {
                // identifies users on POP Forums actions
                options.Filters.Add(typeof(PopForumsUserAttribute));

                options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider(GlobalConstants.DateFormat));
                options.ModelBinderProviders.Insert(1, new DecimalModelBinderProvider());
            })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            // .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new CultureInfo[]
                {
                    new CultureInfo("bg"),
                    new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture("bg");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });



            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("MustBeAdmin", p => p.RequireAuthenticatedUser().RequireRole("admin"));
            //});


            // Add Recaptcha
            services.Configure<RecaptchaSettings>(Configuration.GetSection("RecaptchaSettings"));
            services.AddTransient<IRecaptchaService, RecaptchaService>();

            services.ConfigureDI();
            services.RegisterDataTables();


            services.Configure<elasticSettings>(Configuration.GetSection("elasticSettings"));
            services.AddSignalR();

            // sets up the dependencies for the base, SQL and web libraries in POP Forums
            services.AddPopForumsBase();
            services.AddPopForumsSql();
            // this adds dependencies from the MVC project and sets up authentication for the forum
            services.AddPopForumsMvc();

            // use Redis cache for POP Forums using AzureKit
            //services.AddPopForumsRedisCache();

            // use Azure Search for POP Forums using AzureKit
            //services.AddPopForumsAzureSearch();

            // creates an instance of the background services for POP Forums... call this last in forum setup
            services.AddPopForumsBackgroundServices();

            services.Configure<OpenDataExportSettings>(Configuration.GetSection("OpenDataExportSettings"));
            services.AddHostedService<BackgroundOpenDataExportService>();

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = true;
            });

            //   services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {

            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRequestLocalization();
            app.UseStaticFiles();

            app.UseAuthentication();

            // Records exceptions and info to the POP Forums database.
            // logger.AddPopForumsLogger(app);

            // Populate the POP Forums identity in every request.
            app.UsePopForumsAuth();

            // Wires up the SignalR hubs for real-time updates.
            app.UsePopForumsSignalR();

            app.UseMvc(routes =>
            {
                // POP Forums routes
                routes.AddPopForumsRoutes(app);

                routes.MapRoute(
                                  name: "page by id",
                                  template: "page/view/{id?}/{url?}",
                                  defaults: new { controller = "Page", action = "Preview", area = "" }
                                  );

                routes.MapRoute(
                                  name: "page by url",
                                  template: "page/{pageType}/{url}",
                                  defaults: new { controller = "Page", action = "PreviewByUrl", area = "" }
                                  );

                routes.MapRoute(
                                    name: "areaRoute",
                                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



                routes.MapRoute(
                                    name: "default",
                                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            logger.AddLog4Net();

            RotativaConfiguration.Setup(env, @"lib\rotativa");

            //// TODO: abstract this
            //var supportedCultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("bg"), new CultureInfo("de"), new CultureInfo("es"), new CultureInfo("nl"), new CultureInfo("uk"), new CultureInfo("zh-TW") };
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("bg", "bg"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("bg");
            //CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("bg");
        }
    }
}
