using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void clientTest()
        {
            ClientDropBoxClone.MainWindow win = new ClientDropBoxClone.MainWindow();
            int i = 1;
            int y = 2;
            int expected = 3;
            int actual = win.CountSum(i,y);
            Assert.AreEqual(expected, actual);
        }
    }
}
