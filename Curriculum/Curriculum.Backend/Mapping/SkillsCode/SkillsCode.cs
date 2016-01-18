using AutoMapper;
using Curriculum.Backend.Models.SkillsCode;
using Curriculum.Core.Pager;
using Curriculum.Models.SkillsCode;

namespace Curriculum.Backend.Mapping.SkillsCode {
    
    public partial class SkillsCodeProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<SkillsCodeModel, SkillsCodeResponse>();
            Mapper.CreateMap<Page<SkillsCodeModel>, Page<SkillsCodeResponse>>();
            Mapper.CreateMap<SkillsCodeResponse, SkillsCodeModel>();
        }
    }
}
