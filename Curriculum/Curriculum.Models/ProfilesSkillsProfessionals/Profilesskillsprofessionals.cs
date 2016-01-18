using Curriculum.Models.Profiles;
using Curriculum.Models.SkillsPercentages;
using Curriculum.Models.SkillsProfessionals;
using FluentNHibernate.Mapping;

namespace Curriculum.Models.ProfilesSkillsProfessionals {
    
    public partial class ProfilesSkillsProfessionalsModel
    {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual SkillsProfessionalsModel SkillsProfessionals { get; set; }
        public virtual SkillsPercentagesModel SkillsPercentages { get; set; }
    }

    public partial class ProfilesSkillsProfessionalsModelMap : ClassMap<ProfilesSkillsProfessionalsModel>
    {
        
        public ProfilesSkillsProfessionalsModelMap()
        {
            Table("ProfilesSkillsProfessionals");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            References(x => x.SkillsProfessionals).Column("idSkillsProfessionals");
            References(x => x.SkillsPercentages).Column("idSkillsPercentage");
        }
    }
}
