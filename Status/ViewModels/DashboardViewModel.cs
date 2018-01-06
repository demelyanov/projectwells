using status.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.ViewModels
{
    public class DashboardViewModel
    {
        public ProjectModel Project { get; set; } 

        public IList<WellPieModel> WellPies { get; set; }
    }
}
