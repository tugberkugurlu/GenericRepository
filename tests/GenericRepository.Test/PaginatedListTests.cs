using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GenericRepository.Test {
    
    public class PaginatedListTests {

        [Fact]
        public void Throws_ArgumentNullException_If_source_Param_Is_Null() { 

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new PaginatedList<object>(null, 1, 1, 1));
        }

        [Fact]
        public void Sets_The_PageIndex_Property_Corretly() {

            // Arrange
            var source = Enumerable.Empty<object>();
            var pageIndex = 2;
            var pageSize = 20;
            var totalCount = 50;

            // Act
            var paginatedList = new PaginatedList<object>(source, pageIndex, pageSize, totalCount);

            // Assert
            Assert.Equal(2, paginatedList.PageIndex);
        }

        [Fact]
        public void Sets_The_PageSize_Property_Corretly() {

            // Arrange
            var source = Enumerable.Empty<object>();
            var pageIndex = 2;
            var pageSize = 20;
            var totalCount = 50;

            // Act
            var paginatedList = new PaginatedList<object>(source, pageIndex, pageSize, totalCount);

            // Assert
            Assert.Equal(pageSize, paginatedList.PageSize);
        }

        [Fact]
        public void Sets_The_TotalCount_Property_Corretly() {

            // Arrange
            var source = Enumerable.Empty<object>();
            var pageIndex = 2;
            var pageSize = 20;
            var totalCount = 50;

            // Act
            var paginatedList = new PaginatedList<object>(source, pageIndex, pageSize, totalCount);

            // Assert
            Assert.Equal(totalCount, paginatedList.TotalCount);
        }

        [Fact]
        public void Sets_The_TotalPageCount_Property_Corretly() {

            // Arrange
            var source = Enumerable.Empty<object>();
            var pageIndex = 2;
            var pageSize = 20;
            var totalCount = 50;
            var totalPageCount = 3;

            // Act
            var paginatedList = new PaginatedList<object>(source, pageIndex, pageSize, totalCount);

            // Assert
            Assert.Equal(totalPageCount, paginatedList.TotalPageCount);
        }

        [Fact]
        public void Sets_The_HasPreviousPage_Property_Corretly() {

            // Arrange
            var source = Enumerable.Empty<object>();
            var pageIndex = 2;
            var pageSize = 20;
            var totalCount = 50;
            var hasPreviousPage = true;

            // Act
            var paginatedList = new PaginatedList<object>(source, pageIndex, pageSize, totalCount);

            // Assert
            Assert.Equal(hasPreviousPage, paginatedList.HasPreviousPage);
        }

        [Fact]
        public void Sets_The_HasNextPage_Property_Corretly() {

            // Arrange
            var source = Enumerable.Empty<object>();
            var pageIndex = 2;
            var pageSize = 20;
            var totalCount = 50;
            var hasNextPage = true;

            // Act
            var paginatedList = new PaginatedList<object>(source, pageIndex, pageSize, totalCount);

            // Assert
            Assert.Equal(hasNextPage, paginatedList.HasNextPage);
        }
    }
}