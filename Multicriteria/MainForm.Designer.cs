namespace Multicriteria
{
    partial class frmMain
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
            Logger.Finish();
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExport.Location = new System.Drawing.Point(23, 202);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(268, 81);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Создать новую матрицу оценок";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnImport.Location = new System.Drawing.Point(327, 202);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(268, 81);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Загрузить существующую матрицу оценок";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.Import_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(72, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(498, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Решение многокритериальнных задач";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(135, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Что вы желаете сделать?";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 326);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Name = "frmMain";
            this.Text = "              Multicriteria";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

