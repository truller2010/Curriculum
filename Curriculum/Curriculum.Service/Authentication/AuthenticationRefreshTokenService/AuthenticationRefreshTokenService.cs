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
using Curriculum.Core.Pager;
using Curriculum.Models.Authentication.AuthenticationRefreshToken;
using Curriculum.Repository.Authentication.AuthenticationRefreshTokenRepository;
using Spring.Transaction.Interceptor;

#endregion

namespace Curriculum.Service.Authentication.AuthenticationRefreshTokenService
{
    /// <summary>
    /// 
    /// </summary>
    [Transaction(ReadOnly = true)]
    public class AuthenticationRefreshTokenService : IAuthenticationRefreshTokenService
    {
        /// <summary>
        /// 
        /// </summary>
        private IAuthenticationRefreshTokenRepository AuthenticationRefreshTokenRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public string Save(AuthenticationRefreshToken entity)
        {
            return AuthenticationRefreshTokenRepository.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        [Transaction(ReadOnly = false)]
        public void Save(IList<AuthenticationRefreshToken> entity)
        {
            AuthenticationRefreshTokenRepository.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        [Transaction(ReadOnly = false)]
        public void Update(AuthenticationRefreshToken entity)
        {
            AuthenticationRefreshTokenRepository.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationRefreshToken Get(string id)
        {
            return AuthenticationRefreshTokenRepository.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<AuthenticationRefreshToken> GetAll()
        {
            return AuthenticationRefreshTokenRepository.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<AuthenticationRefreshToken> Paginated(PageRequest pageRequest)
        {
            return AuthenticationRefreshTokenRepository.Paginated(pageRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        [Transaction(ReadOnly = false)]
        public void Delete(AuthenticationRefreshToken entity)
        {
            AuthenticationRefreshTokenRepository.Delete(entity);
        }
    }
}