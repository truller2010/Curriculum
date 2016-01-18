#region Curriculum Header License

// // Solution: Curriculum
// // Project: Curriculum.Service
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
using Curriculum.Core.Filter;
using Curriculum.Core.Pager;
using Curriculum.Models.BlogArchives;
using Curriculum.Models.BlogPost;
using Curriculum.Repository.BlogPost;
using Spring.Transaction.Interceptor;

#endregion

namespace Curriculum.Service.BlogPost
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogPostService : IBlogPostService
    {
        /// <summary>
        /// 
        /// </summary>
        public IBlogPostRepository BlogPostRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public BlogPostModel Get(int id)
        {
            return BlogPostRepository.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public ICollection<BlogPostModel> GetAll()
        {
            return BlogPostRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Transaction]
        public int SaveOrUpdate(BlogPostModel entity)
        {
            if (entity.ID != 0)
            {
                var dbEntity = BlogPostRepository.Get(entity.ID);
                if (dbEntity != null)
                {
                    BlogPostRepository.Update(dbEntity);

                    return dbEntity.ID;
                }
                throw new ArgumentException("Invalid id");
            }
            return BlogPostRepository.Save(entity);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Transaction]
        public int Save(BlogPostModel entity)
        {
            return BlogPostRepository.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        [Transaction]
        public void Update(BlogPostModel entity)
        {
            BlogPostRepository.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.Paginated(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByTag(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByTag(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByCategory(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByCategory(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByIdTitle(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByIdTitle(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Page<BlogPostModel> PaginatedByArchives(FindRequestImpl<SearchFilter> filter)
        {
            return BlogPostRepository.PaginatedByArchives(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public BlogArchivesModel GetArchives(int year)
        {
            return BlogPostRepository.GetArchives(year);
        }
    }
}