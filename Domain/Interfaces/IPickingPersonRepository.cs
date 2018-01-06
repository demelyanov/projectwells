using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace status.domain.Interfaces
{
    public interface IPickingPersonRepository
    {
        IList<PickingPerson> ListByStage(int stageId);
        IList<PickingPerson> ListByPicker(string picker, int projectId);
        IList<PickingPerson> ListByWells(IList<int> ids);
    }
}
