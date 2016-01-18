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

using FluentNHibernate.Mapping;
using Curriculum.Models.BlogPost;
using Curriculum.Models.BlogTag;

#endregion

namespace Curriculum.Models.BlogPostTagMap
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogPostTagMapModel
    {
        public virtual int Post_id { get; set; }
        public virtual int Tag_id { get; set; }
        public virtual BlogPostModel BlogPost { get; set; }
        public virtual BlogTagModel BlogTag { get; set; }

        #region NHibernate Composite Key Requirements

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as BlogPostTagMapModel;
            if (t == null) return false;
            if (Post_id == t.Post_id
                && Tag_id == t.Tag_id)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            var hash = GetType().GetHashCode();
            hash = (hash*397) ^ Post_id.GetHashCode();
            hash = (hash*397) ^ Tag_id.GetHashCode();

            return hash;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class PostTagMapMap : ClassMap<BlogPostTagMapModel>
    {
        public PostTagMapMap()
        {
            Table("PostTagMap");
            LazyLoad();
            CompositeId().KeyProperty(x => x.Post_id, "Post_id")
                .KeyProperty(x => x.Tag_id, "Tag_id");
            References(x => x.BlogPost).Column("Post_id");
            References(x => x.BlogTag).Column("Tag_id");
        }
    }
}