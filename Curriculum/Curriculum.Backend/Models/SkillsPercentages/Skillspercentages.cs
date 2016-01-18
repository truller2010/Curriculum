using System.Collections.Generic;
using Curriculum.Backend.Models.ProfilesSkillsCode;
using Curriculum.Backend.Models.ProfilesSkillsProfessionals;
using Curriculum.Backend.Models.ProfilesSkillsSoftware;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.SkillsPercentages {
    
    public partial class SkillsPercentagesResponse
    {
        public SkillsPercentagesResponse() {
			ProfilesSkillsCode = new List<ProfilesSkillsCodeResponse>();
			ProfilesSkillsProfessionals = new List<ProfilesSkillsProfessionalsResponse>();
			ProfilesSkillsSoftware = new List<ProfilesSkillsSoftwareResponse>();
        }
        public virtual int ID { get; set; }
        public virtual string Percentage { get; set; }
        public virtual IList<ProfilesSkillsCodeResponse> ProfilesSkillsCode { get; set; }
        public virtual IList<ProfilesSkillsProfessionalsResponse> ProfilesSkillsProfessionals { get; set; }
        public virtual IList<ProfilesSkillsSoftwareResponse> ProfilesSkillsSoftware { get; set; }
    }

}
