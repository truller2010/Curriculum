using AutoMapper;
using Curriculum.Backend.Models.SkillsProfessionals;
using Curriculum.Core.Pager;
using Curriculum.Models.SkillsProfessionals;

namespace Curriculum.Backend.Mapping.SkillsProfessionals {
    
    public partial class SkillsProfessionalsProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<SkillsProfessionalsModel, SkillsProfessionalsResponse>();
            Mapper.CreateMap<Page<SkillsProfessionalsModel>, Page<SkillsProfessionalsResponse>>();
            Mapper.CreateMap<SkillsProfessionalsResponse, SkillsProfessionalsModel>();
        }
    }
}
