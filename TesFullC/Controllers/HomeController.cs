using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TesFullC.Contexts;
using TesFullC.Models;

namespace TesFullC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MSSqlContext _db;

        public HomeController(ILogger<HomeController> logger, MSSqlContext context)
        {
            _logger = logger;
            _db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            var claim = User.FindFirst(ClaimTypes.Email);
            if(claim == null)
            {
                returnUrl = returnUrl ?? Url.Content("~/");
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            model.ReturnUrl = model.ReturnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        var claimList = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, model.Email)
                        };
                        var claimIdentity = new ClaimsIdentity(claimList, "CookieAuth");
                        var claimPrincipal = new ClaimsPrincipal(new[] { claimIdentity });
                        await HttpContext.SignInAsync(claimPrincipal, new AuthenticationProperties { IsPersistent = model.RememberMe});
                        return Redirect(model.ReturnUrl);
                    }
                }
                ViewData["Error"] = "Login Failed!";
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddStock()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
