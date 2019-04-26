using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class ClientUnitTest
    {
        [TestMethod]
        public void ClientCreation()
        {
            Client testClient = new Client();

            Assert.IsNotNull(testClient);
        }

        [TestMethod]
        public void JournalCreation()
        {
            Client testClient = new Client();
            Assert.IsNotNull(testClient.Journal);
        }

        [TestMethod]
        public void ClientInheritanceUserTest()
        {
            Client testClient = new Client();

            Assert.IsInstanceOfType(testClient, typeof(User));
        }
    }
}
