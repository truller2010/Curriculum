using AutoMapper;
using Curriculum.Backend.Models.ProfilesSkillsProfessionals;
using Curriculum.Core.Pager;
using Curriculum.Models.ProfilesSkillsProfessionals;

namespace Curriculum.Backend.Mapping.ProfilesSkillsProfessionals {
    
    public partial class ProfilesSkillsProfessionalsProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<ProfilesSkillsProfessionalsModel, ProfilesSkillsProfessionalsResponse>();
            Mapper.CreateMap<Page<ProfilesSkillsProfessionalsModel>, Page<ProfilesSkillsProfessionalsResponse>>();
            Mapper.CreateMap<ProfilesSkillsProfessionalsResponse, ProfilesSkillsProfessionalsModel>();
        }
    }
}