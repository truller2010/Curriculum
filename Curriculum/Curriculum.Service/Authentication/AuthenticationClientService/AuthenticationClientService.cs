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
using Curriculum.CoreUtils.Pager;
using Curriculum.Models.Authentication.AuthenticationClient;
using Curriculum.Repository.Authentication.AuthenticationClientRepository;
using Spring.Transaction.Interceptor;

#endregion

namespace Curriculum.Service.Authentication.AuthenticationClientService
{
    /// <summary>
    /// </summary>
    [Transaction(ReadOnly = true)]
    public class AuthenticationClientService : IAuthenticationClientService
    {
        /// <summary>
        /// </summary>
        private IAuthenticationClientRepository AuthenticationClientRepository;

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Transaction(ReadOnly = false)]
        public string Save(AuthenticationClient entity)
        {
            return AuthenticationClientRepository.Save(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        [Transaction(ReadOnly = false)]
        public void Save(IList<AuthenticationClient> entity)
        {
            AuthenticationClientRepository.Save(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        [Transaction(ReadOnly = false)]
        public void Update(AuthenticationClient entity)
        {
            AuthenticationClientRepository.Update(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationClient Get(string id)
        {
            return AuthenticationClientRepository.Get(id);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IList<AuthenticationClient> GetAll()
        {
            return AuthenticationClientRepository.GetAll();
        }

        /// <summary>
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        public Page<AuthenticationClient> Paginated(PageRequest pageRequest)
        {
            return AuthenticationClientRepository.Paginated(pageRequest);
        }
    }
}