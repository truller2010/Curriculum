using System.Collections.Generic;
using Curriculum.Backend.Models.ProfilesSkillsSoftware;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.SkillsSoftware {
    
    public partial class SkillsSoftwareResponse {
        public SkillsSoftwareResponse() {
			ProfilesSkillsSoftware = new List<ProfilesSkillsSoftwareResponse>();
        }
        public virtual int ID { get; set; }
        public virtual string SoftwareSkills { get; set; }
        public virtual IList<ProfilesSkillsSoftwareResponse> ProfilesSkillsSoftware { get; set; }
    }

}
