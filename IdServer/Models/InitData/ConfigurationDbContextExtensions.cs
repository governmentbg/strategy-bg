using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

namespace IdServer.Models.InitData
{
    public static class ConfigurationDbContextExtensions
    {
        public static void ForceSampleData(this ConfigurationDbContext context)
        {
            //if (!context.Clients.Any())
            //{
            //    foreach (var client in Config.GetClients())
            //    {
            //        context.Clients.Add(client.ToEntity());
            //    }

            //    context.SaveChanges();
            //}

            //if (!context.IdentityResources.Any())
            //{
            //    foreach (var resourse in Config.GetIdentityResources())
            //    {
            //        context.IdentityResources.Add(resourse.ToEntity());
            //    }

            //    context.SaveChanges();
            //}            
        }
    }
}
