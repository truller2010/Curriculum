using Curriculum.Backend.Models.Profiles;
using Curriculum.Backend.Models.SkillsCode;
using Curriculum.Backend.Models.SkillsPercentages;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.ProfilesSkillsCode {
    
    public partial class ProfilesSkillsCodeResponse {
        public virtual int ID { get; set; }
        public virtual ProfilesResponse Profiles { get; set; }
        public virtual SkillsCodeResponse SkillsCode { get; set; }
        public virtual SkillsPercentagesResponse SkillsPercentages { get; set; }
    }
}
