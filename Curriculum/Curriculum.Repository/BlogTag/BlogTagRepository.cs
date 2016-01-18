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
using System.Linq;
using Curriculum.Core.Filter;
using Curriculum.Core.Pager;
using Curriculum.Models.BlogTag;
using Curriculum.Repository.Abstract;

#endregion

namespace Curriculum.Repository.BlogTag
{
    /// <summary>
    /// 
    /// </summary>
    public class BlogTagRepository : HibernateDao, IBlogTagRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogTagModel Get(int id)
        {
            return CurrentSession.Get<BlogTagModel>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<BlogTagModel> GetAll()
        {
            return GetAll<BlogTagModel>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(BlogTagModel entity)
        {
            return (int) CurrentSession.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public void Save(IList<BlogTagModel> entities)
        {
            SaveAll(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(BlogTagModel entity)
        {
            CurrentSession.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<BlogTagModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<BlogTagModel> Paginated(PageRequest pageRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<BlogTagModel> GetAllQueryable()
        {
            throw new NotImplementedException();
        }
    }
}