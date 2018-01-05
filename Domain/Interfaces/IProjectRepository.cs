using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace status.domain.Interfaces
{
    public interface IProjectRepository
    {
        Project GetByUserId(int userId);
    }
}
