using System;
using System.Collections.Generic;
using System.Text;

namespace status.domain.Model
{
    public class Well
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }

        public IList<Stage> Stages { get; set; }
    }
}
