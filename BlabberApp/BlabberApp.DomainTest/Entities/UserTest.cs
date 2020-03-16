using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetEmail_Success()
        {
            //Arrange
            User harness = new User();
            string expected = "foobar@example.com";
            harness.ChangeEmail("foobar@example.com");

            //Act
            string actual = harness.Email.ToString();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail02()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail03()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestGetSysId()
        {
            //Arrange
            User harness = new User();
            string expected = harness.SysId;

            //Act
            string actual = harness.SysId;

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.SysId is string);
        }

        [TestMethod]
        public void TestGetSetRegisterDTTM()
        {
            //Arrange
            User Expected = new User();
            Expected.RegisterDTTM = DateTime.Now;

            //Act
            User Actual = new User();
            Actual.RegisterDTTM = DateTime.Now;

            //Assert
            Assert.AreEqual(Expected.RegisterDTTM.ToString(), Actual.RegisterDTTM.ToString());
        }

        [TestMethod]
        public void TestGetSetLastLoginDTTM()
        {
            //Arrange
            User Expected = new User();
            Expected.LastLoginDTTM = DateTime.Now;

            //Act
            User Actual = new User();
            Actual.LastLoginDTTM = DateTime.Now;

            //Assert
            Assert.AreEqual(Expected.LastLoginDTTM.ToString(), Actual.LastLoginDTTM.ToString());
        }
    }
}