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
        public void TestSetGetEmail_Fail00()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("Foobar"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail01()
        {
            //Arrange
            User harness = new User();

            //Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("example.com"));

            //Assert
            Assert.AreEqual("Invalid email", ex.Message.ToString());
        }

        [TestMethod]
        public void TestSetGetEmail_Fail02()
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
            string expected = harness.getSysId();

            //Act
            string actual = harness.getSysId();

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.getSysId() is string);
        }
    }
}