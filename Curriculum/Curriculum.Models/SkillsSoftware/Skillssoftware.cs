using System.Collections.Generic;
using Curriculum.Models.ProfilesSkillsSoftware;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.SkillsSoftware {
    
    public partial class SkillsSoftwareModel {
        public SkillsSoftwareModel() {
			ProfilesSkillsSoftware = new List<ProfilesSkillsSoftwareModel>();
        }
        public virtual int ID { get; set; }
        public virtual string SoftwareSkills { get; set; }
        public virtual IList<ProfilesSkillsSoftwareModel> ProfilesSkillsSoftware { get; set; }
    }

    public partial class SkillsSoftwareModelModelMap : ClassMap<SkillsSoftwareModel>
    {

        public SkillsSoftwareModelModelMap()
        {
            Table("SkillsSoftware");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.SoftwareSkills).Column("SoftwareSkills").Not.Nullable();
            HasMany(x => x.ProfilesSkillsSoftware).KeyColumn("idSkillsSoftware");
        }
    }
}
