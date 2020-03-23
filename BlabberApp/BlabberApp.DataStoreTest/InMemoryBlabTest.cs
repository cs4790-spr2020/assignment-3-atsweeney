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
        //Attributes
         private InMemory<Blab> _harness;


        //Constructor
         public InMemory_Blab_UnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            this._harness = new InMemory<Blab>(new ApplicationContext(options));
        }


        //Methods
        [TestMethod]
        public void Add_Blab_GetByUserId_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.Message = "This is a test. This is only a test. If this weren't a test, then this wouldn't be here, would it?";
            Expected.UserID = Email;
            this._harness.Add(Expected);

            //Act
            Blab Actual = (Blab)this._harness.GetByUserId(Email);

            //Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Fail01()
        {
            //Arrange
            this._harness.Reset();
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Add(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Fail02()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.UserID = Email;
            this._harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.GetByUserId(""));

            //Assert
            Assert.AreEqual("userId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Add_Blab_GetBySysId_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.UserID = Email;
            this._harness.Add(Expected);

            //Act
            Blab Actual = (Blab)this._harness.GetBySysId(Expected.SysId);

            //Assert
            Assert.AreEqual(Expected.SysId, Actual.SysId);
        }

        [TestMethod]
        public void Add_Blab_GetBySysId_Fail()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.UserID = Email;
            this._harness.Add(Expected);

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.GetBySysId(""));

            //Assert
            Assert.AreEqual("sysId is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Remove_Blab_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            Blab Test = new Blab();
            Test.UserID = Email;
            this._harness.Add(Test);

            //Act
            this._harness.Remove(Test);

            //Assert
            Assert.IsNull(this._harness.GetByUserId(Email));
        }

        [TestMethod]
        public void Remove_Blab_Fail()
        {
            //Arrange
            this._harness.Reset();
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Remove(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void Update_Blab_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email = "foo@example.com";
            string message = "Hello, I'm a Blab!";
            Blab Test = new Blab();
            string TestSysId = Test.SysId;
            Test.UserID = Email;
            Test.Message = message;
            this._harness.Add(Test);

            //Act
            string NewMessage = "I'm a new Blab!";
            Test.Message = NewMessage;
            this._harness.Update(Test);
            Blab Test2 = (Blab)this._harness.GetBySysId(TestSysId);

            //Assert
            Assert.AreEqual(NewMessage, Test2.Message);
        }

        [TestMethod]
        public void Update_Blab_Fail()
        {
            //Arrange
            this._harness.Reset();
            Blab expected = null;

            //Act
            var ex = Assert.ThrowsException<ArgumentNullException>(() => this._harness.Update(expected));

            //Assert
            Assert.AreEqual("Entity is null", ex.ParamName.ToString());
        }

        [TestMethod]
        public void GetAll_Blab_Success()
        {
            //Arrange
            this._harness.Reset();
            string Email1 = "foo@example.com";
            string Email2 = "bar@example.com";
            Blab Expected1 = new Blab();
            Blab Expected2 = new Blab();
            Expected1.UserID = Email1;
            Expected2.UserID = Email2;
            this._harness.Add(Expected1);
            this._harness.Add(Expected2);
            
            //Act
            var AllTheBlabs = this._harness.GetAll();

            //Assert
            Assert.IsTrue(AllTheBlabs is IEnumerable);
            Assert.AreEqual("foo@example.com", AllTheBlabs.First().UserID);
            Assert.AreEqual("bar@example.com", AllTheBlabs.Last().UserID);
        }
    }
}
