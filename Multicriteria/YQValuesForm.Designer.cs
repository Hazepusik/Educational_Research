namespace Multicriteria
{
    partial class frmValuesYQ
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
            this.label3 = new System.Windows.Forms.Label();
            this.Yval = new System.Windows.Forms.NumericUpDown();
            this.Qval = new System.Windows.Forms.NumericUpDown();
            this.btnYQ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Yval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qval)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Уровень согласия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Уровень несогласия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Задайте уровни согласия и несогласия";
            // 
            // Yval
            // 
            this.Yval.DecimalPlaces = 2;
            this.Yval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Yval.Location = new System.Drawing.Point(143, 43);
            this.Yval.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Yval.Name = "Yval";
            this.Yval.Size = new System.Drawing.Size(120, 20);
            this.Yval.TabIndex = 5;
            // 
            // Qval
            // 
            this.Qval.DecimalPlaces = 2;
            this.Qval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Qval.Location = new System.Drawing.Point(143, 85);
            this.Qval.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Qval.Name = "Qval";
            this.Qval.Size = new System.Drawing.Size(120, 20);
            this.Qval.TabIndex = 6;
            // 
            // btnYQ
            // 
            this.btnYQ.Location = new System.Drawing.Point(25, 133);
            this.btnYQ.Name = "btnYQ";
            this.btnYQ.Size = new System.Drawing.Size(237, 46);
            this.btnYQ.TabIndex = 7;
            this.btnYQ.Text = "Задать";
            this.btnYQ.UseVisualStyleBackColor = true;
            this.btnYQ.Click += new System.EventHandler(this.btnYQ_Click);
            // 
            // frmValuesYQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnYQ);
            this.Controls.Add(this.Qval);
            this.Controls.Add(this.Yval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmValuesYQ";
            this.Text = "frmValuesYQ";
            ((System.ComponentModel.ISupportInitialize)(this.Yval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Yval;
        private System.Windows.Forms.NumericUpDown Qval;
        private System.Windows.Forms.Button btnYQ;
    }
}