using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Models;

namespace EY.BankApp.Web.Mapping
{
    public class ApplicationUserMapper:IApplicatonUserMapper
    {public List<UserListModel> MapToListOfUserList(List<ApplicationUser>users)
        {
            return users.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).ToList();
        }

        public UserListModel MapToUserList(ApplicationUser user)
        {
            return new UserListModel { Id = user.Id, Name = user.Name, Surname = user.Surname };
        }
    }
}
