using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Data.Interfaces;
using EY.BankApp.Web.Data.Repositories;
using EY.BankApp.Web.Mapping;
using EY.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EY.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        
        //private readonly IAccountRepository _accountRepository;
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IApplicatonUserMapper _applicatonUserMapper;
        //private readonly IAccountMapper _accountMapper;

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _applicatonUserRepository;

        public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> applicatonUserRepository)
        {
            _accountRepository = accountRepository;
            _applicatonUserRepository = applicatonUserRepository;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _applicatonUserRepository.GetById(id);
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(new Account { AccountNumber = model.AccountNumber ,Balance=model.Balance,ApplicationUserId=model.ApplicationUserId});
            return RedirectToAction("Index", "Home");
        }
    }
}
