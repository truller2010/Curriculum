#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Service
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

using System.Collections.Generic;
using Curriculum.CoreUtils.Filter;
using Curriculum.CoreUtils.Pager;
using Curriculum.Models.Authentication.AuthenticationUsers;
using Curriculum.Repository.Authentication.AuthenticationUsersRepository;
using Spring.Transaction.Interceptor;

#endregion

namespace Curriculum.Service.Authentication.AuthenticationUsersService
{
    /// <summary>
    /// </summary>
    internal class AuthenticationUsersService : IAuthenticationUsersService
    {
        /// <summary>
        /// </summary>
        public IAuthenticationUsersRepository AuthenticationUsersRepository { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public AuthenticationUsers Get(long id)
        {
            return AuthenticationUsersRepository.Get(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public ICollection<AuthenticationUsers> GetAll()
        {
            return AuthenticationUsersRepository.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Transaction]
        public long Save(AuthenticationUsers entity)
        {
            var id = AuthenticationUsersRepository.Save(entity);

            return id;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        [Transaction]
        public void Update(AuthenticationUsers entity)
        {
            AuthenticationUsersRepository.Update(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Page<AuthenticationUsers> Paginated(FindRequestImpl<SearchFilter> filter)
        {
            return AuthenticationUsersRepository.Paginated(filter);
        }

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public AuthenticationUsers GetByUsernameAndPassword(string username, string hashedPassword)
        {
            return AuthenticationUsersRepository.GetByUsernameAndPassword(username, hashedPassword);
        }

        /// <summary>
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public AuthenticationUsers GetByEmail(string email)
        {
            return AuthenticationUsersRepository.GetByEmail(email);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passOld"></param>
        /// <param name="passNew"></param>
        /// <returns></returns>
        [Transaction]
        public bool ActualizarContrasenia(long id, string passOld, string passNew)
        {
            return AuthenticationUsersRepository.ActualizarContrasenia(id, passOld, passNew);
        }

        /// <summary>
        /// </summary>
        /// <param name="locked"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public bool UserHasLockCode(LockCode locked)
        {
            return AuthenticationUsersRepository.UserHasLockCode(locked);
        }
    }
}