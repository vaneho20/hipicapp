namespace Hipicapp.Utils.Pager
{
    /// <summary>
    /// A search request placed from a given component
    /// </summary>
    /// <typeparam name="T">The filter type contained in the request</typeparam>
    public class FindRequestImpl<T>
    {
        /// <summary>
        /// Search filter
        /// </summary>
        public T Filter { get; set; }

        /// <summary>
        /// The page request
        /// </summary>
        public PageRequest PageRequest { get; set; }
    }
}