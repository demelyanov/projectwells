using System;
using System.Collections.Generic;
using System.Text;

namespace status.domain.Model
{
    public class Project
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

        public IList<Well> Wells { get; set; }
    }
}
