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

using Curriculum.Models.Profiles;
using Curriculum.Models.SkillsCode;
using Curriculum.Models.SkillsPercentages;
using FluentNHibernate.Mapping;

#endregion

namespace Curriculum.Models.ProfilesSkillsCode
{
    public class ProfilesSkillsCodeModel
    {
        public virtual int ID { get; set; }
        public virtual ProfilesModel Profiles { get; set; }
        public virtual SkillsCodeModel SkillsCode { get; set; }
        public virtual SkillsPercentagesModel SkillsPercentages { get; set; }
    }

    public class ProfilesSkillsCodeModelMap : ClassMap<ProfilesSkillsCodeModel>
    {
        public ProfilesSkillsCodeModelMap()
        {
            Table("ProfilesSkillsCode");
            LazyLoad();
            Id(x => x.ID).GeneratedBy.Identity().Column("ID");
            References(x => x.Profiles).Column("idProfile");
            References(x => x.SkillsCode).Column("idSkillsCode");
            References(x => x.SkillsPercentages).Column("idSkillsPercentage");
        }
    }
}