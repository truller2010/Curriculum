#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Repository
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 16/01/2016   23:12
// //
// // File Modified on 16/01/2016/   23:12
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
using Curriculum.CoreUtils.Filter;
using Curriculum.CoreUtils.Pager;
using Curriculum.Models.Profiles;
using Curriculum.Repository.Abstract;
using NHibernate.Linq;

#endregion

namespace Curriculum.Repository.Profiles
{
    /// <summary>
    /// </summary>
    public class ProfilesRepository : HibernateDao, IProfilesRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProfilesModel Get(int id)
        {
            return CurrentSession.Get<ProfilesModel>(id);
        }

        /// <summary>
        ///     /
        /// </summary>
        /// <returns></returns>
        public IList<ProfilesModel> GetAll()
        {
            return GetAll<ProfilesModel>();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(ProfilesModel entity)
        {
            return (int) CurrentSession.Save(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entities"></param>
        public void Save(IList<ProfilesModel> entities)
        {
            SaveAll(entities);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ProfilesModel entity)
        {
            CurrentSession.Update(entity);
        }


        /// <summary>
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<ProfilesModel> Paginated(PageRequest pageRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IQueryable<ProfilesModel> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<ProfilesModel> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            var query = CurrentSession.Query<ProfilesModel>().Where(x => x.ID == 1);

            return Paginated(query, filter.PageRequest);
        }
    }
}