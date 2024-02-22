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

        ////private readonly IAccountRepository _accountRepository;
        ////private readonly IApplicationUserRepository _applicationUserRepository;
        ////private readonly IApplicatonUserMapper _applicatonUserMapper;
        ////private readonly IAccountMapper _accountMapper;

        //private readonly IRepository<Account> _accountRepository;
        //private readonly IRepository<ApplicationUser> _applicatonUserRepository;

        //public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> applicatonUserRepository)
        //{
        //    _accountRepository = accountRepository;
        //    _applicatonUserRepository = applicatonUserRepository;

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;

        public AccountController(IRepository<ApplicationUser> applicationUserRepository, IRepository<Account> accountRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _accountRepository = accountRepository;
        }


        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.GetById(id);
            return View(new UserListModel { Id=userInfo.Id,Name=userInfo.Name,Surname=userInfo.Surname});
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(new Account { AccountNumber = model.AccountNumber, Balance = model.Balance, ApplicationUserId = model.ApplicationUserId });
            return RedirectToAction("Index", "Home");
        }

         [HttpGet]
         public IActionResult GetByUserId(int userId)
        {
            var query = _accountRepository.GetQueryable();
            var accounts=query.Where(x => x.Id == userId).ToList();
            var user=_applicationUserRepository.GetById(userId);
            ViewBag.FullName = user.Name + " " + user.Surname;
            var list=new List<AccountListModel>();

            foreach (var item in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId,
                    Balance = item.Balance,
                    
                    Id = item.Id
                });

               

            }
            return View(list);

        }

          
    }
}
