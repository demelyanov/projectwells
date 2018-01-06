using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.Models
{
    public class PickingPersonItemModel
    {
        public int Id { get; set; }
        public string CutEvent { get; set; }
        public string PickedEvent { get; set; }
        public string DeletedEvent { get; set; }
        public DateTime EventDate { get; set; }
        public string Folder { get; set; }
        public string Picker { get; set; }

    }
}
