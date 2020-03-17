using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaxCollectorAdmin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult Accounts()
        {
            return View();
        }
    }
}