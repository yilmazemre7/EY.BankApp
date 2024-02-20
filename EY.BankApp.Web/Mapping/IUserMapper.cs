using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Models;

namespace EY.BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
        public UserListModel MapToUserList(ApplicationUser user);

    }
}
