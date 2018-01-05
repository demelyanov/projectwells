using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.Models
{
    public class WellModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<StageModel> Stages { get; set; }
    }
}
