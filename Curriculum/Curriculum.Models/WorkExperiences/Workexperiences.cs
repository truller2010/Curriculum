#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Models
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 18/01/2016   19:34
// //
// // File Modified on 18/01/2016/   19:34
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System;
using Curriculum.Models.Profiles;
using FluentNHibernate.Mapping;

#endregion

namespace Curriculum.Models.WorkExperiences
{
    public class WorkExperiencesModel
    {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
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

    public class WorkExperiencesModelMap : ClassMap<WorkExperiencesModel>
    {
        public WorkExperiencesModelMap()
        {
            Table("WorkExperiences");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            Map(x => x.Enterprise).Column("Enterprise");
            Map(x => x.Occupation).Column("Occupation");
            Map(x => x.InitialDate).Column("InitialDate");
            Map(x => x.FinalDate).Column("FinalDate");
            Map(x => x.Description).Column("Description");
            Map(x => x.Created).Column("Created");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.Modified).Column("Modified");
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.Deleted).Column("Deleted");
            Map(x => x.DeletedBy).Column("DeletedBy");
        }
    }
}