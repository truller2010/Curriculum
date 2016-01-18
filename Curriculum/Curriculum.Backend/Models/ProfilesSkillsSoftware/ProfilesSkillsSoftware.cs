using Curriculum.Backend.Models.Profiles;
using Curriculum.Backend.Models.SkillsPercentages;
using Curriculum.Backend.Models.SkillsSoftware;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.ProfilesSkillsSoftware {
    
    public partial class ProfilesSkillsSoftwareResponse
    {
        public virtual int ID { get; set; }
        public virtual ProfilesResponse Profiles { get; set; }
        public virtual SkillsSoftwareResponse SkillsSoftware { get; set; }
        public virtual SkillsPercentagesResponse SkillsPercentages { get; set; }
    }

}
