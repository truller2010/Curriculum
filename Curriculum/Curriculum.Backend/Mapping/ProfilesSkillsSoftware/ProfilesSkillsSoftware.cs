using AutoMapper;
using Curriculum.Backend.Models.Courses;
using Curriculum.Backend.Models.Profiles;
using Curriculum.Backend.Models.ProfilesSkillsSoftware;
using Curriculum.Backend.Models.SkillsPercentages;
using Curriculum.Backend.Models.SkillsSoftware;
using Curriculum.Core.Pager;
using Curriculum.Models.Courses;
using Curriculum.Models.ProfilesSkillsSoftware;

namespace Curriculum.Backend.Mapping.ProfilesSkillsSoftware {
    
    public partial class ProfilesSkillsSoftwareProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<ProfilesSkillsSoftwareModel, ProfilesSkillsSoftwareResponse>();
            Mapper.CreateMap<Page<ProfilesSkillsSoftwareModel>, Page<ProfilesSkillsSoftwareResponse>>();
            Mapper.CreateMap<ProfilesSkillsSoftwareResponse, ProfilesSkillsSoftwareModel>();
        }
    }
}