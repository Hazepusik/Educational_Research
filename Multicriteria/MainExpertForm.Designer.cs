namespace Multicriteria
{
    partial class frmMainExpert
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnExisting = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNew.Location = new System.Drawing.Point(93, 32);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(358, 45);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Создать новое голосование";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnExisting
            // 
            this.btnExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExisting.Location = new System.Drawing.Point(93, 104);
            this.btnExisting.Name = "btnExisting";
            this.btnExisting.Size = new System.Drawing.Size(358, 45);
            this.btnExisting.TabIndex = 9;
            this.btnExisting.Text = "Пройти существующее голосование";
            this.btnExisting.UseVisualStyleBackColor = true;
            this.btnExisting.Click += new System.EventHandler(this.btnExisting_Click);
            // 
            // btnResults
            // 
            this.btnResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResults.Location = new System.Drawing.Point(93, 175);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(358, 45);
            this.btnResults.TabIndex = 10;
            this.btnResults.Text = "Посчитать результаты голосования";
            this.btnResults.UseVisualStyleBackColor = true;
            // 
            // frmMainExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 269);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnExisting);
            this.Controls.Add(this.btnNew);
            this.Name = "frmMainExpert";
            this.Text = "Коллективный выбор";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExisting;
        private System.Windows.Forms.Button btnResults;

    }
}