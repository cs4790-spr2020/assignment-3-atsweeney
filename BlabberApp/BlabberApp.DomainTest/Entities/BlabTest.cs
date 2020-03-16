using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {
        [TestMethod]
        public void TestSetGetMessage()
        {
            //Arrange
            Blab harness = new Blab();
            string expected = "This is just a test. If this weren't a test, then this wouldn't be here, would it?";
            harness.Message = "This is just a test. If this weren't a test, then this wouldn't be here, would it?";

            //Act
            string actual = harness.Message;

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestSetGetUserID()
        {
            //Arrange
            Blab harness = new Blab();
            harness.UserID = "foobar@example.com";
            string expected = "foobar@example.com";

            //Act
            string actual = harness.UserID.ToString();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestGetSysId()
        {
            //Arrange
            Blab harness = new Blab();
            string expected = harness.SysId;

            //Act
            string actual = harness.SysId;

            //Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.SysId is string);
        }

        [TestMethod]
        public void TestDTTM()
        {
            //Arrange
            Blab Expected = new Blab();

            //Act
            Blab Actual = new Blab();

            //Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}
