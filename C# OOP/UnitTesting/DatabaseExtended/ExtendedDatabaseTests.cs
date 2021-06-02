using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        private readonly Person[] people =
        {
            new Person(12345, "Pesho"),
            new Person(54321, "Gosho")
        };

        private readonly List<Person> bigCollection = CreateBiggerCollection();

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase(people);
        }

        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            var expected = new Person[]
            {
                new Person(12345, "Pesho"),
                new Person(54321, "Gosho")
            };

            this.database = new ExtendedDatabase(expected);

            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestIfConstructorWorksProperly()
        {
            var newMembers = new Person[]
            {
                new Person(90, "Bambam"),
                new Person(29, "PingPong")
            };

            this.database = new ExtendedDatabase(newMembers);

            var expectedCount = newMembers.Length;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfCollectionIsBiggerThanCapacity()
        {
            this.bigCollection.Add(new Person(80, "Grisho"));

            Assert.Throws<ArgumentException>(() => { this.database = new ExtendedDatabase(bigCollection.ToArray()); });
        }

        [Test]
        public void AddShouldThrowExceptionWhenCollectionIsBiggerThanCapacity()
        {
            this.database = new ExtendedDatabase(bigCollection.ToArray());

            Assert.Throws<InvalidOperationException>(() => { this.database.Add(new Person(60, "Name")); });
        }

        [Test]
        public void AddShouldThrowExceptionWhenUsernameExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var person = new Person(46273, "Pesho");
                this.database.Add(person);
            });
        }

        [Test]

        public void AddShouldThrowExceptionWhenIdExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var person = new Person(12345, "Stamat");
                this.database.Add(person);
            });
        }

        [Test]
        public void CheckIfRemoveWorksProperly()
        {
            this.database.Remove();

            var expectedCount = 1;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenCollectionIsEmpty()
        {
            var emptyArguments = new Person[] { };
            this.database = new ExtendedDatabase(emptyArguments);

            Assert.Throws<InvalidOperationException>(() => { this.database.Remove(); });

        }

        [Test]
        public void CheckIfFindByUsernameWorksProperly()
        {
            var expectedUsername = "Pesho";

            var actualPerson = this.database.FindByUsername(expectedUsername);

            Assert.AreEqual(expectedUsername, actualPerson.UserName);

        }

        [TestCase("Michael")]
        [TestCase("Johnny")]
        public void FindUsernameShouldThrowExceptionWhenNoSuchUsername(string username)
        {
            Assert.Throws<InvalidOperationException>(() => { this.database.FindByUsername(username); });
        }

        [Test]
        public void FindUsernameShouldThrowExceptionWhenUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => { this.database.FindByUsername(null); });
        }

        [Test]
        public void CheckIfFindByIdWorksProperly()
        {
            var expectedId = 12345;

            var actualPerson = this.database.FindById(expectedId);

            Assert.AreEqual(expectedId, actualPerson.Id);

        }

        [TestCase(23982)]
        [TestCase(745283)]
        public void FindByIdShouldThrowExceptionWhenInvalidId(long id)
        {
            Assert.Throws<InvalidOperationException>(() => { this.database.FindById(id); });
        }

        [TestCase(-129)]
        [TestCase(-32189)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegative(long negativeId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { this.database.FindById(negativeId); });
        }

        private static List<Person> CreateBiggerCollection()
        {
            return new List<Person>()
            {
                new Person(2178, "Joro"),
                new Person(219, "Stamat"),
                new Person(222, "Dimcho"),
                new Person(642, "Nasko"),
                new Person(99, "Pesho"),
                new Person(123, "Gosho"),
                new Person(311, "Bobby"),
                new Person(45, "Mitko"),
                new Person(98, "Boiko"),
                new Person(41, "Ana"),
                new Person(76, "Gergana"),
                new Person(21, "Milena"),
                new Person(69, "Maya"),
                new Person(57, "Raya"),
                new Person(90, "Elena"),
                new Person(49, "Neli")
            };
        }
    }
}