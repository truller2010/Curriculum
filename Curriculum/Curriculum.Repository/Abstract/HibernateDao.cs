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

using System.Collections.Generic;
using System.Linq;
using Curriculum.Core.Pager;
using NHibernate;
using NHibernate.Criterion;
using Order = NHibernate.Criterion.Order;

#endregion

namespace Curriculum.Repository.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class HibernateDao
    {
        /// <summary>
        ///     Session factory for sub-classes.
        /// </summary>
        public ISessionFactory SessionFactory { get; set; }

        /// <summary>
        ///     Get's the current active session. Will retrieve session as managed by the
        ///     Open Session In View module if enabled.
        /// </summary>
        protected ISession CurrentSession
        {
            get { return SessionFactory.GetCurrentSession(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected IList<T> GetAll<T>() where T : class
        {
            var criteria = CurrentSession.CreateCriteria<T>();
            var result = criteria.List<T>();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        protected Page<T> GetAll<T>(ICriteria criteria) where T : class
        {
            var result = criteria.List<T>();

            return new Page<T>(result, result.Count, 0, result.Count, new Sort(), result.Count, result.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="criteria"></param>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        protected Page<T> Paginated<T>(ICriteria criteria, PageRequest pageRequest) where T : class
        {
            if (pageRequest.Size > 0)
            {
                criteria.SetFirstResult(pageRequest.Offset);
                criteria.SetMaxResults(pageRequest.Size);
            }

            if (pageRequest.Sort != null && pageRequest.Sort.Orders != null && pageRequest.Sort.Orders.Count > 0)
            {
                foreach (var o in pageRequest.Sort.Orders)
                {
                    if (o.Ascending)
                    {
                        criteria.AddOrder(Order.Asc(o.Property));
                    }
                    else
                    {
                        criteria.AddOrder(Order.Desc(o.Property));
                    }
                }
            }

            var result = criteria.List<T>();

            criteria.SetFirstResult(0);
            criteria.SetMaxResults(1);

            var totalElements = criteria.SetProjection(Projections.Count(Projections.Id())).UniqueResult<long>();

            return new Page<T>(result, result.Count, pageRequest.Page, result.Count, pageRequest.Sort, totalElements,
                pageRequest.Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryover"></param>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        protected Page<T> Paginated<T>(IQueryOver queryover, PageRequest pageRequest) where T : class
        {
            return Paginated<T>(queryover.UnderlyingCriteria, pageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryList"></param>
        /// <param name="queryCount"></param>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        protected Page<T> Paginated<T>(IQuery queryList, IQuery queryCount, PageRequest pageRequest) where T : class
        {
            queryList.SetFirstResult(pageRequest.Offset);
            queryList.SetMaxResults(pageRequest.Size);

            var result = queryList.List<T>();

            queryCount.SetFirstResult(0);
            queryCount.SetMaxResults(1);

            var totalElements = queryCount.UniqueResult<long>();

            return new Page<T>(result, result.Count, pageRequest.Page, result.Count, pageRequest.Sort, totalElements,
                pageRequest.Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        protected Page<T> Paginated<T>(IQueryable<T> q, PageRequest pageRequest)
        {
            long totalElements = q.Count();

            q = q.Skip(pageRequest.Offset).Take(pageRequest.Size);

            IList<T> result = q.ToList();

            return new Page<T>(result, result.Count, pageRequest.Page, result.Count, pageRequest.Sort, totalElements,
                pageRequest.Size);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        protected void SaveAll<T>(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                CurrentSession.Save(entity);
            }
        }
    }
}