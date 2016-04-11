using Spring.Util;
using System;
using System.Collections.Generic;

namespace Hipica.Utils.Pager
{
    /// <summary>
    /// Represents a property order for sorting a search
    /// </summary>
    public sealed class Order
    {
        /// <summary>
        /// Whether if we're ignoring case by default
        /// </summary>
        private static readonly bool DEFAULT_IGNORE_CASE = false;

        /// <summary>
        /// Sorting direction, <seealso cref="Direction"/>
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// The soring property
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// <c>true</c> if we want to explicitly ignore case in character comparison
        /// </summary>
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// Readonly property that represents if search is sorted ascendingly
        /// </summary>
        public bool Ascending
        {
            get
            {
                return this.Direction.Equals(Direction.ASC);
            }
        }

        /// <summary>
        /// Default explicit constructor
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Creates a new <seealso cref="Order"/> instance. if order is <c>null</c> then order defaults to
        /// <seealso cref="Sort.DEFAULT_DIRECTION"/>
        /// </summary>
        /// <param name="direction">can be <c>null</c>, will default to <seealso cref="Sort.DEFAULT_DIRECTION"/></param>
        /// <param name="property">must not be <c>null</c> or empty.</param>
        public Order(Direction? direction, string property)
            : this(direction, property, DEFAULT_IGNORE_CASE) { }

        /// <summary>
        /// Creates a new <seealso cref="Order"/> instance. Takes a single property. Direction defaults to
        /// <seealso cref="Sort.DEFAULT_DIRECTION"/>.
        /// </summary>
        /// <param name="property">must not be <c>null</c> or empty.</param>
        public Order(string property)
            : this(Sort.DEFAULT_DIRECTION, property) { }

        /// <summary>
        /// Creates a new <seealso cref="Order"/> instance. if order is <c>null</c> then order defaults to
        /// <seealso cref="Sort.DEFAULT_DIRECTION"/>
        /// </summary>
        /// <param name="direction">can be <c>null</c>, will default to <seealso cref="Sort.DEFAULT_DIRECTION"/></param>
        /// <param name="property">must not be <c>null</c> or empty.</param>
        /// <param name="ignoreCase"><c>true</c> if sorting should be case insensitive. <c>false</c> if sorting should be case sensitive.</param>
        private Order(Direction? direction, string property, bool ignoreCase)
        {
            if (!StringUtils.HasText(property))
            {
                throw new ArgumentException("Property must not null or empty!");
            }

            this.Direction = direction == null ? Sort.DEFAULT_DIRECTION : (Direction)direction;
            this.Property = property;
            this.IgnoreCase = ignoreCase;
        }

        /// <summary>
        /// Deprecated use <seealso cref="Sort.Sort(Direction, IList)"/> instead.
        /// </summary>
        /// <param name="direction">can be <c>null</c>, will default to <seealso cref="Sort.DEFAULT_DIRECTION"/></param>
        /// <param name="properties">must not be <c>null</c> or empty.</param>
        /// <returns>Order list</returns>
        [Obsolete("Deprecated use Sort.Sort(Direction, IList) instead.")]
        public static List<Order> Create(Direction direction, IEnumerable<string> properties)
        {
            List<Order> orders = new List<Order>();
            foreach (string property in properties)
            {
                orders.Add(new Order(direction, property));
            }
            return orders;
        }

        /// <summary>
        /// Returns a new <seealso cref="Order"/> with the given <seealso cref="Order"/>.
        /// </summary>
        /// <param name="order">the given order</param>
        /// <returns></returns>
        public Order With(Direction order)
        {
            return new Order(order, this.Property);
        }

        /// <summary>
        /// Returns a new <seealso cref="Sort"/> instance for the given properties.
        /// </summary>
        /// <param name="properties">the given properties</param>
        /// <returns>a new <seealso cref="Sort"/> instance for the given properties.</returns>
        public Sort WithProperties(string[] properties)
        {
            return new Sort(this.Direction, properties);
        }

        /// <summary>
        /// Returns a new <seealso cref="Order"/> with case insensitive sorting enabled.
        /// </summary>
        /// <returns>a new <seealso cref="Order"/> with case insensitive sorting enabled.</returns>
        public Order CreateIgnoreCase()
        {
            return new Order(Direction, Property, true);
        }

        /// <summary>
        /// Hashcode digest method
        /// </summary>
        /// <returns>hashcode digest</returns>
        public override int GetHashCode()
        {
            int result = 17;

            result = 31 * result + Direction.GetHashCode();
            result = 31 * result + Property.GetHashCode();

            return result;
        }

        /// <summary>
        /// Checks if this instance is equal to another one
        /// </summary>
        /// <param name="obj">the other instance</param>
        /// <returns><c>true</c> if both instances are considered equal</returns>
        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!(obj is Order))
            {
                return false;
            }

            Order that = (Order)obj;

            return this.Direction.Equals(that.Direction) && this.Property.Equals(that.Property);
        }

        /// <summary>
        /// String representation of this instance
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", Property, Direction);
        }
    }
}