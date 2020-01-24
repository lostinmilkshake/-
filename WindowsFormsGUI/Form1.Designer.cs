namespace WindowsFormsGUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Abox = new System.Windows.Forms.TextBox();
            this.Bbox = new System.Windows.Forms.TextBox();
            this.Cbox = new System.Windows.Forms.TextBox();
            this.Dbox = new System.Windows.Forms.TextBox();
            this.Ebox = new System.Windows.Forms.TextBox();
            this.Fbox = new System.Windows.Forms.TextBox();
            this.Gbox = new System.Windows.Forms.TextBox();
            this.Hbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Запустить симмуляцию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 181);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(253, 204);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Abox
            // 
            this.Abox.Location = new System.Drawing.Point(24, 22);
            this.Abox.Name = "Abox";
            this.Abox.Size = new System.Drawing.Size(29, 20);
            this.Abox.TabIndex = 5;
            this.Abox.Text = "1";
            // 
            // Bbox
            // 
            this.Bbox.Location = new System.Drawing.Point(59, 22);
            this.Bbox.Name = "Bbox";
            this.Bbox.Size = new System.Drawing.Size(33, 20);
            this.Bbox.TabIndex = 6;
            this.Bbox.Text = "2";
            // 
            // Cbox
            // 
            this.Cbox.Location = new System.Drawing.Point(23, 63);
            this.Cbox.Name = "Cbox";
            this.Cbox.Size = new System.Drawing.Size(30, 20);
            this.Cbox.TabIndex = 7;
            this.Cbox.Text = "1";
            // 
            // Dbox
            // 
            this.Dbox.Location = new System.Drawing.Point(59, 63);
            this.Dbox.Name = "Dbox";
            this.Dbox.Size = new System.Drawing.Size(34, 20);
            this.Dbox.TabIndex = 8;
            this.Dbox.Text = "3";
            // 
            // Ebox
            // 
            this.Ebox.Location = new System.Drawing.Point(22, 100);
            this.Ebox.Name = "Ebox";
            this.Ebox.Size = new System.Drawing.Size(31, 20);
            this.Ebox.TabIndex = 9;
            this.Ebox.Text = "4";
            // 
            // Fbox
            // 
            this.Fbox.Location = new System.Drawing.Point(59, 100);
            this.Fbox.Name = "Fbox";
            this.Fbox.Size = new System.Drawing.Size(33, 20);
            this.Fbox.TabIndex = 10;
            this.Fbox.Text = "6";
            // 
            // Gbox
            // 
            this.Gbox.Location = new System.Drawing.Point(22, 140);
            this.Gbox.Name = "Gbox";
            this.Gbox.Size = new System.Drawing.Size(31, 20);
            this.Gbox.TabIndex = 11;
            this.Gbox.Text = "6";
            // 
            // Hbox
            // 
            this.Hbox.Location = new System.Drawing.Point(59, 140);
            this.Hbox.Name = "Hbox";
            this.Hbox.Size = new System.Drawing.Size(33, 20);
            this.Hbox.TabIndex = 12;
            this.Hbox.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Введите границы  того, как часто прибывают корабли";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Введите границы того, как долго обслуживаются малые корабли";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Введите границы того, как долго обслуживаются средние корабли";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(351, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Введите границы того, как долго обслуживаются большие корабли";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hbox);
            this.Controls.Add(this.Gbox);
            this.Controls.Add(this.Fbox);
            this.Controls.Add(this.Ebox);
            this.Controls.Add(this.Dbox);
            this.Controls.Add(this.Cbox);
            this.Controls.Add(this.Bbox);
            this.Controls.Add(this.Abox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox Abox;
        private System.Windows.Forms.TextBox Bbox;
        private System.Windows.Forms.TextBox Cbox;
        private System.Windows.Forms.TextBox Dbox;
        private System.Windows.Forms.TextBox Ebox;
        private System.Windows.Forms.TextBox Fbox;
        private System.Windows.Forms.TextBox Gbox;
        private System.Windows.Forms.TextBox Hbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

