using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstTask;
using System;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChangeAge()
        {
            FullAge Dima = new FullAge("Dima", 19, 70, "1234567890");
            Dima.changeAge(20);
            Console.WriteLine("{0}", Dima);
            //Assert.IsFalse(false);
            Assert.AreEqual(20, Dima.getAge());
        }
        public void TestMethod2()
        {
            FullAge Dima = new FullAge("Dima", 19, 70, "1234567890");
            Dima.changePassport("0987654321");
            Assert.AreEqual("0987654321", Dima.getPassportNumber());
        }
    }
}
