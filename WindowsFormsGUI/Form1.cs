using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourthTask;

namespace WindowsFormsGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            WFHarbor wFHarbor = new WFHarbor(richTextBox1);
            richTextBox1.ScrollToCaret();
            int A, B, C, D, E, F, G, H;
            //Reading all input values
            try
            {
                A = int.Parse(Abox.Text);
                B = int.Parse(Bbox.Text);
                C = int.Parse(Cbox.Text);
                D = int.Parse(Dbox.Text);
                E = int.Parse(Ebox.Text);
                F = int.Parse(Fbox.Text);
                G = int.Parse(Gbox.Text);
                H = int.Parse(Hbox.Text);
                if (A >= E || E >= G)
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка, неверно введены границы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            wFHarbor.Simulate(A, B, C, D, E, F, G, H);
        }
    }

    //Same class as harbor, but with functional
    // to work with RichTexBox
    class WFHarbor: Harbor
    {

        RichTextBox RichTextBox1;

        public WFHarbor(RichTextBox richTextBox1) 
        {

            this.RichTextBox1 = richTextBox1;
        }
        //Displaying all message in txt
        public override void DisplayAllMessage(string message)
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile =
                File.AppendText("simulation.txt"))
            {
                outputFile.WriteLine(message);
            }

        }
        //Displaying queue message in txt
        public override void DisplayQueueMessage(string message)
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile =
                File.AppendText("simulation.txt"))
            {
                outputFile.WriteLine(message);
            }

        }
        //Displaying current statistics in first rich box
        public override void DisplayCurrentStatMessage(string message)
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile =
                File.AppendText("simulationAllStats.txt"))
            {
                outputFile.WriteLine(message);
            }
            /*RichTextBox1.Text += $"{message}\n";
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length;
            RichTextBox1.ScrollToCaret();*/
        }
        //Displaying all statistics in second rich box
        public override void DisplayStatMessage(string message)
        {

            RichTextBox1.Text += $"{message}\n";
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length;
            RichTextBox1.ScrollToCaret();
        }
    }
}
