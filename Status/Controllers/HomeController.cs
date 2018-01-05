using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using status.domain.Interfaces;
using status.web.Models;
using status.web.ViewModels;

namespace status.web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public HomeController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int? id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (null == userId)
                return RedirectToAction("logoff", "account");

            var projectDb = _projectRepository.GetByUserId(Convert.ToInt32(userId.Value));

            if (null == projectDb)
                return RedirectToAction("logoff", "account");

            var model = new DashboardViewModel
            {
                Project = _mapper.Map<ProjectModel>(projectDb)
            };

            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
