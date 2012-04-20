using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericRepository {

    public class PaginatedList<T> : List<T> {

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize) {

            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);

            this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize).ToList());
        }
        
        public bool HasPreviousPage {

            get {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage {

            get {
                return (PageIndex + 1 < TotalPages);
            }
        }

    }
}
