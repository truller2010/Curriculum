using System.Collections.Generic;
using Curriculum.Models.ProfilesSkillsCode;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.SkillsCode {
    
    public partial class SkillsCodeModel {
        public SkillsCodeModel() {
			ProfilesSkillsCode = new List<ProfilesSkillsCodeModel>();
        }
        public virtual int ID { get; set; }
        public virtual string CodeSkills { get; set; }
        public virtual IList<ProfilesSkillsCodeModel> ProfilesSkillsCode { get; set; }
    }

    public partial class SkillsCodeModelMap : ClassMap<SkillsCodeModel>
    {

        public SkillsCodeModelMap()
        {
            Table("SkillsCode");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.CodeSkills).Column("CodeSkills").Not.Nullable();
            HasMany(x => x.ProfilesSkillsCode).KeyColumn("idSkillsCode");
        }
    }
}
