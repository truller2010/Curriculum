using System;
using FluentNHibernate.Mapping;

namespace Curriculum.Backend.Models.Education
{
    
    public partial class EducationsResponse
    {
        public virtual int ID { get; set; }
        public virtual ProfilesResponse Profiles { get; set; }
        public virtual string Titulation { get; set; }
        public virtual string Centre { get; set; }
        public virtual string DurationYears { get; set; }
        public virtual string GraduationDate { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual string DeletedBy { get; set; }
    }

}
