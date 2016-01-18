using System;
using Curriculum.Backend.Models.Profiles;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.Courses {
    
    public partial class CoursesResponse {
        public virtual int ID { get; set; }
        public virtual ProfilesResponse Profiles { get; set; }
        public virtual string Course { get; set; }
        public virtual DateTime InitialDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
    }

}
