using Microsoft.EntityFrameworkCore;
using status.domain.Interfaces;
using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace status.dataaccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly StatusDbContext _context;

        public ProjectRepository(StatusDbContext context)
        {
            _context = context;
        }

        public Project GetByUserId(int userId)
        {
            return  _context.Projects.Include(p => p.Wells).ThenInclude(x => x.Stages).ThenInclude(x=>x.PickingPersons).Where(p => p.UserId == userId).SingleOrDefault();
        }

        public IList<Project> ListAll()
        {
            return _context.Projects.OrderBy(p => p.Name).ToList();
        }
    }
}
