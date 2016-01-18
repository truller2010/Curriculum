using AutoMapper;
using Curriculum.Backend.Models.WorkExperiences;
using Curriculum.Core.Pager;
using Curriculum.Models.WorkExperiences;

namespace Curriculum.Backend.Mapping.WorkExperiences {
    
    public partial class WorkExperiencesProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<WorkExperiencesModel, WorkexperiencesResponse>();
            Mapper.CreateMap<Page<WorkExperiencesModel>, Page<WorkexperiencesResponse>>();
            Mapper.CreateMap<WorkexperiencesResponse, WorkExperiencesModel>();
        }
    }
}
