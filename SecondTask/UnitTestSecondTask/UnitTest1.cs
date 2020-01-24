using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondTask;

namespace UnitTestSecondTask
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double[,] newMatrix = { {7, 5, 5, 1, 6 },
                                    {2, 3, 4, 2, 5},
                                    {6, 3, 2, 4, 4},
                                    {3, 5, 5, 7, 7},
                                    {7, 2, 4, 3, 2},
                                    {5, 4, 7, 5, 3},
                                    {4, 3, 4, 3, 4},
                                    {3, 4, 4, 5, 5} };
            Playoff playoff = new Playoff(newMatrix);
            Risk risk = Converter.fromPlayoffToRisk(playoff);
            double[] currentState = { 0.2, 0.1, 0.3, 0.3, 0.1 };
            risk.addStateOfNature(currentState);
            risk.findMaxExperimentPrice();

            Assert.AreEqual(1.4, risk.MaxExperiment);
        }
        [TestMethod]
        public void TestMethod2()
        {
            double[,] newMatrix = { {5, 1},
                                    {4, 2},
                                    {2, 3}, };
            Playoff playoff = new Playoff(newMatrix);
            Risk risk = Converter.fromPlayoffToRisk(playoff);
            double[] currentState = { 0.6, 0.4};
            risk.addStateOfNature(currentState);
            risk.findMaxExperimentPrice();

            Assert.AreEqual(0.8, risk.MaxExperiment);
        }
        [TestMethod]
        public void TestMethod3()
        {
            double[,] newMatrix = { {5, 1},
                                    {4, 2},
                                    {2, 3}, };
            Playoff playoff = new Playoff(newMatrix);
            Risk risk = Converter.fromPlayoffToRisk(playoff);
            double[] currentState = { 0.6, 0.2};


            Assert.AreEqual(false, risk.addStateOfNature(currentState));
        }
    }
}
