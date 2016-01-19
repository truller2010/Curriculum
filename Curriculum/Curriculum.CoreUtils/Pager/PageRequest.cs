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

#endregion

namespace Curriculum.CoreUtils.Pager
{
    public class PageRequest
    {
        /// <summary>
        /// </summary>
        public PageRequest()
            : this(0, 0, null)
        {
        }

        /**
         * Creates a new {@link PageRequest}. Pages are zero indexed, thus providing 0 for {@code page} will return the first
         * page.
         *
         * @param size
         * @param page
         */

        public PageRequest(int page, int size)
            : this(page, size, null)
        {
        }

        /**
         * Creates a new {@link PageRequest} with sort parameters applied.
         *
         * @param page
         * @param size
         * @param direction
         * @param properties
         */

        public PageRequest(int page, int size, Direction direction, string[] properties)
            : this(page, size, new Sort(direction, properties))
        {
        }

        /**
         * Creates a new {@link PageRequest} with sort parameters applied.
         *
         * @param page
         * @param size
         * @param sort can be {@literal null}.
         */

        public PageRequest(int page, int size, Sort sort)
        {
            if (page < 0)
            {
                throw new ArgumentException("Page index must not be less than zero!");
            }

            if (size < 0)
            {
                throw new ArgumentException("Page size must not be less than zero!");
            }

            Page = page;
            Size = size;
            Sort = sort;
        }

        /// <summary>
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// </summary>
        public Sort Sort { get; set; }

        /// <summary>
        /// </summary>
        public int Offset
        {
            get { return Page*Size; }
        }

        /*
         * (non-Javadoc)
         * @see org.springframework.data.domain.Pageable#next()
         */

        public PageRequest Next()
        {
            return new PageRequest(Page + 1, Size, Sort);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool HasPrevious()
        {
            return Page > 0;
        }

        /*
         * (non-Javadoc)
         * @see org.springframework.data.domain.Pageable#previousOrFirst()
         */

        public PageRequest PreviousOrFirst()
        {
            return HasPrevious() ? new PageRequest(Page - 1, Size, Sort) : this;
        }

        /*
         * (non-Javadoc)
         * @see org.springframework.data.domain.Pageable#first()
         */

        public PageRequest First()
        {
            return new PageRequest(0, Size, Sort);
        }

        /*
         * (non-Javadoc)
         * @see java.lang.Object#equals(java.lang.Object)
         */

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!(obj is PageRequest))
            {
                return false;
            }

            var that = (PageRequest) obj;

            var pageEqual = Page == that.Page;
            var sizeEqual = Size == that.Size;

            var sortEqual = Sort == null ? that.Sort == null : Sort.Equals(that.Sort);

            return pageEqual && sizeEqual && sortEqual;
        }

        /*
         * (non-Javadoc)
         * @see java.lang.Object#hashCode()
         */

        public override int GetHashCode()
        {
            var result = 17;

            result = 31*result + Page;
            result = 31*result + Size;
            result = 31*result + (null == Sort ? 0 : Sort.GetHashCode());

            return result;
        }

        /*
         * (non-Javadoc)
         * @see java.lang.Object#toString()
         */

        public override string ToString()
        {
            return string.Format("Page request [number: {0}, size {1}, sort: {2}]", Page, Size,
                Sort == null ? null : Sort.ToString());
        }
    }
}