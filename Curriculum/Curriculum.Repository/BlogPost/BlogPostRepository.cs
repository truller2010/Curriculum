#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Repository
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 14/01/2016   14:54
// //
// // File Modified on 14/01/2016/   14:54
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
using System.Globalization;
using System.Linq;
using Curriculum.Core.Filter;
using Curriculum.Core.Pager;
using Curriculum.Models.BlogArchives;
using Curriculum.Models.BlogPost;
using Curriculum.Repository.Abstract;
using NHibernate.Linq;

#endregion

namespace Curriculum.Repository.BlogPost
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogPostRepository : HibernateDao, IBlogPostRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogPostModel Get(int id)
        {
            return CurrentSession.Get<BlogPostModel>(id);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public IList<BlogPostModel> GetAll()
        {
            return GetAll<BlogPostModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(BlogPostModel entity)
        {
            return (int) CurrentSession.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public void Save(IList<BlogPostModel> entities)
        {
            SaveAll(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(BlogPostModel entity)
        {
            CurrentSession.Update(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<BlogPostModel> Paginated(PageRequest pageRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<BlogPostModel> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<BlogPostModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            var query = CurrentSession.Query<BlogPostModel>();

            int n;
            var isNumeric = int.TryParse(filter.Filter.Texto, out n);

            if (filter.Filter.Texto != null)
            {
                query = query.Where(x => x.Title.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.Description.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.ShortDescription.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || (isNumeric && x.ID == n));
            }

            return Paginated(query, filter.PageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<BlogPostModel> PaginatedByTag(FindRequestImpl<SearchFilter> filter)
        {
            var query =
                CurrentSession.Query<BlogPostModel>().Where(x => x.Tags.Any(y => y.BlogTag.Name == filter.Filter.Tag));

            int n;
            var isNumeric = int.TryParse(filter.Filter.Texto, out n);

            if (filter.Filter.Texto != null)
            {
                query = query.Where(x => x.Title.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.Description.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.ShortDescription.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || (isNumeric && x.ID == n));
            }

            return Paginated(query, filter.PageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<BlogPostModel> PaginatedByCategory(FindRequestImpl<SearchFilter> filter)
        {
            var query = CurrentSession.Query<BlogPostModel>().Where(x => x.Category.Name == filter.Filter.Category);

            int n;
            var isNumeric = int.TryParse(filter.Filter.Texto, out n);

            if (filter.Filter.Texto != null)
            {
                query = query.Where(x => x.Title.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.Description.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.ShortDescription.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || (isNumeric && x.ID == n));
            }

            return Paginated(query, filter.PageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<BlogPostModel> PaginatedByIdTitle(FindRequestImpl<SearchFilter> filter)
        {
            var query =
                CurrentSession.Query<BlogPostModel>()
                    .Where(x => x.Title == filter.Filter.Title && x.ID == filter.Filter.ID);

            int n;
            var isNumeric = int.TryParse(filter.Filter.Texto, out n);

            if (filter.Filter.Texto != null)
            {
                query = query.Where(x => x.Title.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.Description.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.ShortDescription.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || (isNumeric && x.ID == n));
            }

            return Paginated(query, filter.PageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<BlogPostModel> PaginatedByArchives(FindRequestImpl<SearchFilter> filter)
        {
            var year = Convert.ToInt32(filter.Filter.Year);
            var month = Convert.ToInt32(filter.Filter.Month);
            var query =
                CurrentSession.Query<BlogPostModel>().Where(x => x.PostedOn.Year == year && x.PostedOn.Month == month);

            int n;
            var isNumeric = int.TryParse(filter.Filter.Texto, out n);

            if (filter.Filter.Texto != null)
            {
                query = query.Where(x => x.Title.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.Description.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || x.ShortDescription.ToUpper().Contains(filter.Filter.Texto.ToUpper())
                                         || (isNumeric && x.ID == n));
            }

            return Paginated(query, filter.PageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public BlogArchivesModel GetArchives(int year)
        {
            var model = new BlogArchivesModel();

            var query = CurrentSession.Query<BlogPostModel>();

            model.Archives = (from i in query.ToList()
                orderby i.PostedOn descending
                group i by i.PostedOn.Month
                into grp
                select new ArchiveModel
                {
                    year = DateTime.Now.Year.ToString(),
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(grp.Key),
                    Month = grp.Key.ToString(),
                    Total = grp.Count().ToString()
                }).ToList();

            return model;
        }
    }
}