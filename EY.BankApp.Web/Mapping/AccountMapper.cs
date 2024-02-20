using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Models;

namespace EY.BankApp.Web.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account MapAccountCreateModel(AccountCreateModel model)
        {
            return new Account { AccountNumber = model.AccountNumber, ApplicationUserId = model.ApplicationUserId, Balance = model.Balance };
        }

      
    }
}
