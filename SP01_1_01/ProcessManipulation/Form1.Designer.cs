
namespace ProcessManipulation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartedAssemblies = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AvailableAssemblies = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.RunCalc = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 450);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartedAssemblies);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(262, 430);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запущенные процессы";
            // 
            // StartedAssemblies
            // 
            this.StartedAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartedAssemblies.FormattingEnabled = true;
            this.StartedAssemblies.Location = new System.Drawing.Point(5, 18);
            this.StartedAssemblies.Name = "StartedAssemblies";
            this.StartedAssemblies.Size = new System.Drawing.Size(252, 407);
            this.StartedAssemblies.TabIndex = 0;
            this.StartedAssemblies.SelectedIndexChanged += new System.EventHandler(this.StartedAssemblies_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AvailableAssemblies);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(402, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(262, 430);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Доступные сборки";
            // 
            // AvailableAssemblies
            // 
            this.AvailableAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvailableAssemblies.FormattingEnabled = true;
            this.AvailableAssemblies.Location = new System.Drawing.Point(5, 18);
            this.AvailableAssemblies.Name = "AvailableAssemblies";
            this.AvailableAssemblies.Size = new System.Drawing.Size(252, 407);
            this.AvailableAssemblies.TabIndex = 0;
            this.AvailableAssemblies.SelectedIndexChanged += new System.EventHandler(this.AvailableAssemblies_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.RunCalc);
            this.panel1.Controls.Add(this.StopButton);
            this.panel1.Controls.Add(this.RefreshButton);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(285, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 444);
            this.panel1.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(4, 80);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(97, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RunCalc
            // 
            this.RunCalc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RunCalc.Location = new System.Drawing.Point(4, 216);
            this.RunCalc.Name = "RunCalc";
            this.RunCalc.Size = new System.Drawing.Size(97, 23);
            this.RunCalc.TabIndex = 6;
            this.RunCalc.Text = "Run Calc";
            this.RunCalc.UseVisualStyleBackColor = true;
            this.RunCalc.Click += new System.EventHandler(this.RunCalc_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(4, 114);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(97, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point(4, 182);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(97, 23);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CloseButton.Enabled = false;
            this.CloseButton.Location = new System.Drawing.Point(4, 148);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(97, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close Window";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseWindowButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(690, 400);
            this.Name = "Form1";
            this.Text = "Управление дочерними процессами";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox StartedAssemblies;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox AvailableAssemblies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button RunCalc;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button CloseButton;
    }
}

