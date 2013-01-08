using GenericRepository.EntityFramework.Test.Infrastrucure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericRepository.EntityFramework.Test {
    
    public class EntityRepositoryTest {

        [Fact]
        public void GetAll_Should_Call_Set_Once_And_Get_Expected_Amount_Of_Entities() {

            // Arrange
            var people = GetDummyPeople(2);
            var personDbSet = GetPersonDbSet(people);
            var peopleContextMock = new Mock<IPeopleContext>();
            peopleContextMock.Setup(pc => pc.Set<Person>()).Returns(personDbSet);
            var entityRepository = new EntityRepository<Person>(peopleContextMock.Object);

            // Act
            IEnumerable<Person> peopleResult = entityRepository.GetAll().ToList();

            // Assert
            Assert.Equal(personDbSet.Count(), peopleResult.Count());
        }

        [Fact]
        public void GetSingle_Should_Call_Set_Once_And_Get_Expected_Entity() {

            // Arrange
            var targetPersonId = 2;
            var people = GetDummyPeople(3).ToList();
            var personDbSet = GetPersonDbSet(people);
            var peopleContextMock = new Mock<IPeopleContext>();
            peopleContextMock.Setup(pc => pc.Set<Person>()).Returns(personDbSet);
            var entityRepository = new EntityRepository<Person>(peopleContextMock.Object);
            var expectedPeson = people.FirstOrDefault(x => x.Id == targetPersonId);

            // Act
            Person person = entityRepository.GetSingle(targetPersonId);

            // Assert
            peopleContextMock.Verify(pc => pc.Set<Person>(), Times.Once());
            Assert.Same(expectedPeson, person);
        }

        [Fact]
        public void GetSingle_Should_Call_Set_Once_And_Return_Null() {

            // Arrange
            var targetPersonId = 4;
            var people = GetDummyPeople(3).ToList();
            var personDbSet = GetPersonDbSet(people);
            var peopleContextMock = new Mock<IPeopleContext>();
            peopleContextMock.Setup(pc => pc.Set<Person>()).Returns(personDbSet);
            var entityRepository = new EntityRepository<Person>(peopleContextMock.Object);

            // Act
            Person person = entityRepository.GetSingle(targetPersonId);

            // Assert
            peopleContextMock.Verify(pc => pc.Set<Person>(), Times.Once());
            Assert.Null(person);
        }

        // Privates

        private FakeDbSet<Person> GetPersonDbSet(IEnumerable<Person> people) {

            var personDbSet = new FakeDbSet<Person>();
            foreach (var person in people) {

                personDbSet.Add(person);
            }

            return personDbSet;
        }

        private IEnumerable<Person> GetDummyPeople(int count) {

            for (int i = 0; i < count; i++) {

                yield return new Person {
                    Id = i,
                    Name = string.Concat("Foo", i),
                    Surname = string.Concat("Bar", i),
                    Age = 5 * i,
                    CreatedOn = DateTime.Parse("2012-10-23 18:48")
                };
            }
        }
    }
}