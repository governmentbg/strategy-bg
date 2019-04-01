using Models.ViewModels;
using System.Linq;

namespace Models.Contracts
{
  public interface IUsersInfoService
  {
    UsersInfoVM UsersInfo_Select(int? userId, string userName, int? userType);

    UsersInfoVM GetUserInCategories(UsersInfoVM model);

    IQueryable<UsersInfoConsultationsVM> GetConsultations(int userId);

    IQueryable<UsersInfoChangeProposalsVM> GetChangeProposals(int userId);
  }
}
