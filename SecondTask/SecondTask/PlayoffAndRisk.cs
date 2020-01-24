using System;
using System.Linq;

namespace SecondTask
{
    //Playoff matrix
    class Playoff
    {
        private double[,] matrix;
        public double[,] Matrix => matrix;
        Playoff()
        {
           
        }

        public Playoff(double[,] matrix)
        {
            this.matrix = matrix;

        }
        //Find max value in row
        public double findMaxValueInRow(int rowNumber)
        {
            double max = 0;
            for (int i = 0 ; i < matrix.GetLength(0); i++)
            {
                if (max < matrix[i, rowNumber])
                    max = matrix[i, rowNumber];
            }
            return max;
        }
    }

    //Risk matrix
    class Risk
    {
        double[,] matrix;
        public double[,] Matrix => matrix;
        double[] riskValues;
        public double[] RiskValues => riskValues;
        double[] stateOfNature;
        public double[] StateOfNature => stateOfNature;
        public Risk(int n, int m)
        {
            matrix = new double[n, m];
        }
        public Risk(double[,] matrix)
        {
            this.matrix = matrix;
            this.riskValues = new double[matrix.GetLength(0)];
        }
        public void addStateOfNature(double[] stateOfNature)
        {
            this.stateOfNature = stateOfNature;
        }
        public double findMaxExperimentPrice()
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                riskValues[i] = 0;
                for (int j = 0; j < m; j++)
                {
                    riskValues[i] += matrix[i, j] * stateOfNature[j];
                }
            }
            return riskValues.Min();
        }
    }

    //Converter from playoff to risk matrix
    class Converter
    {
        public static Risk fromPlayoffToRisk(Playoff playoff)
        {
            int n = playoff.Matrix.GetLength(0);
            int m = playoff.Matrix.GetLength(1);
            //Creating risk matrix the same size as playoff
            double[,] riskMatrix = new double[n, m];
            for (int j = 0; j < m; j++)
            {
                //Finding maximum value in current row
                double rowMax = playoff.findMaxValueInRow(j);
                for (int i = 0; i < n; i++)
                {
                    riskMatrix[i, j] = rowMax - playoff.Matrix[i, j];
                }
            }
            Risk risk = new Risk(riskMatrix);
            return risk;
        }
    }

    class PlayoffAndRisk
    {
        static void Main(string[] args)
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
            double[] currentState = {0.2, 0.1, 0.3, 0.3, 0.1};
            risk.addStateOfNature(currentState);
            double min = risk.findMaxExperimentPrice();
            Console.WriteLine($"{min}");
        }
    }
}
