#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Models
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 16/01/2016   23:11
// //
// // File Modified on 16/01/2016/   23:11
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

using FluentNHibernate.Mapping;
using NHibernate.Envers;
using NHibernate.Envers.Configuration.Attributes;

#endregion

namespace Curriculum.Models.Revision
{
    /// <summary>
    /// </summary>
    [RevisionEntity(typeof (AppRevisionListener))]
    public class AppRevisionEntity : DefaultTrackingModifiedEntitiesRevisionEntity
    {
        public virtual string UserName { get; set; }

        //public virtual string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        public class Properties
        {
            public const string RevisionDate = "RevisionDate";

            public const string UserName = "UserName";

            private Properties()
            {
            }

            //public const string DisplayName = "DisplayName";
        }
    }

    /// <summary>
    /// </summary>
    public class AppRevisionEntityMap : ClassMap<AppRevisionEntity>
    {
        /// <summary>
        /// </summary>
        public AppRevisionEntityMap()
        {
            Table("REVINFO");

            Id(x => x.Id).Column("REV");

            Map(x => x.RevisionDate).Column("REVTSTMP");
            Map(x => x.UserName).Column("USER_NAME");
            //Map(x => x.DisplayName).Column("DISPLAY_NAME");

            HasMany(x => x.ModifiedEntityNames)
                .Table("REVINFO_ELEMENTS")
                .KeyColumn("ELEMENT_ID")
                .Element("ELEMENT_NAME")
                .LazyLoad();
        }
    }
}