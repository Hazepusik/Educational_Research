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
            this.btnCount = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDiff = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(104, 25);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 20);
            this.btnCount.TabIndex = 0;
            this.btnCount.Text = "Заполнить";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.UseWaitCursor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(27, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Введите число критериев";
            this.lblTitle.UseWaitCursor = true;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(30, 25);
            this.txtCount.MaxLength = 3;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(68, 20);
            this.txtCount.TabIndex = 2;
            this.txtCount.UseWaitCursor = true;
            this.txtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название";
            this.lblName.UseWaitCursor = true;
            this.lblName.Visible = false;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(249, 62);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(57, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Важность";
            this.lblValue.UseWaitCursor = true;
            this.lblValue.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(252, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 20);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.UseWaitCursor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.Location = new System.Drawing.Point(377, 62);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(137, 13);
            this.lblDiff.TabIndex = 6;
            this.lblDiff.Text = "Макс. разность значений";
            // 
            // frmFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 268);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCount);
            this.Name = "frmFill";
            this.Text = "Стартовое заполнение";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmFill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDiff;
    }
}