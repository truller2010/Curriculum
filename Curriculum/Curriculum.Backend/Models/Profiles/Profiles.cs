using System;
using System.Collections.Generic;
using Curriculum.Backend.Models.Courses;
using Curriculum.Backend.Models.Education;
using Curriculum.Models.Courses;
using Curriculum.Models.Education;
using Curriculum.Models.WorkExperiences;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.Profiles {
    
    public partial class ProfilesResponse
    {
        public ProfilesResponse()
        {
			Courses = new List<CoursesResponse>();
			Educations = new List<EducationsResponse>();
			ProfilesSkillsCode = new List<ProfilesSkillsCodeResponse>();
			ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsResponse>();
			ProfilesSkillsSoftware = new List<Curriculum.Models.ProfilesSkillsSoftwareResponse>();
			WorkExperiences = new List<WorkExperiencesResponse>();
        }
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string FirstSurname { get; set; }
        public virtual string SecondSurname { get; set; }
        public virtual string Street { get; set; }
        public virtual int StreetNumber { get; set; }
        public virtual int Floor { get; set; }
        public virtual string Letter { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual DateTime Born { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual IList<CoursesModel> Courses { get; set; }
        public virtual IList<EducationsModel> Educations { get; set; }
        public virtual IList<ProfilesSkillsCodeResponse> ProfilesSkillsCode { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsResponse> ProfilesSkillsProfessionals { get; set; }
        public virtual IList<ProfilesSkillsSoftwareResponse> ProfilesSkillsSoftware { get; set; }
        public virtual IList<WorkExperiencesModel> WorkExperiences { get; set; }
    }

}
