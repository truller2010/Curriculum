using System;
using Curriculum.Models.Profiles;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.Education
{
    
    public partial class EducationsModel
    {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual string Titulation { get; set; }
        public virtual string Centre { get; set; }
        public virtual string DurationYears { get; set; }
        public virtual string GraduationDate { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
    }

    public partial class EducationsModelMap : ClassMap<EducationsModel>
    {

        public EducationsModelMap()
        {
            Table("Educations");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            Map(x => x.Titulation).Column("Titulation").Not.Nullable();
            Map(x => x.Centre).Column("Centre").Not.Nullable();
            Map(x => x.DurationYears).Column("DurationYears").Not.Nullable();
            Map(x => x.GraduationDate).Column("GraduationDate").Not.Nullable();
            Map(x => x.Description).Column("Description").Not.Nullable();
            Map(x => x.Created).Column("Created");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.Modified).Column("Modified");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.Deleted).Column("Deleted");
            Map(x => x.DeletedBy).Column("DeletedBy");
        }
    }
}
