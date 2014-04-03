namespace Multicriteria
{
    partial class frmFill
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
            this.btnCrit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCritCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCrit
            // 
            this.btnCrit.Location = new System.Drawing.Point(183, 28);
            this.btnCrit.Name = "btnCrit";
            this.btnCrit.Size = new System.Drawing.Size(75, 23);
            this.btnCrit.TabIndex = 0;
            this.btnCrit.Text = "Запомнить";
            this.btnCrit.UseVisualStyleBackColor = true;
            this.btnCrit.UseWaitCursor = true;
            this.btnCrit.Click += new System.EventHandler(this.btnCrit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.UseWaitCursor = true;
            // 
            // txtCritCount
            // 
            this.txtCritCount.Location = new System.Drawing.Point(77, 28);
            this.txtCritCount.Name = "txtCritCount";
            this.txtCritCount.Size = new System.Drawing.Size(100, 20);
            this.txtCritCount.TabIndex = 2;
            this.txtCritCount.UseWaitCursor = true;
            this.txtCritCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCritCount_KeyPress);
            // 
            // frmFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 268);
            this.Controls.Add(this.txtCritCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrit);
            this.Name = "frmFill";
            this.Text = "Стартовое заполнение";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCritCount;
    }
}