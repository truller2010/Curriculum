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

#endregion

namespace Curriculum.Service.Authentication.AuthenticationRefreshTokenService
{
    public interface IAuthenticationRefreshTokenService
    {
        /// <summary>
        ///     Retrieves a single entity by its ID
        /// </summary>
        /// <param name="id">must not be <c>null</c></param>
        /// <returns>entity whose id matches id</returns>
        AuthenticationRefreshToken Get(string id);

        /// <summary>
        ///     Returns every entity in the database
        /// </summary>
        /// <returns>list with entities</returns>
        IList<AuthenticationRefreshToken> GetAll();

        /// <summary>
        ///     Returns every entity in the database, paginating the result
        /// </summary>
        /// <param name="pageRequest">must not be null</param>
        /// <returns>requested page number</returns>
        Page<AuthenticationRefreshToken> Paginated(PageRequest pageRequest);

        /// <summary>
        ///     Saves the entity
        /// </summary>
        /// <param name="entity">to be saved</param>
        /// <returns>assigned identifier</returns>
        string Save(AuthenticationRefreshToken entity);

        /// <summary>
        ///     Saves a entity list
        /// </summary>
        /// <param name="entity">entities to be saved</param>
        void Save(IList<AuthenticationRefreshToken> entity);

        /// <summary>
        ///     Updates an entity
        /// </summary>
        /// <param name="entity">to be updated</param>
        void Update(AuthenticationRefreshToken entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(AuthenticationRefreshToken entity);
    }
}