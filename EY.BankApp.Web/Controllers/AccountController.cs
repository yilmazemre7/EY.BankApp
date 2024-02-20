using EY.BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace EY.BankApp.Web.Views.Home
{
    public class AccountController : Controller
    {
        private readonly BankContext _context;

        public AccountController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Create(int id)
        {
            var userInfo=_context.ApplicationUsers.SingleOrDefault(x=>x.Id==id);
            return View(userInfo);
        }
    }
}
