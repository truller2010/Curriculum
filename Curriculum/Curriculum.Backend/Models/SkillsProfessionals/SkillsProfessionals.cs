using System.Collections.Generic;
using Curriculum.Backend.Models.ProfilesSkillsProfessionals;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.SkillsProfessionals {
    
    public partial class SkillsProfessionalsResponse {
        public SkillsProfessionalsResponse() {
			ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsResponse>();
        }
        public virtual int ID { get; set; }
        public virtual string ProfessionalSkill { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsResponse> ProfilesSkillsProfessionals { get; set; }
    }

}
