using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThirdTask;

namespace WindowsFormsGUI
{
    public partial class Form1 : Form
    {
        //Matrix to read from matrixEnterView
        public int[,] enterMatrix { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            //Definig matrix size
            try
            {
                n = int.Parse(matrixSizeBox.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, неверно введён размер матрицы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Clearing current matrixEnterView
            matrixEnterView.Columns.Clear();
            //Creating n*n matrixEnterView
            for (int i = 0; i < n; i++)
            {
                matrixEnterView.Columns.Add("", "");
            }
            for (int i = 0; i < n; i++)
            {
                matrixEnterView.Rows.Add();
            }
            //Defing inaccessible matrix parts and coloring them in cadet blue
            for (int i = 0; i < n; i++)
            {
                matrixEnterView[i, i].Value = 0;
                matrixEnterView[i, i].ReadOnly = true;
                matrixEnterView[i, i].Style.BackColor = System.Drawing.Color.CadetBlue;
                matrixEnterView[0, i].Value = 0;
                matrixEnterView[0, i].ReadOnly = true;
                matrixEnterView[0, i].Style.BackColor = System.Drawing.Color.CadetBlue;
                matrixEnterView[i, n-1].Value = 0;
                matrixEnterView[i, n-1].ReadOnly = true;
                matrixEnterView[i, n-1].Style.BackColor = System.Drawing.Color.CadetBlue;
            }
            matrixEnterView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n;
            try
            {
                n = matrixEnterView.ColumnCount;
                if (n == 0)
                    throw new Exception();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ошибка, неверный составлена матрица смежности", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            enterMatrix = new int[n, n];
            //Reading values from matrixEnterView and adding them to enterMatrix
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    try
                    {
                        enterMatrix[j, i] = int.Parse(matrixEnterView[i, j].Value.ToString());
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show("Ошибка, неверный составлена матрица смежности", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            Graph testGraph = new Graph(enterMatrix);
            
            //Clearing current matrixOutView
            matrixOutView.Columns.Clear();
            //Creating matrixOutView as n*n matrix
            for (int i = 0; i < int.Parse(matrixSizeBox.Text.ToString()); i++)
            {
                matrixOutView.Columns.Add("", "");
            }
            for (int i = 0; i < int.Parse(matrixSizeBox.Text.ToString()); i++)
            {
                matrixOutView.Rows.Add();
            }
            //Finding max flow of current matrix
            label2.Text = "Максимальный поток: " + testGraph.findMaxFlow().ToString();
            //Displaying matrix of residual capacity
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixOutView[i, j].Value = testGraph.residualCapacity[j, i];
                    //Making all cells inaccessible
                    matrixOutView[i, j].ReadOnly = true;
                }
            }
            matrixOutView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
