using System;
using System.Collections.Generic;
using System.Text;

namespace status.domain.Model
{
    public class Stage
    {
        public int Id { get; set; }
        public int WellId { get; set; }
        public string Name { get; set; }
        public int FilesCount { get; set; }

        public IList<PickingPerson> PickingPersons { get; set; }
    }
}
