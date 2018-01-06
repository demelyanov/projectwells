using Microsoft.EntityFrameworkCore;
using status.domain.Interfaces;
using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace status.dataaccess.Repositories
{
    public class WellRepository : IWellRepository
    {
        private readonly StatusDbContext _context;

        public WellRepository(StatusDbContext context)
        {
            _context = context;
        }

        public IList<Well> ListByIds(IList<int> ids)
        {
            return _context.Wells.Include(w => w.Stages).ThenInclude(s => s.PickingPersons).Where(w => ids.Contains(w.Id)).OrderBy(w => w.Name).ToList();
        }
    }
}
