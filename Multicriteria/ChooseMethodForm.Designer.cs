namespace Multicriteria
{
    partial class frmChoose
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
            this.btnSuperiority = new System.Windows.Forms.Button();
            this.btnElectre = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSuperiority
            // 
            this.btnSuperiority.Location = new System.Drawing.Point(47, 37);
            this.btnSuperiority.Name = "btnSuperiority";
            this.btnSuperiority.Size = new System.Drawing.Size(166, 42);
            this.btnSuperiority.TabIndex = 0;
            this.btnSuperiority.Text = "Отношение превосходства";
            this.btnSuperiority.UseVisualStyleBackColor = true;
            this.btnSuperiority.Click += new System.EventHandler(this.btnSuperiority_Click);
            // 
            // btnElectre
            // 
            this.btnElectre.Location = new System.Drawing.Point(52, 106);
            this.btnElectre.Name = "btnElectre";
            this.btnElectre.Size = new System.Drawing.Size(161, 41);
            this.btnElectre.TabIndex = 1;
            this.btnElectre.Text = "ELECTRE";
            this.btnElectre.UseVisualStyleBackColor = true;
            this.btnElectre.Click += new System.EventHandler(this.btnElectre_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(52, 179);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(161, 41);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "Всеми";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // frmChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnElectre);
            this.Controls.Add(this.btnSuperiority);
            this.Name = "frmChoose";
            this.Text = "ChooseMethod";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSuperiority;
        private System.Windows.Forms.Button btnElectre;
        private System.Windows.Forms.Button btnAll;
    }
}