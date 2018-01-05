using AutoMapper;
using status.domain.Model;
using status.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace status.web.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, ProjectModel>();
            CreateMap<Well, WellModel>();
            CreateMap<Stage, StageModel>();
        }
    }
}
