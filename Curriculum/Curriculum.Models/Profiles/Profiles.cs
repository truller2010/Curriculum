using System;
using System.Collections.Generic;
using Curriculum.Models.Courses;
using Curriculum.Models.Education;
using Curriculum.Models.ProfilesSkillsCode;
using Curriculum.Models.ProfilesSkillsProfessionals;
using Curriculum.Models.ProfilesSkillsSoftware;
using Curriculum.Models.WorkExperiences;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.Profiles {
    
    public partial class ProfilesModel
    {
        public ProfilesModel()
        {
			Courses = new List<CoursesModel>();
			Educations = new List<EducationsModel>();
			ProfilesSkillsCode = new List<ProfilesSkillsCodeModel>();
			ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsModel>();
			ProfilesSkillsSoftware = new List<ProfilesSkillsSoftwareModel>();
			WorkExperiences = new List<WorkExperiencesModel>();
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
        public virtual IList<ProfilesSkillsCode.ProfilesSkillsCodeModel> ProfilesSkillsCode { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsModel> ProfilesSkillsProfessionals { get; set; }
        public virtual IList<ProfilesSkillsSoftwareModel> ProfilesSkillsSoftware { get; set; }
        public virtual IList<WorkExperiencesModel> WorkExperiences { get; set; }
    }

    public partial class ProfilesModelMap : ClassMap<ProfilesModel>
    {

        public ProfilesModelMap()
        {
            Table("Profiles");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.FirstSurname).Column("FirstSurname").Not.Nullable();
            Map(x => x.SecondSurname).Column("SecondSurname").Not.Nullable();
            Map(x => x.Street).Column("Street").Not.Nullable();
            Map(x => x.StreetNumber).Column("StreetNumber").Not.Nullable();
            Map(x => x.Floor).Column("Floor").Not.Nullable();
            Map(x => x.Letter).Column("Letter").Not.Nullable();
            Map(x => x.PostalCode).Column("PostalCode").Not.Nullable();
            Map(x => x.City).Column("City").Not.Nullable();
            Map(x => x.Country).Column("Country").Not.Nullable();
            Map(x => x.Born).Column("Born").Not.Nullable();
            Map(x => x.Email).Column("Email").Not.Nullable();
            Map(x => x.Created).Column("Created");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.Modified).Column("Modified");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.Deleted).Column("Deleted");
            Map(x => x.DeletedBy).Column("DeletedBy");
            HasMany(x => x.Courses).KeyColumn("idProfile");
            HasMany(x => x.Educations).KeyColumn("idProfile");
            HasMany(x => x.ProfilesSkillsCode).KeyColumn("idProfile");
            HasMany(x => x.ProfilesSkillsProfessionals).KeyColumn("idProfile");
            HasMany(x => x.ProfilesSkillsSoftware).KeyColumn("idProfile");
            HasMany(x => x.WorkExperiences).KeyColumn("idProfile");
        }
    }
}
