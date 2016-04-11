using System;
using System.Collections.Generic;

namespace Hipica.Utils.Pager
{
    /// <summary>
    /// Search page
    /// </summary>
    /// <typeparam name="T">The type of the contained entities</typeparam>
    public class Page<T>
    {
        /// <summary>
        /// Entities list that conform a given page
        /// </summary>
        public IList<T> Content { get; set; }

        /// <summary>
        /// The size of the page. Equals Content.Count
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Page number
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Number of elements really contained in this page
        /// </summary>
        public long NumberOfElements { get; set; }

        /// <summary>
        /// Requested page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total number of pages that one should request to obtain the full search
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        /// How this page is sorted
        /// </summary>
        public Sort Sort { get; set; }

        /// <summary>
        /// Total number of elements that really conformed the search
        /// </summary>
        public long TotalElements { get; set; }

        /// <summary>
        /// The first page number. Defaults to 0.
        /// </summary>
        public bool FirstPage { get { return this.Number == 0; } }

        /// <summary>
        /// The last page number. Defaults to TotalPages - 1.
        /// </summary>
        public bool LastPage { get { return this.Number == this.TotalPages - 1; } }

        /// <summary>
        /// Returns a new Page instance
        /// </summary>
        /// <param name="content">Page content</param>
        /// <param name="size">Page size</param>
        /// <param name="number">Page number</param>
        /// <param name="numberOfElements">Page size</param>
        /// <param name="sort">Sort order</param>
        /// <param name="totalElements">Total number of elements</param>
        /// <param name="pageSize">Requested page size</param>
        public Page(IList<T> content, long size, long number, long numberOfElements, Sort sort, long totalElements, int pageSize)
        {
            this.Content = content;
            this.Size = size;
            this.Number = number;
            this.NumberOfElements = numberOfElements;
            this.Sort = sort;
            this.TotalElements = totalElements;
            this.PageSize = pageSize;
            if (numberOfElements > 0)
            {
                this.TotalPages = (long)Math.Ceiling((decimal)totalElements / pageSize);
            }
        }

        /// <summary>
        /// Returns an empty page instance
        /// </summary>
        public Page()
        {
        }
    }
}