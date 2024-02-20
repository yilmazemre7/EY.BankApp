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
        private readonly BankContext _bankContext;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public AccountController(BankContext context, IApplicationUserRepository userRepository, IUserMapper userMapper)
        {
            _bankContext = context;
            _applicationUserRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetById(id));
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _bankContext.Add(new Account { AccountNumber = model.AccountNumber, Balance = model.Balance, ApplicationUserId = model.ApplicationUserId });
            _bankContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
