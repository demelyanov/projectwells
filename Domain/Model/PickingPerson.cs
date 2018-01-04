using System;
using System.Collections.Generic;
using System.Text;

namespace status.domain.Model
{
    public class PickingPerson
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int WellId { get; set; }
        public int StageId { get; set; }
        public string Picker { get; set; }
        public string Folder { get; set; }
        public string CutEvent { get; set; }
        public string PickedEvent { get; set; }
        public string DeletedEvent { get; set; }
        public DateTime EventDate { get; set; }
    }
}
