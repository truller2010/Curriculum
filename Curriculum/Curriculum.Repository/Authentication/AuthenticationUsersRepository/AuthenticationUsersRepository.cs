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
using Curriculum.Core.Filter;
using Curriculum.Core.Pager;
using Curriculum.Models.Authentication.AuthenticationUsers;
using Curriculum.Repository.Abstract;
using NHibernate.Linq;

#endregion

namespace Curriculum.Repository.Authentication.AuthenticationUsersRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationUsersRepository : HibernateDao, IAuthenticationUsersRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationUsers Get(long id)
        {
            return CurrentSession.Get<AuthenticationUsers>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<AuthenticationUsers> GetAll()
        {
            return GetAll<AuthenticationUsers>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long Save(AuthenticationUsers entity)
        {
            return (long) CurrentSession.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        public void Save(IList<AuthenticationUsers> entities)
        {
            SaveAll(entities);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(AuthenticationUsers entity)
        {
            CurrentSession.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public AuthenticationUsers GetByUsernameAndPassword(string username, string hashedPassword)
        {
            return CurrentSession.QueryOver<AuthenticationUsers>()
                .Where(u => u.Nombre == username && u.Password == hashedPassword)
                .List().FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CUCurriculum"></param>
        /// <param name="passOld"></param>
        /// <param name="passNew"></param>
        /// <returns></returns>
        public bool ActualizarContrasenia(long CUCurriculum, string passOld, string passNew)
        {
            var user =
                CurrentSession.QueryOver<AuthenticationUsers>().Where(x => x.Password == passOld).SingleOrDefault();

            if (user != null)
            {
                user.Password = passNew;
                CurrentSession.Update(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<AuthenticationUsers> Paginated(PageRequest pageRequest)
        {
            return Paginated<AuthenticationUsers>(CurrentSession.CreateCriteria<AuthenticationUsers>(), pageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<AuthenticationUsers> GetAllQueryable()
        {
            return CurrentSession.Query<AuthenticationUsers>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Page<AuthenticationUsers> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            AuthenticationUsers u = null;
            var qUsuarios2 = CurrentSession.Query<AuthenticationUsers>();
            return Paginated(qUsuarios2, filter.PageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public AuthenticationUsers GetByEmail(string email)
        {
            return CurrentSession.QueryOver<AuthenticationUsers>()
                .Where(u => u.Email == email)
                .List().FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locked"></param>
        /// <returns></returns>
        public bool UserHasLockCode(LockCode locked)
        {
            var status = false;
            status = CurrentSession.Query<AuthenticationUsers>()
                .Where(u => u.Email == locked.email && u.Nombre == locked.username && u.LockedCode == locked.lockCode)
                .ToList().Count() > 0
                ? true
                : false;

            return status;
        }
    }
}