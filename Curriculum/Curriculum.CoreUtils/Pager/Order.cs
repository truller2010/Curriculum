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
using Spring.Util;

#endregion

namespace Curriculum.CoreUtils.Pager
{
    /// <summary>
    ///     Represents a property order for sorting a search
    /// </summary>
    public sealed class Order
    {
        /// <summary>
        ///     Whether if we're ignoring case by default
        /// </summary>
        private static readonly bool DEFAULT_IGNORE_CASE = false;

        /// <summary>
        ///     Default explicit constructor
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        ///     Creates a new <seealso cref="Order" /> instance. if order is <c>null</c> then order defaults to
        ///     <seealso cref="Sort.DEFAULT_DIRECTION" />
        /// </summary>
        /// <param name="direction">can be <c>null</c>, will default to <seealso cref="Sort.DEFAULT_DIRECTION" /></param>
        /// <param name="property">must not be <c>null</c> or empty.</param>
        public Order(Direction? direction, string property)
            : this(direction, property, DEFAULT_IGNORE_CASE)
        {
        }

        /// <summary>
        ///     Creates a new <seealso cref="Order" /> instance. Takes a single property. Direction defaults to
        ///     <seealso cref="Sort.DEFAULT_DIRECTION" />.
        /// </summary>
        /// <param name="property">must not be <c>null</c> or empty.</param>
        public Order(string property)
            : this(Sort.DEFAULT_DIRECTION, property)
        {
        }

        /// <summary>
        ///     Creates a new <seealso cref="Order" /> instance. if order is <c>null</c> then order defaults to
        ///     <seealso cref="Sort.DEFAULT_DIRECTION" />
        /// </summary>
        /// <param name="direction">can be <c>null</c>, will default to <seealso cref="Sort.DEFAULT_DIRECTION" /></param>
        /// <param name="property">must not be <c>null</c> or empty.</param>
        /// <param name="ignoreCase">
        ///     <c>true</c> if sorting should be case insensitive. <c>false</c> if sorting should be case
        ///     sensitive.
        /// </param>
        private Order(Direction? direction, string property, bool ignoreCase)
        {
            if (!StringUtils.HasText(property))
            {
                throw new ArgumentException("Property must not null or empty!");
            }

            Direction = direction == null ? Sort.DEFAULT_DIRECTION : (Direction) direction;
            Property = property;
            IgnoreCase = ignoreCase;
        }

        /// <summary>
        ///     Sorting direction, <seealso cref="Direction" />
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        ///     The soring property
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        ///     <c>true</c> if we want to explicitly ignore case in character comparison
        /// </summary>
        public bool IgnoreCase { get; set; }

        /// <summary>
        ///     Readonly property that represents if search is sorted ascendingly
        /// </summary>
        public bool Ascending
        {
            get { return Direction.Equals(Direction.ASC); }
        }

        /// <summary>
        ///     Deprecated use <seealso cref="Sort.Sort(Direction, IList)" /> instead.
        /// </summary>
        /// <param name="direction">can be <c>null</c>, will default to <seealso cref="Sort.DEFAULT_DIRECTION" /></param>
        /// <param name="properties">must not be <c>null</c> or empty.</param>
        /// <returns>Order list</returns>
        [Obsolete("Deprecated use Sort.Sort(Direction, IList) instead.")]
        public static List<Order> Create(Direction direction, IEnumerable<string> properties)
        {
            var orders = new List<Order>();
            foreach (var property in properties)
            {
                orders.Add(new Order(direction, property));
            }
            return orders;
        }

        /// <summary>
        ///     Returns a new <seealso cref="Order" /> with the given <seealso cref="Order" />.
        /// </summary>
        /// <param name="order">the given order</param>
        /// <returns></returns>
        public Order With(Direction order)
        {
            return new Order(order, Property);
        }

        /// <summary>
        ///     Returns a new <seealso cref="Sort" /> instance for the given properties.
        /// </summary>
        /// <param name="properties">the given properties</param>
        /// <returns>a new <seealso cref="Sort" /> instance for the given properties.</returns>
        public Sort WithProperties(string[] properties)
        {
            return new Sort(Direction, properties);
        }

        /// <summary>
        ///     Returns a new <seealso cref="Order" /> with case insensitive sorting enabled.
        /// </summary>
        /// <returns>a new <seealso cref="Order" /> with case insensitive sorting enabled.</returns>
        public Order CreateIgnoreCase()
        {
            return new Order(Direction, Property, true);
        }

        /// <summary>
        ///     Hashcode digest method
        /// </summary>
        /// <returns>hashcode digest</returns>
        public override int GetHashCode()
        {
            var result = 17;

            result = 31*result + Direction.GetHashCode();
            result = 31*result + Property.GetHashCode();

            return result;
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

            if (!(obj is Order))
            {
                return false;
            }

            var that = (Order) obj;

            return Direction.Equals(that.Direction) && Property.Equals(that.Property);
        }

        /// <summary>
        ///     String representation of this instance
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", Property, Direction);
        }
    }
}