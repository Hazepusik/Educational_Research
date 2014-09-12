namespace Multicriteria
{
    partial class ResultForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSc = new System.Windows.Forms.Label();
            this.lblPls = new System.Windows.Forms.Label();
            this.lblMod = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(290, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(266, 38);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть без сохранения";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSc
            // 
            this.lblSc.AutoSize = true;
            this.lblSc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSc.Location = new System.Drawing.Point(468, 22);
            this.lblSc.Name = "lblSc";
            this.lblSc.Size = new System.Drawing.Size(69, 24);
            this.lblSc.TabIndex = 4;
            this.lblSc.Text = "Штраф";
            // 
            // lblPls
            // 
            this.lblPls.AutoSize = true;
            this.lblPls.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPls.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPls.Location = new System.Drawing.Point(12, 22);
            this.lblPls.Name = "lblPls";
            this.lblPls.Size = new System.Drawing.Size(68, 24);
            this.lblPls.TabIndex = 5;
            this.lblPls.Text = "Место";
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMod.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMod.Location = new System.Drawing.Point(130, 22);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(81, 24);
            this.lblMod.TabIndex = 6;
            this.lblMod.Text = "Модель";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(12, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(266, 38);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить и закрыть";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 310);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMod);
            this.Controls.Add(this.lblPls);
            this.Controls.Add(this.lblSc);
            this.Controls.Add(this.btnClose);
            this.Name = "ResultForm";
            this.Text = "Результат";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSc;
        private System.Windows.Forms.Label lblPls;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.Button btnSave;
    }
}