using Curriculum.Models.Profiles;
using Curriculum.Models.SkillsPercentages;
using Curriculum.Models.SkillsSoftware;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.ProfilesSkillsSoftware {
    
    public partial class ProfilesSkillsSoftwareModel
    {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual SkillsSoftwareModel SkillsSoftware { get; set; }
        public virtual SkillsPercentagesModel SkillsPercentages { get; set; }
    }

    public partial class ProfilesSkillsSoftwareModelMap : ClassMap<ProfilesSkillsSoftwareModel>
    {

        public ProfilesSkillsSoftwareModelMap()
        {
            Table("ProfilesSkillsSoftware");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            References(x => x.SkillsSoftware).Column("idSkillsSoftware");
            References(x => x.SkillsPercentages).Column("idSkillsPercentage");
        }
    }
}
