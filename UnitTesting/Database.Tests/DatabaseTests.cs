namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Test_ConsturctorWorksProperly()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16);
            Assert.AreEqual(database.Count, 16);
        }
        [Test]
        public void Test_AddElementWorksProperly()
        {
            Database database = new Database(1, 2, 3);
            database.Add(4);
            Assert.AreEqual(database.Count, 4);

        }
        [Test]
        public void Test_AddMoreElementsThanLenght()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
            var ex = Assert.Throws<InvalidOperationException>(() => database.Add(5));
            Assert.AreEqual(ex.Message, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void Test_RemoveElement()
        {
            Database database = new Database(1, 2, 3);
            database.Remove();
            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void Test_RemovingFromEmptyDatabase()
        {
            Database database = new Database();
            var ex = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual(ex.Message, "The collection is empty!");
        }
        [Test]
        public void Test_FetchReturnsElementsAsArray()
        {
            Database database = new Database(1, 2, 3);
            var arr = database.Fetch();
            Assert.AreEqual(arr.Length, 3);
        }
    }
}
