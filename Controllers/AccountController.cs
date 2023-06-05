using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_21.Controllers
{
    public class AccountController : Controller
    {
        private readonly PhoneBookContext _context;

        public AccountController(PhoneBookContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }

            return RedirectToAction("Index", "PhoneBook");
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "PhoneBook");
        }
    }
}
