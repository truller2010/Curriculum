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

#endregion

namespace Curriculum.Service.Authentication.AuthenticationClientService
{
    public interface IAuthenticationClientService
    {
        /// <summary>
        ///     Retrieves a single entity by its ID
        /// </summary>
        /// <param name="id">must not be <c>null</c></param>
        /// <returns>entity whose id matches id</returns>
        AuthenticationClient Get(string id);

        /// <summary>
        ///     Returns every entity in the database
        /// </summary>
        /// <returns>list with entities</returns>
        IList<AuthenticationClient> GetAll();

        /// <summary>
        ///     Returns every entity in the database, paginating the result
        /// </summary>
        /// <param name="pageRequest">must not be null</param>
        /// <returns>requested page number</returns>
        Page<AuthenticationClient> Paginated(PageRequest pageRequest);

        /// <summary>
        ///     Saves the entity
        /// </summary>
        /// <param name="entity">to be saved</param>
        /// <returns>assigned identifier</returns>
        string Save(AuthenticationClient entity);

        /// <summary>
        ///     Saves a entity list
        /// </summary>
        /// <param name="entity">entities to be saved</param>
        void Save(IList<AuthenticationClient> entity);

        /// <summary>
        ///     Updates an entity
        /// </summary>
        /// <param name="entity">to be updated</param>
        void Update(AuthenticationClient entity);
    }
}