using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using status.domain.Interfaces;
using status.web.ViewModels;

namespace Status.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accRepository;

        public AccountController(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _accRepository.Authenticate(model.Username, model.Password);
                if (null == user)
                {
                    model.NotFound = true;
                    return View(model);
                }

                if (null == user.Project && "Administrator" != user.Role.Name)
                {
                    model.NoProject = true;
                    return View(model);
                }

                // Create the identity from the user info
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, model.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.Name));

                // Authenticate using the identity
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = false });

                return Redirect("/");

            }
            return View(model);
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");
        }
    }
}