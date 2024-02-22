using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Data.Entities;
using EY.BankApp.Web.Data.Interfaces;
using EY.BankApp.Web.Data.Repositories;
using EY.BankApp.Web.Data.UnitOfWork;
using EY.BankApp.Web.Mapping;
using EY.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace EY.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUow _uow;
        private readonly IApplicatonUserMapper _userMapper;
        public HomeController(IUow uow, IApplicatonUserMapper userMapper)
        {

            _uow = uow;
            _userMapper = userMapper;


        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
        }

    }
}