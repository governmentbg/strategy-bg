using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebCommon.Services
{
    public class UserContext : IUserContext
    {
        IHttpContextAccessor httpContextAccessor;
        ClaimsPrincipal _user;
        ClaimsPrincipal user
        {
            get
            {
                if (_user == null)
                {
                    _user = httpContextAccessor.HttpContext.User;
                }
                return _user;
            }
        }
        public UserContext(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public int UserId
        {
            get
            {
                int result = 0;
                if (this.user != null)
                {
                    var val = this.user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
                    if (!string.IsNullOrEmpty(val))
                    {
                        result = int.Parse(val);
                    }
                }
                return result;
            }
        }
        public string Email
        {
            get
            {
                string result = string.Empty;
                if (this.user != null)
                {
                    result = this.user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                }
                return result;
            }
        }
        public string FullName
        {
            get
            {
                string result = string.Empty;
                if (this.user != null)
                {
                    result = this.user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                }
                return result;
            }
        }

        public bool IsInRole(string role)
        {
            try
            {
                return this.user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == role);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
