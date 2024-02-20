using EY.BankApp.Web.Data.Entities;

namespace EY.BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}
