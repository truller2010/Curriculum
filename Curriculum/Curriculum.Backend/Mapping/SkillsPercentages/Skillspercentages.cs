using AutoMapper;
using Curriculum.Backend.Models.SkillsPercentages;
using Curriculum.Core.Pager;
using Curriculum.Models.SkillsPercentages;

namespace Curriculum.Backend.Mapping.SkillsPercentages {
    
    public partial class SkillsPercentagesProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<SkillsPercentagesModel, SkillsPercentagesResponse>();
            Mapper.CreateMap<Page<SkillsPercentagesModel>, Page<SkillsPercentagesResponse>>();
            Mapper.CreateMap<SkillsPercentagesResponse, SkillsPercentagesModel>();
        }
    }
}
