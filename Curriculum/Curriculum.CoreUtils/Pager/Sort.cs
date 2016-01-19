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
using System.Linq;
using Spring.Util;

#endregion

namespace Curriculum.CoreUtils.Pager
{
    /// <summary>
    ///     Used for representing a page / search sorting
    /// </summary>
    public class Sort
    {
        /// <summary>
        ///     The default direction (ASC)
        /// </summary>
        public static readonly Direction DEFAULT_DIRECTION = Direction.ASC;

        /// <summary>
        ///     Creates a new <seealso cref="Sort" /> instance using the given <seealso cref="Order" />s.
        /// </summary>
        /// <param name="orders">must not be <c>null</c>.</param>
        public Sort(Order[] orders)
            : this(orders.ToList())
        {
        }

        /// <summary>
        ///     Creates a new <seealso cref="Sort" /> instance.
        /// </summary>
        public Sort()
        {
        }

        /// <summary>
        ///     Creates a new {@link Sort} instance.
        /// </summary>
        /// <param name="orders">must not be <c>null</c> or empty or contain <c>null</c>.</param>
        /// <exception cref="ArgumentException">In case the provided orders listis null or empty</exception>
        public Sort(List<Order> orders)
        {
            if (null == orders || !orders.Any())
            {
                throw new ArgumentException("You have to provide at least one sort property to sort by!");
            }

            Orders = orders;
        }

        /// <summary>
        ///     Creates a new <seealso cref="Sort" /> instance. Order defaults to <seealso cref="Direction.ASC" />.
        /// </summary>
        /// <param name="properties">must not be <c>null</c> or contain <c>null</c> or empty strings</param>
        public Sort(string[] properties)
            : this(DEFAULT_DIRECTION, properties)
        {
            ;
        }

        /// <summary>
        ///     Creates a new <seealso cref="Sort" /> instance.
        /// </summary>
        /// <param name="direction">defaults to <seealso cref="Sort.DEFAULT_DIRECTION" /> (for <c>null</c> cases, too)</param>
        /// <param name="properties">must not be  <c>null</c> or contain <c>null</c> or empty strings</param>
        public Sort(Direction direction, string[] properties)
            : this(direction, properties == null ? new List<string>() : properties.ToList())
        {
        }

        /// <summary>
        ///     Creates a new {@link Sort} instance.
        /// </summary>
        /// <param name="direction">defaults to <seealso cref="Sort.DEFAULT_DIRECTION" /> (for <c>null</c> cases, too)</param>
        /// <param name="properties">>must not be  <c>null</c> or contain <c>null</c> or empty strings</param>
        /// <exception cref="ArgumentException">In case the provided orders listis null or empty</exception>
        public Sort(Direction direction, List<string> properties)
        {
            if (properties == null || !properties.Any())
            {
                throw new ArgumentException("You have to provide at least one property to sort by!");
            }

            Orders = new List<Order>(properties.Count);

            foreach (var property in properties)
            {
                Orders.Add(new Order(direction, property));
            }
        }

        /// <summary>
        ///     Orders list
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        ///     Returns a new <seealso cref="Sort" /> consisting of the <seealso cref="Orders" />s of the current
        ///     <seealso cref="Sort" /> combined with the given
        /// </summary>
        /// <param name="sort">to be combined</param>
        /// <returns></returns>
        public Sort And(Sort sort)
        {
            if (sort == null)
            {
                return this;
            }

            IList<Order> these = new List<Order>(Orders);

            foreach (var order in sort.Orders)
            {
                these.Add(order);
            }

            return new Sort(these.ToArray());
        }

        /// <summary>
        ///     Returns the order registered for the given property.
        /// </summary>
        /// <param name="property">the property</param>
        /// <returns></returns>
        public Order GetOrderFor(string property)
        {
            foreach (var order in Orders)
            {
                if (order.Property.Equals(property))
                {
                    return order;
                }
            }

            return null;
        }

        /// <summary>
        ///     Returns the enumerable to iterate the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> Iterator()
        {
            return Orders;
        }

        /// <summary>
        ///     Checks if this instance is equal to another one
        /// </summary>
        /// <param name="obj">the other instance</param>
        /// <returns><c>true</c> if both instances are considered equal</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!(obj is Sort))
            {
                return false;
            }

            var that = (Sort) obj;

            return Orders.Equals(that.Orders);
        }

        /// <summary>
        ///     Hashcode digest method
        /// </summary>
        /// <returns>hashcode digest</returns>
        public override int GetHashCode()
        {
            var result = 17;
            result = 31*result + Orders.GetHashCode();
            return result;
        }

        /// <summary>
        ///     String representation of this instance
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            return StringUtils.CollectionToCommaDelimitedString(Orders);
        }
    }
}