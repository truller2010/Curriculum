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

using System.Collections.Generic;
using Curriculum.Core.Filter;
using Curriculum.Core.Pager;
using Curriculum.Models.Authentication.AuthenticationUsers;

#endregion

namespace Curriculum.Service.Authentication.AuthenticationUsersService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationUsersService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AuthenticationUsers Get(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICollection<AuthenticationUsers> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        long Save(AuthenticationUsers entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(AuthenticationUsers entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Page<AuthenticationUsers> Paginated(FindRequestImpl<SearchFilter> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        AuthenticationUsers GetByUsernameAndPassword(string username, string hashedPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        AuthenticationUsers GetByEmail(string email);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CUSNIRH"></param>
        /// <param name="passOld"></param>
        /// <param name="passNew"></param>
        /// <returns></returns>
        bool ActualizarContrasenia(long CUSNIRH, string passOld, string passNew);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locked"></param>
        /// <returns></returns>
        bool UserHasLockCode(LockCode locked);
    }
}