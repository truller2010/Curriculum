#region KotikoBlog Header License

// // Solution: KotikoBlog
// // Project: KotikoBlog.Backend
// //
// // This file is included in the KotikoBlog solution.
// //
// // File created on 14/01/2016   14:38
// //
// // File Modified on 14/01/2016/   14:38
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
using System.Web.Http;
using AutoMapper;
using Curriculum.Backend.Models.Authentication.AuthenticationUsers;
using Curriculum.Core.Filter;
using Curriculum.Core.Pager;
using Curriculum.Models.Authentication.AuthenticationUsers;
using Curriculum.Service.Authentication.AuthenticationUsersService;

#endregion

namespace Curriculum.Backend.Controllers.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationUsersController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        private IAuthenticationUsersService AuthenticationUsersService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Throw()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            var user = AuthenticationUsersService.Get(id);

            return Ok(Mapper.Map<AuthenticationUsersResponse>(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<AuthenticationUsers> GetAll()
        {
            IEnumerable<AuthenticationUsers> users = AuthenticationUsersService.GetAll();

            return Mapper.Map<IEnumerable<AuthenticationUsers>>(users);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public AuthenticationUsersResponse GetByEmail(string email)
        {
            var user = AuthenticationUsersService.GetByEmail(email);

            return Mapper.Map<AuthenticationUsersResponse>(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public AuthenticationUsersResponse GetByEmail(string email, string password)
        {
            var user = AuthenticationUsersService.GetByUsernameAndPassword(email, password);

            return Mapper.Map<AuthenticationUsersResponse>(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public AuthenticationUsersResponse Save(AuthenticationUsers entity)
        {
            var user = AuthenticationUsersService.Save(entity);

            return Mapper.Map<AuthenticationUsersResponse>(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Update(AuthenticationUsers entity)
        {
            AuthenticationUsersService.Update(entity);

            return Ok(Mapper.Map<AuthenticationUsersResponse>(entity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public Page<AuthenticationUsersResponse> Find(FindRequestImpl<SearchFilter> filter)
        {
            var users = AuthenticationUsersService.Paginated(filter);

            return Mapper.Map<Page<AuthenticationUsersResponse>>(users);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locked"></param>
        /// <returns></returns>
        [HttpPost]
        public bool checkLockCode(LockCode locked)
        {
            return AuthenticationUsersService.UserHasLockCode(locked);
        }
    }
}