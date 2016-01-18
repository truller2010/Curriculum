using System;
using Curriculum.Models.Profiles;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.Courses {
    
    public partial class CoursesModel {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual string Course { get; set; }
        public virtual DateTime InitialDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
    }

    public partial class CoursesModelMap : ClassMap<CoursesModel>
    {

        public CoursesModelMap()
        {
            Table("Courses");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            Map(x => x.Course).Column("Course").Not.Nullable();
            Map(x => x.InitialDate).Column("InitialDate").Not.Nullable();
            Map(x => x.EndDate).Column("EndDate").Not.Nullable();
            Map(x => x.Created).Column("Created");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.Modified).Column("Modified");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.Deleted).Column("Deleted");
            Map(x => x.DeletedBy).Column("DeletedBy");
        }
    }
}
