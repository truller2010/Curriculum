using System;
using Curriculum.Models.Profiles;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.WorkExperiences {
    
    public partial class WorkExperiencesModel {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual string Enterprise { get; set; }
        public virtual string Occupation { get; set; }
        public virtual DateTime? InitialDate { get; set; }
        public virtual DateTime? FinalDate { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
    }

    public partial class WorkExperiencesModelMap : ClassMap<WorkExperiencesModel>
    {

        public WorkExperiencesModelMap()
        {
            Table("WorkExperiences");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            Map(x => x.Enterprise).Column("Enterprise");
            Map(x => x.Occupation).Column("Occupation");
            Map(x => x.InitialDate).Column("InitialDate");
            Map(x => x.FinalDate).Column("FinalDate");
            Map(x => x.Description).Column("Description");
            Map(x => x.Created).Column("Created");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.Modified).Column("Modified");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.Deleted).Column("Deleted");
            Map(x => x.DeletedBy).Column("DeletedBy");
        }
    }
}
