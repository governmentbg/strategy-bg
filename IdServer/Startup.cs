using System.Globalization;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdServer.Extensions;
using IdServer.Models;
using IdServer.Models.Contracts;
using IdServer.Models.InitData;
using IdServer.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataTables.AspNet.AspNetCore;
using Microsoft.Extensions.Logging;

namespace IdServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdServerContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("idsConnection")));

            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

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

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddConfigurationStore(Configuration.GetConnectionString("idsConnection"))
                    .AddOperationalStore(Configuration.GetConnectionString("idsConnection"))
                    .AddUserStore();

            services.AddAuthentication()
                    .AddFacebook("Facebook", options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                        options.AppId = "593992584303164";
                        options.AppSecret = "b1bf7646d6708f94f1085a4abe4b1463";
                    });


            ConfigureDI(services);

            services.RegisterDataTables();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IdServerContext context,
            ConfigurationDbContext configurationContext,
            ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }



            app.UseRequestLocalization();

            app.UseStaticFiles();

            //context.ForceSampleData();
            //configurationContext.ForceSampleData();

            app.UseIdentityServer();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Manage}/{action=Users}/{id?}");
            });

            logger.AddLog4Net();
        }


        private void ConfigureDI(IServiceCollection services)
        {
            //add services to DI
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
