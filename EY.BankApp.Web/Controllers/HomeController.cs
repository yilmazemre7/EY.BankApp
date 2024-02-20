using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EY.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly BankContext _context;

        public HomeController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ApplicationUsers.ToList());
        }

    }
}