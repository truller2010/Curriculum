using System;
using Curriculum.Backend.Models.Profiles;

namespace Curriculum.Backend.Models.WorkExperiences {
    
    public partial class WorkexperiencesResponse {
        public virtual int ID { get; set; }
        public virtual ProfilesResponse Profiles { get; set; }
        public virtual string Enterprise { get; set; }
        public virtual string Occupation { get; set; }
        public virtual DateTime? InitialDate { get; set; }
        public virtual DateTime? FinalDate { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
    }
}
