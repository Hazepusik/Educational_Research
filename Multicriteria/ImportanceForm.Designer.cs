namespace Multicriteria
{
    partial class frmImportance
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
            this.lblY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEL = new System.Windows.Forms.ComboBox();
            this.cbCV = new System.Windows.Forms.ComboBox();
            this.cbIP = new System.Windows.Forms.ComboBox();
            this.btnSaveImportance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(35, 178);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(163, 24);
            this.lblY.TabIndex = 9;
            this.lblY.Text = "Идеальная точка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(35, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Линейная свертка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "ELECTRE";
            // 
            // cbSP
            // 
            this.cbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSP.FormattingEnabled = true;
            this.cbSP.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbSP.Location = new System.Drawing.Point(328, 51);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(116, 32);
            this.cbSP.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(35, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Отношения превосходства";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(143, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Значимость методов";
            // 
            // cbEL
            // 
            this.cbEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbEL.FormattingEnabled = true;
            this.cbEL.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbEL.Location = new System.Drawing.Point(328, 95);
            this.cbEL.Name = "cbEL";
            this.cbEL.Size = new System.Drawing.Size(116, 32);
            this.cbEL.TabIndex = 18;
            // 
            // cbCV
            // 
            this.cbCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCV.FormattingEnabled = true;
            this.cbCV.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbCV.Location = new System.Drawing.Point(328, 136);
            this.cbCV.Name = "cbCV";
            this.cbCV.Size = new System.Drawing.Size(116, 32);
            this.cbCV.TabIndex = 19;
            // 
            // cbIP
            // 
            this.cbIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIP.FormattingEnabled = true;
            this.cbIP.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbIP.Location = new System.Drawing.Point(328, 178);
            this.cbIP.Name = "cbIP";
            this.cbIP.Size = new System.Drawing.Size(116, 32);
            this.cbIP.TabIndex = 20;
            // 
            // btnSaveImportance
            // 
            this.btnSaveImportance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveImportance.Location = new System.Drawing.Point(55, 225);
            this.btnSaveImportance.Name = "btnSaveImportance";
            this.btnSaveImportance.Size = new System.Drawing.Size(367, 54);
            this.btnSaveImportance.TabIndex = 21;
            this.btnSaveImportance.Text = "Сохранить";
            this.btnSaveImportance.UseVisualStyleBackColor = true;
            this.btnSaveImportance.Click += new System.EventHandler(this.btnSaveImportance_Click);
            // 
            // frmImportance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 301);
            this.Controls.Add(this.btnSaveImportance);
            this.Controls.Add(this.cbIP);
            this.Controls.Add(this.cbCV);
            this.Controls.Add(this.cbEL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblY);
            this.Name = "frmImportance";
            this.Text = "Настройка значимости методов";
            this.Load += new System.EventHandler(this.frmImportance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEL;
        private System.Windows.Forms.ComboBox cbCV;
        private System.Windows.Forms.ComboBox cbIP;
        private System.Windows.Forms.Button btnSaveImportance;
    }
}