#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Models
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 14/01/2016   14:52
// //
// // File Modified on 14/01/2016/   14:52
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
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using Curriculum.Models.BlogCategory;
using Curriculum.Models.BlogPostTagMap;

#endregion

namespace Curriculum.Models.BlogPost
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogPostModel
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Photo { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string Description { get; set; }
        public virtual string Meta { get; set; }
        public virtual string UrlSlug { get; set; }
        public virtual bool Published { get; set; }
        public virtual DateTime PostedOn { get; set; }
        public virtual DateTime? Modified { get; set; }
        public virtual BlogCategoryModel Category { get; set; }
        public virtual IList<BlogPostTagMapModel> Tags { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BlogPostMap : ClassMap<BlogPostModel>
    {
        public BlogPostMap()
        {
            Table("BlogPost");
            LazyLoad();
            Id(x => x.ID);
            Map(x => x.Title).Length(500).Not.Nullable();
            Map(x => x.Photo).Length(500);
            Map(x => x.ShortDescription).Length(5000).Not.Nullable();
            Map(x => x.Description).Length(5000).Not.Nullable();
            Map(x => x.Meta).Length(1000).Not.Nullable();
            Map(x => x.UrlSlug).Length(200).Not.Nullable();
            Map(x => x.Published).Not.Nullable();
            Map(x => x.PostedOn).Not.Nullable();
            Map(x => x.Modified);
            References(x => x.Category).Column("Category").Not.Nullable();
            HasMany(x => x.Tags).KeyColumn("Post_id");
        }
    }
}