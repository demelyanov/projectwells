using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using status.domain.Interfaces;

namespace Status.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accRepository;

        public AccountController(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var user = _accRepository.Authenticate("test", "test");
            return View();
        }
    }
}