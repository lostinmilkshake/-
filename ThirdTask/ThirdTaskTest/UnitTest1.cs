using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdTask;

namespace ThirdTaskTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstTest()
        {
            int[,] graphMatrix = { {0, 16, 13, 0, 0, 0},
                                    {0, 0, 10, 12, 0, 0},
                                    {0, 4, 0, 0, 14, 0},
                                    {0, 0, 9, 0, 0, 20},
                                    {0, 0, 0, 7, 0, 4},
                                    {0, 0, 0, 0, 0, 0} };
            Graph newgraph = new Graph(graphMatrix);
            //Assert.AreEqual(newgraph.getResidualCapacity().Length, 6);
            Assert.AreEqual(newgraph.getResidualCapacity(), graphMatrix);
        }
        [TestMethod]
        public void SecondTest()
        {
            int[,] graphMatrix = { {0, 16, 13, 0, 0, 0},
                                    {0, 0, 10, 12, 0, 0},
                                    {0, 4, 0, 0, 14, 0},
                                    {0, 0, 9, 0, 0, 20},
                                    {0, 0, 0, 7, 0, 4},
                                    {0, 0, 0, 0, 0, 0} };
            Graph newgraph = new Graph(graphMatrix);
            Assert.AreEqual(newgraph.getResidualCapacity().Length, 36);
        }
        [TestMethod]
        public void ThirdTest()
        {
            int[,] graphMatrix = { {0, 16, 13, 0, 0, 0},
                                    {0, 0, 10, 12, 0, 0},
                                    {0, 4, 0, 0, 14, 0},
                                    {0, 0, 9, 0, 0, 20},
                                    {0, 0, 0, 7, 0, 4},
                                    {0, 0, 0, 0, 0, 0} };
            Graph newgraph = new Graph(graphMatrix);
            Assert.AreEqual(newgraph.fordFulkerson(), 23);
        }
    }
}
