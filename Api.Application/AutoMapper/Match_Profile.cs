using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class Match_Profile : Profile
    {

        public Match_Profile()
        {
            CreateMap<MatchEntity, MatchViewModel>()
                .ForMember(x => x.Times, y => y.MapFrom(src => src.Time1.name + " x " + src.Time2.name))
                .ForMember(x => x.Result, y => y.MapFrom(src => src.Goals1 + " x " + src.Goals2));
        }
       
    }
}
