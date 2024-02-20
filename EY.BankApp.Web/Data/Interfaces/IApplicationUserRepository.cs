using EY.BankApp.Web.Data.Entities;

namespace EY.BankApp.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}
