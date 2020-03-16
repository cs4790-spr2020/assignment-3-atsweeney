using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;
using System;
using System.Collections;
using System.Linq;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemory_Blab_UnitTests
    {
        //Methods
        [TestMethod]
        public void Add_Blab_GetByUserId_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = harness = new InMemory<Blab>(new ApplicationContext(options));
            string Email = "foo1@example.com";
            Blab Expected = new Blab();
            Expected.Message = "This is a test. This is only a test. If this weren't a test, then this wouldn't be here, would it?";
            Expected.UserID = Email;
            harness.Add(Expected);

            //Act
            Blab Actual = (Blab)harness.GetByUserId(Email);

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Fail01()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.Add(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Fail02()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            string Email = "foo2@example.com";
            Blab Expected = new Blab();
            Expected.UserID = Email;
            harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.GetByUserId(""));

            //Assert
            Assert.AreEqual("userId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_Blab_GetBySysId_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            string Email = "foo3@example.com";
            Blab Expected = new Blab();
            Expected.UserID = Email;
            harness.Add(Expected);

            //Act
            Blab Actual = (Blab)harness.GetBySysId(Expected.SysId);

            //Assert
            Assert.AreEqual(Expected.SysId, Actual.SysId);
        }

        [TestMethod]
        public void Add_Blab_GetBySysId_Fail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            string Email = "foo4@example.com";
            Blab Expected = new Blab();
            Expected.UserID = Email;
            harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.GetBySysId(""));

            //Assert
            Assert.AreEqual("sysId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Remove_Blab_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            string Email = "foo5@example.com";
            Blab Test = new Blab();
            Test.UserID = Email;
            harness.Add(Test);

            //Act
            harness.Remove(Test);

            //Assert
            Assert.IsNull(harness.GetByUserId(Email));
        }

        [TestMethod]
        public void Remove_Blab_Fail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.Remove(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Update_Blab_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            string Email = "foo6@example.com";
            string message = "Hello, I'm a Blab!";
            Blab Test = new Blab();
            string TestSysId = Test.SysId;
            Test.UserID = Email;
            Test.Message = message;
            harness.Add(Test);

            //Act
            string NewMessage = "I'm a new Blab!";
            Test.Message = NewMessage;
            harness.Update(Test);
            Blab Test2 = (Blab)harness.GetBySysId(TestSysId);

            //Assert
            Assert.AreEqual(NewMessage, Test2.Message);
        }

        [TestMethod]
        public void Update_Blab_Fail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.Update(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void GetAll_Blab_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<Blab> harness = new InMemory<Blab>(new ApplicationContext(options));
            
            //Act
            var AllTheBlabs = harness.GetAll();

            //Assert
            Assert.IsTrue(AllTheBlabs is IEnumerable);
            Assert.AreEqual("foo1@example.com", AllTheBlabs.First().UserID);
        }
    }
}
