using System;
using System.Collections.Generic;

namespace GenericRepository {
    
    /// <summary>
    /// List object to represent the paginated collection.
    /// </summary>
    /// <typeparam name="T">Type of the Entity</typeparam>
    public class PaginatedList<T> : List<T> {

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPageCount { get; private set; }

        public bool HasPreviousPage {

            get {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage {

            get {
                return (PageIndex < TotalPageCount);
            }
        }

        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount) {

            if (source == null) {
                throw new ArgumentNullException("source");
            }

            if (pageSize > totalCount) {
                throw new ArgumentException(string.Format("{0} parameter cannot be bigger than {1} parameter.", "pageSize", "totalCount"), "pageSize");
            }

            // Check: Do we need to check if int parameters are lower than 0

            AddRange(source);

            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}