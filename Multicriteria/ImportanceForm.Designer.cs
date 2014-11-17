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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUsing = new System.Windows.Forms.Button();
            this.clbUsing = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPR = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(97, 189);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(163, 24);
            this.lblY.TabIndex = 9;
            this.lblY.Text = "Идеальная точка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(97, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Линейная свертка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(97, 113);
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
            this.cbSP.Location = new System.Drawing.Point(390, 75);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(116, 32);
            this.cbSP.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(97, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Отношения превосходства";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(205, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Важность методов";
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
            this.cbEL.Location = new System.Drawing.Point(390, 113);
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
            this.cbCV.Location = new System.Drawing.Point(390, 151);
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
            this.cbIP.Location = new System.Drawing.Point(390, 189);
            this.cbIP.Name = "cbIP";
            this.cbIP.Size = new System.Drawing.Size(116, 32);
            this.cbIP.TabIndex = 20;
            // 
            // btnSaveImportance
            // 
            this.btnSaveImportance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveImportance.Location = new System.Drawing.Point(120, 294);
            this.btnSaveImportance.Name = "btnSaveImportance";
            this.btnSaveImportance.Size = new System.Drawing.Size(367, 54);
            this.btnSaveImportance.TabIndex = 21;
            this.btnSaveImportance.Text = "Сохранить";
            this.btnSaveImportance.UseVisualStyleBackColor = true;
            this.btnSaveImportance.Click += new System.EventHandler(this.btnSaveImportance_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Location = new System.Drawing.Point(1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(651, 382);
            this.tabControl1.TabIndex = 22;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.cbPR);
            this.tab2.Controls.Add(this.label6);
            this.tab2.Controls.Add(this.btnSaveImportance);
            this.tab2.Controls.Add(this.cbIP);
            this.tab2.Controls.Add(this.label4);
            this.tab2.Controls.Add(this.cbCV);
            this.tab2.Controls.Add(this.lblY);
            this.tab2.Controls.Add(this.cbEL);
            this.tab2.Controls.Add(this.label1);
            this.tab2.Controls.Add(this.label2);
            this.tab2.Controls.Add(this.cbSP);
            this.tab2.Controls.Add(this.label3);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(643, 356);
            this.tab2.TabIndex = 0;
            this.tab2.Text = "Важность методов";
            this.tab2.UseVisualStyleBackColor = true;
            this.tab2.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.clbUsing);
            this.tab1.Controls.Add(this.btnUsing);
            this.tab1.Controls.Add(this.label5);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(643, 356);
            this.tab1.TabIndex = 1;
            this.tab1.Text = "Используемые методы";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(213, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 24);
            this.label5.TabIndex = 22;
            this.label5.Text = "Используемые методы";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnUsing
            // 
            this.btnUsing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUsing.Location = new System.Drawing.Point(187, 207);
            this.btnUsing.Name = "btnUsing";
            this.btnUsing.Size = new System.Drawing.Size(294, 46);
            this.btnUsing.TabIndex = 23;
            this.btnUsing.Text = "Сохранить";
            this.btnUsing.UseVisualStyleBackColor = true;
            this.btnUsing.Click += new System.EventHandler(this.btnUsing_Click);
            // 
            // clbUsing
            // 
            this.clbUsing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clbUsing.FormattingEnabled = true;
            this.clbUsing.Items.AddRange(new object[] {
            "Отношения превосходства",
            "ELECTRE",
            "Линейная свертка",
            "Идеальная точка",
            "PROMETHEE"});
            this.clbUsing.Location = new System.Drawing.Point(187, 57);
            this.clbUsing.Name = "clbUsing";
            this.clbUsing.Size = new System.Drawing.Size(294, 124);
            this.clbUsing.TabIndex = 24;
            this.clbUsing.SelectedIndexChanged += new System.EventHandler(this.clbUsing_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(97, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 24);
            this.label6.TabIndex = 22;
            this.label6.Text = "PROMETHEE";
            // 
            // cbPR
            // 
            this.cbPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPR.FormattingEnabled = true;
            this.cbPR.Items.AddRange(new object[] {
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
            this.cbPR.Location = new System.Drawing.Point(390, 227);
            this.cbPR.Name = "cbPR";
            this.cbPR.Size = new System.Drawing.Size(116, 32);
            this.cbPR.TabIndex = 23;
            // 
            // frmImportance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 381);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmImportance";
            this.Text = "Настройка значимости методов";
            this.Load += new System.EventHandler(this.frmImportance_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox clbUsing;
        private System.Windows.Forms.Button btnUsing;
        private System.Windows.Forms.ComboBox cbPR;
        private System.Windows.Forms.Label label6;
    }
}