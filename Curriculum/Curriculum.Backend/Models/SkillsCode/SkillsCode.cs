using System.Collections.Generic;
using Curriculum.Backend.Models.ProfilesSkillsCode;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.SkillsCode {
    
    public partial class SkillsCodeResponse {
        public SkillsCodeResponse() {
			ProfilesSkillsCode = new List<ProfilesSkillsCodeResponse>();
        }
        public virtual int ID { get; set; }
        public virtual string CodeSkills { get; set; }
        public virtual IList<ProfilesSkillsCodeResponse> ProfilesSkillsCode { get; set; }
    }

}
