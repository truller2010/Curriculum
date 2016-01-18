using System.Collections.Generic;
using Curriculum.Models.ProfilesSkillsCode;
using Curriculum.Models.ProfilesSkillsProfessionals;
using Curriculum.Models.ProfilesSkillsSoftware;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.SkillsPercentages {
    
    public partial class SkillsPercentagesModel
    {
        public SkillsPercentagesModel() {
			ProfilesSkillsCode = new List<ProfilesSkillsCodeModel>();
			ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsModel>();
			ProfilesSkillsSoftware = new List<ProfilesSkillsSoftwareModel>();
        }
        public virtual int ID { get; set; }
        public virtual string Percentage { get; set; }
        public virtual IList<ProfilesSkillsCodeModel> ProfilesSkillsCode { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsModel> ProfilesSkillsProfessionals { get; set; }
        public virtual IList<ProfilesSkillsSoftwareModel> ProfilesSkillsSoftware { get; set; }
    }

    public partial class SkillsPercentagesModelMap : ClassMap<SkillsPercentagesModel>
    {

        public SkillsPercentagesModelMap()
        {
            Table("SkillsPercentages");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            Map(x => x.Percentage).Column("Percentage").Not.Nullable();
            HasMany(x => x.ProfilesSkillsCode).KeyColumn("idSkillsPercentage");
            HasMany(x => x.ProfilesSkillsProfessionals).KeyColumn("idSkillsPercentage");
            HasMany(x => x.ProfilesSkillsSoftware).KeyColumn("idSkillsPercentage");
        }
    }
}
