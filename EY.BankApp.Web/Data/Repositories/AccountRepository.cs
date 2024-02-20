using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Data.Interfaces;

namespace EY.BankApp.Web.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public BankContext _context{ get; set; }

        public AccountRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChangesAsync();
        }
    }
}
