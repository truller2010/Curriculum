using System.Collections.Generic;
using Curriculum.Models.ProfilesSkillsProfessionals;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.SkillsProfessionals {
    
    public partial class SkillsProfessionalsModel {
        public SkillsProfessionalsModel() {
			ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsModel>();
        }
        public virtual int ID { get; set; }
        public virtual string ProfessionalSkill { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsModel> ProfilesSkillsProfessionals { get; set; }
    }

    public partial class SkillsProfessionalsModelMap : ClassMap<SkillsProfessionalsModel>
    {

        public SkillsProfessionalsModelMap()
        {
            Table("SkillsProfessionals");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.ProfessionalSkill).Column("ProfessionalSkill").Not.Nullable();
            HasMany(x => x.ProfilesSkillsProfessionals).KeyColumn("idSkillsProfessionals");
        }
    }
}
