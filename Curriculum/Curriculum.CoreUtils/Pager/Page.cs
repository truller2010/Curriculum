#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.CoreUtils
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 16/01/2016   23:10
// //
// // File Modified on 16/01/2016/   23:10
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

#endregion

namespace Curriculum.CoreUtils.Pager
{
    /// <summary>
    ///     Search page
    /// </summary>
    /// <typeparam name="T">The type of the contained entities</typeparam>
    public class Page<T>
    {
        /// <summary>
        ///     Returns a new Page instance
        /// </summary>
        /// <param name="content">Page content</param>
        /// <param name="size">Page size</param>
        /// <param name="number">Page number</param>
        /// <param name="numberOfElements">Page size</param>
        /// <param name="sort">Sort order</param>
        /// <param name="totalElements">Total number of elements</param>
        /// <param name="pageSize">Requested page size</param>
        public Page(IList<T> content, long size, long number, long numberOfElements, Sort sort, long totalElements,
            int pageSize)
        {
            Content = content;
            Size = size;
            Number = number;
            NumberOfElements = numberOfElements;
            Sort = sort;
            TotalElements = totalElements;
            PageSize = pageSize;
            if (numberOfElements > 0)
            {
                TotalPages = (long) Math.Ceiling((decimal) totalElements/pageSize);
            }
        }

        /// <summary>
        ///     Returns an empty page instance
        /// </summary>
        public Page()
        {
        }

        /// <summary>
        ///     Entities list that conform a given page
        /// </summary>
        public IList<T> Content { get; set; }

        /// <summary>
        ///     The size of the page. Equals Content.Count
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        ///     Page number
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        ///     Number of elements really contained in this page
        /// </summary>
        public long NumberOfElements { get; set; }

        /// <summary>
        ///     Requested page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Total number of pages that one should request to obtain the full search
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        ///     How this page is sorted
        /// </summary>
        public Sort Sort { get; set; }

        /// <summary>
        ///     Total number of elements that really conformed the search
        /// </summary>
        public long TotalElements { get; set; }

        /// <summary>
        ///     The first page number. Defaults to 0.
        /// </summary>
        public bool FirstPage
        {
            get { return Number == 0; }
        }

        /// <summary>
        ///     The last page number. Defaults to TotalPages - 1.
        /// </summary>
        public bool LastPage
        {
            get { return Number == TotalPages - 1; }
        }
    }
}