using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Models;

namespace EY.BankApp.Web.Mapping
{
    public interface IAccountMapper
    {
        public Account MapAccountCreateModel(AccountCreateModel model);
       
    }
}
