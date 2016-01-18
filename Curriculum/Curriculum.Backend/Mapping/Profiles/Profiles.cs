using AutoMapper;
using Curriculum.Backend.Models.Profiles;
using Curriculum.Core.Pager;
using Curriculum.Models.Profiles;

namespace Curriculum.Backend.Mapping.Profiles {
    
    public partial class ProfilesProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<ProfilesModel, ProfilesResponse>();
            Mapper.CreateMap<Page<ProfilesModel>, Page<ProfilesResponse>>();
            Mapper.CreateMap<ProfilesResponse, ProfilesModel>();
        }
    }
}