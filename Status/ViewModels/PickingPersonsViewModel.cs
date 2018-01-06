using status.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.ViewModels
{
    public class PickingPersonsViewModel
    {
        public IList<PickingPersonItemModel> Cut { get; set; }
        public IList<PickingPersonItemModel> Picked { get; set; }
        public IList<PickingPersonItemModel> Deleted { get; set; }
    }
}
