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
            Assert.AreEqual(newgraph.findMaxFlow(), 23);
        }
        [TestMethod]
        public void SecondTest()
        {
            int[,] graphMatrix = { {0, 1000, 1000, 0},
                                    {0, 0, 1, 1000},
                                    {0, 0, 0, 1000},
                                    {0, 0, 0, 0 } };
            Graph newgraph = new Graph(graphMatrix);
            Assert.AreEqual(newgraph.findMaxFlow(), 2000);
        }
        [TestMethod]
        public void ThirdTest()
        {
            int[,] graphMatrix = { {0, 9, 8, 9, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 5, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 2, 5, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 4, 0, 3, 0, 0, 6, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 5, 0, 5, 0, 3, 5, 0, 0, 0},
                                    {0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 0, 7, 0, 0},
                                    {0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 7},
                                    {0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 1, 0, 1, 6},
                                    {0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 9},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Graph newgraph = new Graph(graphMatrix);
            Assert.AreEqual(newgraph.findMaxFlow(), 22);
        }
    }
}
