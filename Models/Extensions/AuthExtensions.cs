using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Models.Extensions
{
    public static class AuthExtensions
    {
        public static string GetValue(this IEnumerable<Claim> claims,string type)
        {
            return claims.Where(c => c.Type == type).Select(c => c.Value).FirstOrDefault();
        }
    }
}
