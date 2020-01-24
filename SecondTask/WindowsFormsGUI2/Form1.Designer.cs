namespace WindowsFormsGUI2
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
            this.findMaxButton = new System.Windows.Forms.Button();
            this.winMatrixView = new System.Windows.Forms.DataGridView();
            this.riskMatrixView = new System.Windows.Forms.DataGridView();
            this.sizeBox1 = new System.Windows.Forms.TextBox();
            this.sizeBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.createMatrix = new System.Windows.Forms.Button();
            this.maxExp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.winMatrixView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riskMatrixView)).BeginInit();
            this.SuspendLayout();
            // 
            // findMaxButton
            // 
            this.findMaxButton.Location = new System.Drawing.Point(68, 365);
            this.findMaxButton.Name = "findMaxButton";
            this.findMaxButton.Size = new System.Drawing.Size(230, 23);
            this.findMaxButton.TabIndex = 0;
            this.findMaxButton.Text = "Найти максимальную цену эксперимента";
            this.findMaxButton.UseVisualStyleBackColor = true;
            this.findMaxButton.Click += new System.EventHandler(this.findMaxButton_Click);
            // 
            // winMatrixView
            // 
            this.winMatrixView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.winMatrixView.Location = new System.Drawing.Point(68, 108);
            this.winMatrixView.Name = "winMatrixView";
            this.winMatrixView.Size = new System.Drawing.Size(330, 244);
            this.winMatrixView.TabIndex = 1;
            // 
            // riskMatrixView
            // 
            this.riskMatrixView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.riskMatrixView.Location = new System.Drawing.Point(475, 62);
            this.riskMatrixView.Name = "riskMatrixView";
            this.riskMatrixView.Size = new System.Drawing.Size(289, 222);
            this.riskMatrixView.TabIndex = 2;
            // 
            // sizeBox1
            // 
            this.sizeBox1.Location = new System.Drawing.Point(68, 53);
            this.sizeBox1.Name = "sizeBox1";
            this.sizeBox1.Size = new System.Drawing.Size(100, 20);
            this.sizeBox1.TabIndex = 4;
            // 
            // sizeBox2
            // 
            this.sizeBox2.Location = new System.Drawing.Point(198, 53);
            this.sizeBox2.Name = "sizeBox2";
            this.sizeBox2.Size = new System.Drawing.Size(100, 20);
            this.sizeBox2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите размер матрицы выигрышей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество строк";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество столбцов";
            // 
            // createMatrix
            // 
            this.createMatrix.Location = new System.Drawing.Point(68, 79);
            this.createMatrix.Name = "createMatrix";
            this.createMatrix.Size = new System.Drawing.Size(118, 23);
            this.createMatrix.TabIndex = 9;
            this.createMatrix.Text = "Создать матрицу";
            this.createMatrix.UseVisualStyleBackColor = true;
            this.createMatrix.Click += new System.EventHandler(this.createMatrix_Click);
            // 
            // maxExp
            // 
            this.maxExp.AutoSize = true;
            this.maxExp.Location = new System.Drawing.Point(475, 338);
            this.maxExp.Name = "maxExp";
            this.maxExp.Size = new System.Drawing.Size(187, 13);
            this.maxExp.TabIndex = 10;
            this.maxExp.Text = "Максимальная цена эксперимента";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.maxExp);
            this.Controls.Add(this.createMatrix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeBox2);
            this.Controls.Add(this.sizeBox1);
            this.Controls.Add(this.riskMatrixView);
            this.Controls.Add(this.winMatrixView);
            this.Controls.Add(this.findMaxButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.winMatrixView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riskMatrixView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findMaxButton;
        private System.Windows.Forms.DataGridView winMatrixView;
        private System.Windows.Forms.DataGridView riskMatrixView;
        private System.Windows.Forms.TextBox sizeBox1;
        private System.Windows.Forms.TextBox sizeBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createMatrix;
        private System.Windows.Forms.Label maxExp;
    }
}

