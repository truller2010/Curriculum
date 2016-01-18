using Curriculum.Backend.Models.Profiles;
using Curriculum.Backend.Models.SkillsPercentages;
using Curriculum.Backend.Models.SkillsProfessionals;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.ProfilesSkillsProfessionals {
    
    public partial class ProfilesSkillsProfessionalsResponse
    {
        public virtual int ID { get; set; }
        public virtual ProfilesResponse Profiles { get; set; }
        public virtual SkillsProfessionalsResponse SkillsProfessionals { get; set; }
        public virtual SkillsPercentagesResponse SkillsPercentages { get; set; }
    }

}
