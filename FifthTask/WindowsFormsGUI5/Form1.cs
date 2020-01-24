using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FifthTask;

namespace WindowsFormsGUI5
{
    public partial class Form1 : Form
    {

        List<string> vs;
        string rpnFunction;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valuesGrid.Columns.Clear();
            //Reading new function
            try
            {
                rpnFunction = RPN.toRPN(functionBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, неверно записана формула", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Finding all variables in function
            vs = RPN.findAllX(rpnFunction);
            //Displaying grid for entering variables values
            if (vs.Count != 0)
            {
                foreach (string value in vs)
                {
                    valuesGrid.Columns.Add("", value);
                }
                valuesGrid.Rows.Add();
            }
            valuesGrid.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            double[] values = new double[valuesGrid.Columns.Count];

            //Reading all values for variables
            for (int i = 0; i < valuesGrid.Columns.Count; i++)
            {
                try { 
                    values[i] = double.Parse(valuesGrid[i, 0].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка, неверный записаны значения переменных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //Calculating result
            double result = RPN.CalculateRPN(rpnFunction, vs, values);
            //Displaying result
            outLabel.Text = "Найденное значение " + result.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a, b;
            //Reading new function
            try
            {
                rpnFunction = RPN.toRPN(functionBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, неверно записана формула", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vs = RPN.findAllX(rpnFunction);
            try
            {
                a = double.Parse(aBox.Text.ToString());
                b = double.Parse(bBox.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, неверно введены границы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double result;
            try
            {
                result = Bolzano.findMinimum(a, b, rpnFunction, vs);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\nПроизводные в начальной и конечной точке должны быть разных знаков", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            minimumLabel.Text = "Минимум функции: " + result.ToString();
        }
    }
}
