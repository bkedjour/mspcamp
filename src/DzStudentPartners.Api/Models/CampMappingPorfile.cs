using AutoMapper;
using DzStudentPartners.Domain;

namespace DzStudentPartners.Api.Models
{
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<MspCamp, CampModel>()
            .ReverseMap()
            .ForMember(c => c.Location, o => o.ResolveUsing(m => new Location
            {
                Address1 = m.LocationAddress1,
                Address2 = m.LocationAddress2,
                Wilaya = m.LocationWilaya
            }));

            CreateMap<Msp, MspModel>()
            .ReverseMap();

            CreateMap<Skill, SkillModel>()
            .ReverseMap();
        }
    }
}