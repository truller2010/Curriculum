#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Backend
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 18/01/2016   11:24
// //
// // File Modified on 18/01/2016/   11:24
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

using System.Text;
using System.Web;
using System.Web.Http.Description;

#endregion

namespace Curriculum.Backend.Areas.HelpPage
{
    public static class ApiDescriptionExtensions
    {
        /// <summary>
        ///     Generates an URI-friendly ID for the <see cref="ApiDescription" />. E.g. "Get-Values-id_name" instead of
        ///     "GetValues/{id}?name={name}"
        /// </summary>
        /// <param name="description">The <see cref="ApiDescription" />.</param>
        /// <returns>The ID as a string.</returns>
        public static string GetFriendlyId(this ApiDescription description)
        {
            var path = description.RelativePath;
            var urlParts = path.Split('?');
            var localPath = urlParts[0];
            string queryKeyString = null;
            if (urlParts.Length > 1)
            {
                var query = urlParts[1];
                var queryKeys = HttpUtility.ParseQueryString(query).AllKeys;
                queryKeyString = string.Join("_", queryKeys);
            }

            var friendlyPath = new StringBuilder();
            friendlyPath.AppendFormat("{0}-{1}",
                description.HttpMethod.Method,
                localPath.Replace("/", "-").Replace("{", string.Empty).Replace("}", string.Empty));
            if (queryKeyString != null)
            {
                friendlyPath.AppendFormat("_{0}", queryKeyString.Replace('.', '-'));
            }
            return friendlyPath.ToString();
        }
    }
}