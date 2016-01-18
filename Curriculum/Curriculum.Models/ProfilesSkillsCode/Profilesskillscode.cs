using Curriculum.Models.Profiles;
using Curriculum.Models.SkillsCode;
using Curriculum.Models.SkillsPercentages;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.ProfilesSkillsCode {
    
    public partial class ProfilesSkillsCodeModel {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual SkillsCodeModel SkillsCode { get; set; }
        public virtual SkillsPercentagesModel SkillsPercentages { get; set; }
    }

    public partial class ProfilesSkillsCodeModelMap : ClassMap<ProfilesSkillsCodeModel>
    {

        public ProfilesSkillsCodeModelMap()
        {
            Table("ProfilesSkillsCode");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            References(x => x.SkillsCode).Column("idSkillsCode");
            References(x => x.SkillsPercentages).Column("idSkillsPercentage");
        }
    }
}
