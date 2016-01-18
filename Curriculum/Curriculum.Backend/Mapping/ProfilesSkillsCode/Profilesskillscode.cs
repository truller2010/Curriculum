using AutoMapper;
using Curriculum.Backend.Models.ProfilesSkillsCode;
using Curriculum.Core.Pager;
using Curriculum.Models.ProfilesSkillsCode;

namespace Curriculum.Backend.Mapping.ProfilesSkillsCode {
    
    public partial class ProfilesSkillsCodeProfile: Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<ProfilesSkillsCodeModel, ProfilesSkillsCodeResponse>();
            Mapper.CreateMap<Page<ProfilesSkillsCodeModel>, Page<ProfilesSkillsCodeResponse>>();
            Mapper.CreateMap<ProfilesSkillsCodeResponse, ProfilesSkillsCodeModel>();
        }
    }
}