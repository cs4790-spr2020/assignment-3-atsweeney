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
    public class InMemory_User_UnitTests
    {
        //Methods
        [TestMethod]
        public void Add_User_GetBySysId_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            string Email = "foo1@example.com";
            User Expected = new User();
            Expected.ChangeEmail(Email);
            harness.Add(Expected);

            //Act
            User Actual = (User)harness.GetBySysId(Expected.SysId);

            //Assert
            Assert.AreEqual(Expected.Email, Actual.Email);
        }

        [TestMethod]
        public void Add_User_GetBySysId_Fail01()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            string Email = "foo2@example.com";
            User Expected = new User();
            Expected.ChangeEmail(Email);
            harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.GetBySysId(""));

            //Assert
            Assert.AreEqual("sysId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_User_GetBySysId_Fail02()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            User expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.Add(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Remove_User_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            string Email = "foo3@example.com";
            User Test = new User();
            Test.ChangeEmail(Email);
            harness.Add(Test);

            //Act
            harness.Remove(Test);

            //Assert
            Assert.IsNull(harness.GetBySysId(Test.SysId));
        }

        [TestMethod]
        public void Remove_User_Fail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            User expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.Remove(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Update_User_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            string Email = "foo4@example.com";
            User Test = new User();
            string TestSysId = Test.SysId;
            Test.ChangeEmail(Email);
            Test.LastLoginDTTM = DateTime.Now;
            harness.Add(Test);

            //Act
            DateTime NewTime = DateTime.UtcNow;
            Test.LastLoginDTTM = NewTime;
            harness.Update(Test);
            User Test2 = (User)harness.GetBySysId(TestSysId);

            //Assert
            Assert.AreEqual(NewTime.ToString(), Test2.LastLoginDTTM.ToString());
        }

        [TestMethod]
        public void Update_User_Fail()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));
            User expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => harness.Update(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void GetAll_User_Success()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            InMemory<User> harness = new InMemory<User>(new ApplicationContext(options));

            //Act
            var AllTheUsers = harness.GetAll();

            //Assert
            Assert.IsTrue(AllTheUsers is IEnumerable);
            Assert.AreEqual("foo1@example.com", AllTheUsers.First().Email);
        }
    }
}
