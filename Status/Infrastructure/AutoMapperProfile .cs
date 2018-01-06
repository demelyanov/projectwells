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
            CreateMap<PickingPerson, PickingPersonItemModel>()
                .ForMember(dest=>dest.WellName, opt=>opt.MapFrom(src=>src.Well.Name))
                .ForMember(dest => dest.StageName, opt => opt.MapFrom(src => src.Stage.Name));

                /*.ForMember(dest=>dest.Event, opt=>opt.ResolveUsing((src, dest, destMember, resContext)  => 
                    dest.Event = (EventType)resContext.Items["EventType"] == EventType.Cut ? src.CutEvent :
                        (EventType)resContext.Items["EventType"] == EventType.Picked ? src.PickedEvent : src.DeletedEvent));*/
        }
    }
}
