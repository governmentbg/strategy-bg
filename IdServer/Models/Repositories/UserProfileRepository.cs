using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdServer.Models.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdServer.Models.Repositories
{
    public class UserProfileRepository : IProfileService
    {
        private readonly IUserService userRepo;

        public UserProfileRepository(IUserService userRepo)
        {
            this.userRepo = userRepo;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var clientId = context.Client.ClientId;
            var claimsForUser = userRepo.GetClaimsByUserId(userId, clientId);

            context.IssuedClaims = claimsForUser
                .Select(c => new Claim(c.ClaimType, c.ClaimValue))
                .ToList();

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            context.IsActive = userRepo.IsUserActive(subjectId);

            return Task.FromResult(0);
        }
    }
}
