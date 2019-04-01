using IdServer.Models;
using System.Linq;

namespace IdServer.Models.InitData
{
    public static class IdServerContextExtension
    {
        public static void ForceSampleData(this IdServerContext context)
        {


            //if (!context.Users.Any())
            //{
            //    // init users
            //    var users = Config.GetUsers();

            //    context.Users.AddRange(users);
            //    context.SaveChanges();
            //}


            //if (!context.Roles.Any())
            //{
            //    var roles = Config.GetRoles();

            //    context.Roles.AddRange(roles);
            //    context.SaveChanges();
            //}
        }
    }
}
