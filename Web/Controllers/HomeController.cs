using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using B2CAssist.Models;
using UseCases;
using Web.Models;
using System.Collections.Generic;
using Models;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace B2CAssist.Controllers
{
    public class HomeController : Controller
    {
        protected IPolicyKeysCase _case;

        public HomeController(IPolicyKeysCase _case)
        {
            this._case = _case;
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            List<PolicyKey> keys = _case.GetPolicyKeys();
            IndexViewModel model = new IndexViewModel(keys);
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }
    }
}
