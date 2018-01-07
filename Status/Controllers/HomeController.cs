using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
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
        private readonly IPickingPersonRepository _pickingPersonRepository;
        private readonly IWellRepository _wellRepository;
        private readonly IMapper _mapper;
        public HomeController(IProjectRepository projectRepository, IPickingPersonRepository pickingPersonRepository,
                                IWellRepository wellRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _pickingPersonRepository = pickingPersonRepository;
            _wellRepository = wellRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int? projects)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (null == userId)
                return RedirectToAction("logoff", "account");

            int projectId = 0;


            IList<ProjectModel> projectsList = null;
            if (User.IsInRole("Administrator"))
            {
                projectsList = _mapper.Map<IList<ProjectModel>>(_projectRepository.ListAll());
                if (projects.HasValue)
                {
                    projectId = projects.Value;
                }
                else
                    projectId = projectsList.FirstOrDefault().Id;
            }
            else
                projectId = Convert.ToInt32(userId.Value);

            var projectDb = _projectRepository.GetByUserId(projectId);

            if (null == projectDb)
                return RedirectToAction("logoff", "account");

            var model = new DashboardViewModel
            {
                Project = _mapper.Map<ProjectModel>(projectDb),
                ProjectsList = projectsList,
                StartDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
            };

            model.WellPies = generatePieData(model.Project.Wells);

            return View(model);
        }

        private IList<WellPieModel> generatePieData(IList<WellModel> wells)
        {
            var list = new List<WellPieModel>();

            foreach (var item in wells.OrderBy(w => w.Name))
            {
                if (0 != item.Stages.Sum(s => s.PickingPersons.Count))
                {
                    var model = new WellPieModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    };

                    var data = new StringBuilder();
                    data.Append("[");
                    if (0 != item.Stages.Sum(s => s.PickingPersons.Where(p => p.CutEvent != null).Count()))
                        data.AppendFormat("{{ label: 'Cut Event', data: {0} }},", item.Stages.Sum(s => s.PickingPersons.Where(p => p.CutEvent != null).Count()).ToString());
                    if (0 != item.Stages.Sum(s => s.PickingPersons.Where(p => p.PickedEvent != null).Count()))
                        data.AppendFormat("{{ label: 'Picked Event', data: {0} }},", item.Stages.Sum(s => s.PickingPersons.Where(p => p.PickedEvent != null).Count()).ToString());
                    if (0 != item.Stages.Sum(s => s.PickingPersons.Where(p => p.DeletedEvent != null).Count()))
                        data.AppendFormat("{{ label: 'Deleted Event', data: {0} }}", item.Stages.Sum(s => s.PickingPersons.Where(p => p.DeletedEvent != null).Count()).ToString());
                    data.Append("]");
                    model.Data = data.ToString();
                    list.Add(model);
                }
            }

            return list;
        }

        public IActionResult _loadPickerData(string picker, int project)
        {
            var pickerActivitiesDb = _pickingPersonRepository.ListByPicker(picker, project);

            var grouped = pickerActivitiesDb.GroupBy(p => p.EventDate.Date).Select(r => new
            {
                Date = r.Key,
                Count = r.Count()
            }).OrderBy(r => r.Date).ToList();

            return Json(grouped);
        }

        public IActionResult _loadWellData(IList<int> ids)
        {

            var itemsDb = _pickingPersonRepository.ListByWells(ids);

            var items = _mapper.Map<IList<PickingPersonItemModel>>(itemsDb);
            if (!User.IsInRole("Administrator"))
            {
                items.ToList().ForEach(p => p.Picker = null);
            }

            return Json(items);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
