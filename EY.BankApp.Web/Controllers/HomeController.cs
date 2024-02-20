using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Data.Interfaces;
using EY.BankApp.Web.Data.Repositories;
using EY.BankApp.Web.Mapping;
using EY.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace EY.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly BankContext _context;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        public HomeController(BankContext context,IApplicationUserRepository applicationUserRepository, IUserMapper userMapper)
        {
            _context = context;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;


        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_applicationUserRepository.GetAll()));
        }

    }
}