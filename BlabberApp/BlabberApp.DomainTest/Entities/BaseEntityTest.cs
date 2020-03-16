using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BaseEntityTest
    {
        //Attributes
        private BaseEntity _harness;
        

        //Constructor
        public BaseEntityTest()
        {
            this._harness = new BaseEntity();
        }


        //Methods
        [TestMethod]
        public void TestSysId()
        {
            //Arrange
            string expected = this._harness.SysId;

            //Act
            string actual = this._harness.SysId;

            //Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
            Assert.AreEqual(true, this._harness.SysId is string);
        }

        [TestMethod]
        public void TestEqualsSysId()
        {
            //Arrange
            BaseEntity expected = this._harness;

            //Act
            BaseEntity actual = this._harness;

            //Assert
            Assert.IsTrue(expected.Equals(actual.SysId));
        }

        [TestMethod]
        public void TestCreatedDttm()
        {
            //Arrange
            BaseEntity Expected = new BaseEntity();

            //Act
            BaseEntity Actual = new BaseEntity();

            //Assert
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }

        [TestMethod]
        public void TestModifiedDttm()
        {
            //Arrange
            BaseEntity Expected = new BaseEntity();

            //Act
            BaseEntity Actual = new BaseEntity();

            //Assert
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
    }
}