using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecondTask;

namespace WindowsFormsGUI2
{
    public partial class Form1 : Form
    {
        //Matrix to read from winMatrixView
        public double[,] enterMatrix { get; set; }
        //Array to read probability form winMatrixView
        public double[] enterArray { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void createMatrix_Click(object sender, EventArgs e)
        {
            int n, m;
            try
            {
                n = int.Parse(sizeBox1.Text.ToString());
                m = int.Parse(sizeBox2.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, неверно введён размер матрицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            winMatrixView.Columns.Clear();
            //Creating n*m win matirx
            for (int i = 0; i < m; i++)
            {
                winMatrixView.Columns.Add($"{i}", $"{i}");
            }
            for (int i = 0; i < n; i++)
            {
                winMatrixView.Rows.Add();
                winMatrixView.Rows[i].HeaderCell.Value = i.ToString();
            }
            //Adding Probability row
            winMatrixView.Rows.Add();
            winMatrixView.Rows[n].HeaderCell.Value = "Вероятности";
            winMatrixView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void findMaxButton_Click(object sender, EventArgs e)
        {
            int m = winMatrixView.Columns.Count;
            int n = winMatrixView.Rows.Count - 2;
            enterMatrix = new double[n, m];
            enterArray = new double[m];
            //Reading values from winMatrixView and adding them to enterMatrix
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    try
                    {
                        enterMatrix[j, i] = double.Parse(winMatrixView[i, j].Value.ToString());
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Ошибка, неверный составлена матрица выигрышей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            Playoff playoff = new Playoff(enterMatrix);
            //Reading the state of nature values
            for (int i = 0; i < m; i++)
            {
                try
                {
                    enterArray[i] = double.Parse(winMatrixView[i, n].Value.ToString());
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ошибка, неверный составлены вероятности", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            riskMatrixView.Columns.Clear();

            Risk risk = Converter.fromPlayoffToRisk(playoff);
            //Checking state of nature
            if(!risk.addStateOfNature(enterArray))
            {
                MessageBox.Show("Ошибка, неверный составлены вероятности", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Creating risk matrix n*m for riskMatrixView
            for (int i = 0; i < m; i++)
            {
                riskMatrixView.Columns.Add($"{i}", $"{i}");
            }
            for (int i = 0; i < n; i++)
            {
                riskMatrixView.Rows.Add();
                riskMatrixView.Rows[i].HeaderCell.Value = i.ToString();
            }
            //Adding risk matrix values to riskMatrixView
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    riskMatrixView[j, i].Value = risk.Matrix[i, j];
                    riskMatrixView[j, i].ReadOnly = true;
                }
            }
            riskMatrixView.Columns.Add($"", $"Risk");
            risk.findMaxExperimentPrice();
            //Displaying max experiment price
            maxExp.Text = "Максимальная цена эксперимента: " + risk.MaxExperiment.ToString();
            //Displaying risks values in riskMatirxView
            for (int i = 0; i < n;  i++)
            {
                riskMatrixView[m, i].Value = risk.RiskValues[i];
                riskMatrixView[m, i].ReadOnly = true;
            }
            riskMatrixView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            risk.printToTxt();
        }

        private void printToTxtButton_Click(object sender, EventArgs e)
        {
        }
    }
}
