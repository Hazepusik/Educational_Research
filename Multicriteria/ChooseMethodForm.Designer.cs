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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSuperiority
            // 
            this.btnSuperiority.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSuperiority.Location = new System.Drawing.Point(54, 88);
            this.btnSuperiority.Name = "btnSuperiority";
            this.btnSuperiority.Size = new System.Drawing.Size(372, 55);
            this.btnSuperiority.TabIndex = 0;
            this.btnSuperiority.Text = "Отношения превосходства";
            this.btnSuperiority.UseVisualStyleBackColor = true;
            this.btnSuperiority.Click += new System.EventHandler(this.btnSuperiority_Click);
            // 
            // btnElectre
            // 
            this.btnElectre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnElectre.Location = new System.Drawing.Point(59, 157);
            this.btnElectre.Name = "btnElectre";
            this.btnElectre.Size = new System.Drawing.Size(367, 54);
            this.btnElectre.TabIndex = 1;
            this.btnElectre.Text = "ELECTRE";
            this.btnElectre.UseVisualStyleBackColor = true;
            this.btnElectre.Click += new System.EventHandler(this.btnElectre_Click);
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAll.Location = new System.Drawing.Point(59, 230);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(367, 54);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "Комбинированный";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(71, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите метод решения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(432, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 301);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnElectre);
            this.Controls.Add(this.btnSuperiority);
            this.Name = "frmChoose";
            this.Text = "Выбор метода оценки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSuperiority;
        private System.Windows.Forms.Button btnElectre;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}