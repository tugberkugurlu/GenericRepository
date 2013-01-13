using GenericRepository.EntityFramework.Test.Infrastrucure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericRepository.EntityFramework.Test
{

    public class EntityRepositoryIdStringTest
    {

        [Fact]
        public void GetAll_StringId_Should_Call_Set_Once_And_Get_Expected_Amount_Of_Entities()
        {

            // Arrange
            var books = GetDummyBooks(2);
            var bookDbSet = GetBookDbSet(books);
            var bookContextMock = new Mock<IPeopleContext>();
            bookContextMock.Setup(pc => pc.Set<Book>()).Returns(bookDbSet);
            var entityRepository = new EntityRepository<Book, string>(bookContextMock.Object);

            // Act
            IEnumerable<Book> booksResult = entityRepository.GetAll().ToList();

            // Assert
            Assert.Equal(bookDbSet.Count(), booksResult.Count());
        }

        [Fact]
        public void GetSingle_StringId_Should_Call_Set_Once_And_Get_Expected_Entity()
        {

            // Arrange
            var targetBookId = "2";
            var books = GetDummyBooks(3).ToList();
            var bookDbSet = GetBookDbSet(books);
            var bookContextMock = new Mock<IPeopleContext>();
            bookContextMock.Setup(pc => pc.Set<Book>()).Returns(bookDbSet);
            var entityRepository = new EntityRepository<Book, string>(bookContextMock.Object);
            var expectedPeson = books.FirstOrDefault(x => x.Id == targetBookId);

            // Act
            Book book = entityRepository.GetSingle(targetBookId);

            // Assert
            bookContextMock.Verify(pc => pc.Set<Book>(), Times.Once());
            Assert.Same(expectedPeson, book);
        }


        [Fact]
        public void GetSingle_StringId_Should_Call_Set_Once_And_Return_Null()
        {

            // Arrange
            var targetBookId = "4";
            var books = GetDummyBooks(3).ToList();
            var bookDbSet = GetBookDbSet(books);
            var booksContextMock = new Mock<IPeopleContext>();
            booksContextMock.Setup(pc => pc.Set<Book>()).Returns(bookDbSet);
            var entityRepository = new EntityRepository<Book, string>(booksContextMock.Object);

            // Act
            Book book = entityRepository.GetSingle(targetBookId);

            // Assert
            booksContextMock.Verify(pc => pc.Set<Book>(), Times.Once());
            Assert.Null(book);
        }


        // Privates

        private FakeDbSet<Book> GetBookDbSet(IEnumerable<Book> books)
        {

            var bookDbSet = new FakeDbSet<Book>();
            foreach (var book in books)
            {

                bookDbSet.Add(book);
            }

            return bookDbSet;
        }

        private IEnumerable<Book> GetDummyBooks(int count)
        {

            for (int i = 0; i < count; i++)
            {
                yield return new Book
                {
                    Id = i.ToString(),
                    Name = string.Concat("Foo", i),
                    AuthorName = string.Concat("Bar", i),
                    PublishedOn = DateTime.Parse("2012-10-23 18:48")
                };
            }
        }
    }
}