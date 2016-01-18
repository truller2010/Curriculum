using AutoMapper;
using Curriculum.Backend.Models.SkillsSoftware;
using Curriculum.Core.Pager;
using Curriculum.Models.SkillsSoftware;

namespace Curriculum.Backend.Mapping.SkillsSoftware {
    
    public partial class SkillsSoftwareProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<SkillsSoftwareModel, SkillsSoftwareResponse>();
            Mapper.CreateMap<Page<SkillsSoftwareModel>, Page<SkillsSoftwareResponse>>();
            Mapper.CreateMap<SkillsSoftwareResponse, SkillsSoftwareModel>();
        }
    }
}
