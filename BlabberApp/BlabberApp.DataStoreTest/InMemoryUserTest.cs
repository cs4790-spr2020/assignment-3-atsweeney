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
        //Attributes
         private InMemory<User> _harness;


        //Constructor
         public InMemory_User_UnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            this._harness = new InMemory<User>(new ApplicationContext(options));
        }


        //Methods
        [TestMethod]
        public void Add_User_GetBySysId_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            User Expected = new User();
            Expected.ChangeEmail(Email);
            this._harness.Add(Expected);

            //Act
            User Actual = (User)this._harness.GetBySysId(Expected.SysId);

            //Assert
            Assert.AreEqual(Expected.Email, Actual.Email);
        }

        [TestMethod]
        public void Add_User_GetBySysId_Fail01()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            User Expected = new User();
            Expected.ChangeEmail(Email);
            this._harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.GetBySysId(""));

            //Assert
            Assert.AreEqual("sysId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_User_GetBySysId_Fail02()
        {
            //Arrange
            this._harness.Reset();
            User expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Add(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_User_GetByUserId_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            User Expected = new User();
            Expected.ChangeEmail(Email);
            this._harness.Add(Expected);

            //Act
            User Actual = (User)this._harness.GetByUserId(Expected.Email);

            //Assert
            Assert.AreEqual(Expected.Email, Actual.Email);
        }

        [TestMethod]
        public void Add_User_GetByUserId_Fail()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            User Expected = new User();
            Expected.ChangeEmail(Email);
            this._harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.GetByUserId(""));

            //Assert
            Assert.AreEqual("userId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Remove_User_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            User Test = new User();
            Test.ChangeEmail(Email);
            this._harness.Add(Test);

            //Act
            this._harness.Remove(Test);

            //Assert
            Assert.IsNull(this._harness.GetBySysId(Test.SysId));
        }

        [TestMethod]
        public void Remove_User_Fail()
        {
            //Arrange
            this._harness.Reset();
            User expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Remove(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Update_User_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            User Test = new User();
            string TestSysId = Test.SysId;
            Test.ChangeEmail(Email);
            Test.LastLoginDTTM = DateTime.Now;
            this._harness.Add(Test);

            //Act
            DateTime NewTime = DateTime.UtcNow;
            Test.LastLoginDTTM = NewTime;
            this._harness.Update(Test);
            User Test2 = (User)this._harness.GetBySysId(TestSysId);

            //Assert
            Assert.AreEqual(NewTime.ToString(), Test2.LastLoginDTTM.ToString());
        }

        [TestMethod]
        public void Update_User_Fail()
        {
            //Arrange
            this._harness.Reset();
            User expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Update(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void GetAll_User_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email1 = "foo@example.com";
            string Email2 = "bar@example.com";
            User Expected1 = new User();
            User Expected2 = new User();
            Expected1.ChangeEmail(Email1);
            Expected2.ChangeEmail(Email2);
            this._harness.Add(Expected1);
            this._harness.Add(Expected2);

            //Act
            var AllTheUsers = this._harness.GetAll();

            //Assert
            Assert.IsTrue(AllTheUsers is IEnumerable);
            Assert.AreEqual("foo@example.com", AllTheUsers.First().Email);
            Assert.AreEqual("bar@example.com", AllTheUsers.Last().Email);
        }
    }
}
