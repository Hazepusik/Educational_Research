namespace Multicriteria
{
    partial class frmGraph
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
            this.btnYQ = new System.Windows.Forms.Button();
            this.ybox = new System.Windows.Forms.ComboBox();
            this.qbox = new System.Windows.Forms.ComboBox();
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
            // btnYQ
            // 
            this.btnYQ.Location = new System.Drawing.Point(25, 133);
            this.btnYQ.Name = "btnYQ";
            this.btnYQ.Size = new System.Drawing.Size(237, 46);
            this.btnYQ.TabIndex = 7;
            this.btnYQ.Text = "Показать граф";
            this.btnYQ.UseVisualStyleBackColor = true;
            this.btnYQ.Click += new System.EventHandler(this.btnYQ_Click);
            // 
            // ybox
            // 
            this.ybox.FormattingEnabled = true;
            this.ybox.Location = new System.Drawing.Point(143, 42);
            this.ybox.Name = "ybox";
            this.ybox.Size = new System.Drawing.Size(121, 21);
            this.ybox.TabIndex = 8;
            // 
            // qbox
            // 
            this.qbox.FormattingEnabled = true;
            this.qbox.Location = new System.Drawing.Point(143, 84);
            this.qbox.Name = "qbox";
            this.qbox.Size = new System.Drawing.Size(121, 21);
            this.qbox.TabIndex = 9;
            // 
            // frmGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.qbox);
            this.Controls.Add(this.ybox);
            this.Controls.Add(this.btnYQ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGraph";
            this.Text = "frmValuesYQ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYQ;
        private System.Windows.Forms.ComboBox ybox;
        private System.Windows.Forms.ComboBox qbox;
    }
}