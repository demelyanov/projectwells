﻿using status.domain.Interfaces;
using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace status.dataaccess.Repositories
{
    public class PickingPersonRepository : IPickingPersonRepository
    {
        private readonly StatusDbContext _context;

        public PickingPersonRepository(StatusDbContext context)
        {
            _context = context;
        }

        public IList<PickingPerson> ListByPicker(string picker, int projectId)
        {
            return _context.PickingPersons.Where(p => p.Picker.ToLower() == picker.ToLower() && p.ProjectId == projectId).ToList();
        }

        public IList<PickingPerson> ListByStage(int stageId)
        {
            return _context.PickingPersons.Where(p => p.StageId == stageId).ToList();
        }
    }
}
