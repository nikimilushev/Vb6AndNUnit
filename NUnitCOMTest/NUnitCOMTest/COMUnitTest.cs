using NUnit.Framework;
using System;

namespace NUnitCOMTest
{
    [TestFixture]
    public class COMUnitTest
    {
        [STAThread]
        [Test]
        public void TestCreate_COMObjectSucceeds()
        {
            dynamic comObject = CreateComComponent("COMUnitTest.ClassToTest");

            var message = comObject.MethodToTest();

            Assert.AreEqual("Hello from ClassToTest", message); 

        }
        private dynamic CreateComComponent(string progId) 
        {
            Type type = Type.GetTypeFromProgID(progId);
            if (type == null)
            {
                throw new InvalidOperationException(
                    string.Format("The {0} is not registered on this system.", progId));
            }

            return Activator.CreateInstance(type) as dynamic;
        }
    }
}
