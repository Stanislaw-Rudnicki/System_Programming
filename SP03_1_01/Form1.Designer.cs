
namespace Sp03_1_01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonFile1 = new System.Windows.Forms.Button();
            this.buttonFile2 = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Откуда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Куда";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox2_PreviewKeyDown);
            // 
            // buttonFile1
            // 
            this.buttonFile1.Location = new System.Drawing.Point(381, 34);
            this.buttonFile1.Name = "buttonFile1";
            this.buttonFile1.Size = new System.Drawing.Size(75, 23);
            this.buttonFile1.TabIndex = 4;
            this.buttonFile1.Text = "Файл...";
            this.buttonFile1.UseVisualStyleBackColor = true;
            this.buttonFile1.Click += new System.EventHandler(this.buttonFile1_Click);
            // 
            // buttonFile2
            // 
            this.buttonFile2.Location = new System.Drawing.Point(381, 72);
            this.buttonFile2.Name = "buttonFile2";
            this.buttonFile2.Size = new System.Drawing.Size(75, 23);
            this.buttonFile2.TabIndex = 5;
            this.buttonFile2.Text = "Файл...";
            this.buttonFile2.UseVisualStyleBackColor = true;
            this.buttonFile2.Click += new System.EventHandler(this.buttonFile2_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(381, 111);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 6;
            this.buttonCopy.Text = "Копировать";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 111);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(321, 22);
            this.progressBar1.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 168);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonFile2);
            this.Controls.Add(this.buttonFile1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonFile1;
        private System.Windows.Forms.Button buttonFile2;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

