﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<WellModel> Wells { get; set; }
    }
}
