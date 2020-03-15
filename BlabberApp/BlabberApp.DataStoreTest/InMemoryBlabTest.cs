using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;

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
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            this._harness = new InMemory<Blab>(new ApplicationContext(options));
        }


        //Methods
        [TestMethod]
        public void Add_Blab_GetByUserId_Success()
        {
            //Arrange
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
    }
}
