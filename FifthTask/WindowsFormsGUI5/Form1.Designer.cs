namespace WindowsFormsGUI5
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
            this.functionBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.valuesGrid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.outLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.aBox = new System.Windows.Forms.TextBox();
            this.bBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minimumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valuesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // functionBox
            // 
            this.functionBox.Location = new System.Drawing.Point(59, 45);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(336, 20);
            this.functionBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Считать функцию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите функцию";
            // 
            // valuesGrid
            // 
            this.valuesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.valuesGrid.Location = new System.Drawing.Point(59, 100);
            this.valuesGrid.Name = "valuesGrid";
            this.valuesGrid.Size = new System.Drawing.Size(359, 73);
            this.valuesGrid.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Найти значение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // outLabel
            // 
            this.outLabel.AutoSize = true;
            this.outLabel.Location = new System.Drawing.Point(190, 204);
            this.outLabel.Name = "outLabel";
            this.outLabel.Size = new System.Drawing.Size(116, 13);
            this.outLabel.TabIndex = 5;
            this.outLabel.Text = "Найденное значение ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(444, 178);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Найти минимум";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // aBox
            // 
            this.aBox.Location = new System.Drawing.Point(444, 152);
            this.aBox.Name = "aBox";
            this.aBox.Size = new System.Drawing.Size(21, 20);
            this.aBox.TabIndex = 7;
            // 
            // bBox
            // 
            this.bBox.Location = new System.Drawing.Point(471, 152);
            this.bBox.Name = "bBox";
            this.bBox.Size = new System.Drawing.Size(21, 20);
            this.bBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите границы поиска минимума";
            // 
            // minimumLabel
            // 
            this.minimumLabel.AutoSize = true;
            this.minimumLabel.Location = new System.Drawing.Point(441, 215);
            this.minimumLabel.Name = "minimumLabel";
            this.minimumLabel.Size = new System.Drawing.Size(104, 13);
            this.minimumLabel.TabIndex = 10;
            this.minimumLabel.Text = "Минимум функции:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 237);
            this.Controls.Add(this.minimumLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bBox);
            this.Controls.Add(this.aBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.outLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.valuesGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.functionBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.valuesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox functionBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView valuesGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label outLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox aBox;
        private System.Windows.Forms.TextBox bBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minimumLabel;
    }
}

