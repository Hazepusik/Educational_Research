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
            this.lblY = new System.Windows.Forms.Label();
            this.lblQ = new System.Windows.Forms.Label();
            this.lblCD = new System.Windows.Forms.Label();
            this.btnYQ = new System.Windows.Forms.Button();
            this.ybox = new System.Windows.Forms.ComboBox();
            this.qbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(16, 60);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(263, 24);
            this.lblY.TabIndex = 2;
            this.lblY.Text = "Уровень согласия не менее";
            // 
            // lblQ
            // 
            this.lblQ.AutoSize = true;
            this.lblQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQ.Location = new System.Drawing.Point(16, 101);
            this.lblQ.Name = "lblQ";
            this.lblQ.Size = new System.Drawing.Size(282, 24);
            this.lblQ.TabIndex = 3;
            this.lblQ.Text = "Уровень несогласия не более";
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCD.Location = new System.Drawing.Point(22, 9);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(366, 24);
            this.lblCD.TabIndex = 4;
            this.lblCD.Text = "Задайте уровни согласия и несогласия";
            // 
            // btnYQ
            // 
            this.btnYQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnYQ.Location = new System.Drawing.Point(90, 156);
            this.btnYQ.Name = "btnYQ";
            this.btnYQ.Size = new System.Drawing.Size(239, 58);
            this.btnYQ.TabIndex = 7;
            this.btnYQ.Text = "Показать граф";
            this.btnYQ.UseVisualStyleBackColor = true;
            this.btnYQ.Click += new System.EventHandler(this.btnYQ_Click);
            // 
            // ybox
            // 
            this.ybox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ybox.FormattingEnabled = true;
            this.ybox.Location = new System.Drawing.Point(306, 60);
            this.ybox.Name = "ybox";
            this.ybox.Size = new System.Drawing.Size(116, 32);
            this.ybox.TabIndex = 8;
            // 
            // qbox
            // 
            this.qbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qbox.FormattingEnabled = true;
            this.qbox.Location = new System.Drawing.Point(306, 98);
            this.qbox.Name = "qbox";
            this.qbox.Size = new System.Drawing.Size(116, 32);
            this.qbox.TabIndex = 9;
            // 
            // frmGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 242);
            this.Controls.Add(this.qbox);
            this.Controls.Add(this.ybox);
            this.Controls.Add(this.btnYQ);
            this.Controls.Add(this.lblCD);
            this.Controls.Add(this.lblQ);
            this.Controls.Add(this.lblY);
            this.Name = "frmGraph";
            this.Text = "Графическая интерпретация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblCD;
        private System.Windows.Forms.Button btnYQ;
        private System.Windows.Forms.ComboBox ybox;
        private System.Windows.Forms.ComboBox qbox;
    }
}