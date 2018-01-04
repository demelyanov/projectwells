using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using status.domain.Interfaces;
using status.web.Models;

namespace status.web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public HomeController(IProjectRepository projectRepository) {
            _projectRepository = projectRepositoryж
        }

        public IActionResult Index(int? id)
        {

            return View();
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
