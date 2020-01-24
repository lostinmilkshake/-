using System;
using System.IO;
using System.Linq;

namespace SecondTask
{
    //Playoff matrix
    public class Playoff
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
        public double findMaxValueInColumn(int columnNumber)
        {
            double max = 0;
            for (int i = 0 ; i < matrix.GetLength(0); i++)
            {
                if (max < matrix[i, columnNumber])
                    max = matrix[i, columnNumber];
            }
            return max;
        }
    }

    //Risk matrix
    public class Risk
    {
        double[,] matrix; //Risk matrix
        public double[,] Matrix => matrix; 
        double[] riskValues; //Risk values
        public double[] RiskValues => riskValues;
        double[] stateOfNature; //State of nature
        public double[] StateOfNature => stateOfNature;

        double maxExperiment; //Max experiment price
        public double MaxExperiment => maxExperiment;
        public Risk(int n, int m)
        {
            matrix = new double[n, m];
            riskValues = null;
            stateOfNature = null;
            maxExperiment = 0;
        }
        public Risk(double[,] matrix)
        {
            this.matrix = matrix;
            this.riskValues = new double[matrix.GetLength(0)];
        }
        //Adding state of natures
        public bool addStateOfNature(double[] stateOfNature) 
        {
            if (stateOfNature.Length != matrix.GetLength(1))
                return false;
            double sum = 0;
            foreach (double state in stateOfNature)
            {
                sum += state; 
            }
            if ((int)sum == 1)
            {
                this.stateOfNature = stateOfNature;
                return true;
            }
            else
                return false;
        }
        //Finding max experiment price
        public void findMaxExperimentPrice()
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                riskValues[i] = 0;
                //Multipling each cell element on current state of nature
                //To find risk values of current row
                for (int j = 0; j < m; j++)
                {
                    riskValues[i] += matrix[i, j] * stateOfNature[j];
                }
            }
            //Finding maximum value of all risks
            maxExperiment = riskValues.Min();
        }

        //Printing result to txt document
        public void printToTxt()
        {
            string docPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = File.AppendText("Risks.txt"))
            {
                outputFile.WriteLine("Значения рисков:");
                for (int i = 0; i < riskValues.Length; i++)
                {
                    outputFile.Write(riskValues[i].ToString() + " ");
                }
                outputFile.WriteLine();
                outputFile.WriteLine("Значение максимального эксперимента: " + maxExperiment.ToString());
            }
        }
    }

    //Converter from playoff to risk matrix
    public class Converter
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
                double rowMax = playoff.findMaxValueInColumn(j);
                for (int i = 0; i < n; i++)
                {
                    riskMatrix[i, j] = rowMax - playoff.Matrix[i, j];
                }
            }
            Risk risk = new Risk(riskMatrix);
            return risk;
        }
    }
    /*
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
    */
}
