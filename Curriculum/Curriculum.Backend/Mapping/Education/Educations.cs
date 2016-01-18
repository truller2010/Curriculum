using AutoMapper;
using Curriculum.Backend.Models.Education;
using Curriculum.Core.Pager;
using Curriculum.Models.Education;

namespace Curriculum.Backend.Mapping.Education
{
    
    public partial class EducationsProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<EducationsModel, EducationsResponse>();
            Mapper.CreateMap<Page<EducationsModel>, Page<EducationsResponse>>();
            Mapper.CreateMap<EducationsResponse, EducationsModel>();
        }
    }
}