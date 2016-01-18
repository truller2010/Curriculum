using AutoMapper;
using Curriculum.Backend.Models.Courses;
using Curriculum.Core.Pager;
using Curriculum.Models.Courses;

namespace Curriculum.Backend.Mapping.Courses {
    
    public partial class CoursesProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<CoursesModel, CoursesResponse>();
            Mapper.CreateMap<Page<CoursesModel>, Page<CoursesResponse>>();
            Mapper.CreateMap<CoursesResponse, CoursesModel>();
        }
    }
}