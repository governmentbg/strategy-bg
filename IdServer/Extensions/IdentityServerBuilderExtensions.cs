
using IdServer.Models.Contracts;
using IdServer.Models.Repositories;
using IdServer.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace IdServer.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.AddProfileService<UserProfileRepository>();
            

            return builder;
        }

        public static IIdentityServerBuilder AddSigningCredential(this IIdentityServerBuilder builder)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string certificateFileName = Path.Combine(currentDir, "Certificate\\IOIdpSigningCertificate.pfx");
            X509Certificate2 cert = new X509Certificate2(certificateFileName);

            builder.AddSigningCredential(cert);

            return builder;
        }

        public static IIdentityServerBuilder AddConfigurationStore(this IIdentityServerBuilder builder, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            builder.AddConfigurationStore(options =>
                    options.ConfigureDbContext = context =>
                        context.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly)));

            return builder;
        }

        public static IIdentityServerBuilder AddOperationalStore(this IIdentityServerBuilder builder, string connectionString)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            builder.AddOperationalStore(options =>
                    options.ConfigureDbContext = context =>
                        context.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly)));

            return builder;
        }
    }
}
