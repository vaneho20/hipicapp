using System;

namespace Hipica.Utils.Pager
{
    public class PageRequest
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public Sort Sort { get; set; }

        public int Offset
        {
            get
            {
                return Page * Size;
            }
        }

        /// <summary>
        ///
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

        public PageRequest(int page, int size, Direction direction, String[] properties)
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

            this.Page = page;
            this.Size = size;
            this.Sort = sort;
        }

        /*
         * (non-Javadoc)
         * @see org.springframework.data.domain.Pageable#next()
         */

        public PageRequest Next()
        {
            return new PageRequest(Page + 1, Size, Sort);
        }

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

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (!(obj is PageRequest))
            {
                return false;
            }

            PageRequest that = (PageRequest)obj;

            bool pageEqual = this.Page == that.Page;
            bool sizeEqual = this.Size == that.Size;

            bool sortEqual = this.Sort == null ? that.Sort == null : this.Sort.Equals(that.Sort);

            return pageEqual && sizeEqual && sortEqual;
        }

        /*
         * (non-Javadoc)
         * @see java.lang.Object#hashCode()
         */

        public override int GetHashCode()
        {
            int result = 17;

            result = 31 * result + Page;
            result = 31 * result + Size;
            result = 31 * result + (null == Sort ? 0 : Sort.GetHashCode());

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