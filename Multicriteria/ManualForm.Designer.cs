namespace Multicriteria
{
    partial class frmManual
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
            this.lbModels = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSvExp = new System.Windows.Forms.Button();
            this.cbVote = new System.Windows.Forms.ComboBox();
            this.btnChose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbModels
            // 
            this.lbModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbModels.FormattingEnabled = true;
            this.lbModels.HorizontalScrollbar = true;
            this.lbModels.ItemHeight = 24;
            this.lbModels.Location = new System.Drawing.Point(12, 63);
            this.lbModels.Name = "lbModels";
            this.lbModels.Size = new System.Drawing.Size(322, 28);
            this.lbModels.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10.25F);
            this.button2.Location = new System.Drawing.Point(340, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "▲";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 10.25F);
            this.button3.Location = new System.Drawing.Point(340, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 33);
            this.button3.TabIndex = 6;
            this.button3.Text = "▼";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSvExp
            // 
            this.btnSvExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSvExp.Location = new System.Drawing.Point(409, 63);
            this.btnSvExp.Name = "btnSvExp";
            this.btnSvExp.Size = new System.Drawing.Size(225, 134);
            this.btnSvExp.TabIndex = 7;
            this.btnSvExp.Text = "Сохранить";
            this.btnSvExp.UseVisualStyleBackColor = true;
            this.btnSvExp.Click += new System.EventHandler(this.btnSvExp_Click);
            // 
            // cbVote
            // 
            this.cbVote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVote.FormattingEnabled = true;
            this.cbVote.Location = new System.Drawing.Point(12, 13);
            this.cbVote.Name = "cbVote";
            this.cbVote.Size = new System.Drawing.Size(322, 32);
            this.cbVote.TabIndex = 8;
            // 
            // btnChose
            // 
            this.btnChose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChose.Location = new System.Drawing.Point(12, 51);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(322, 52);
            this.btnChose.TabIndex = 9;
            this.btnChose.Text = "Выбрать голосование";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // frmManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(678, 275);
            this.Controls.Add(this.btnChose);
            this.Controls.Add(this.cbVote);
            this.Controls.Add(this.btnSvExp);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbModels);
            this.Name = "frmManual";
            this.Text = "Голосование";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbModels;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSvExp;
        private System.Windows.Forms.ComboBox cbVote;
        private System.Windows.Forms.Button btnChose;
    }
}