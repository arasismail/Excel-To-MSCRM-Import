namespace ExcelToMSCRMImport
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Start_btn = new System.Windows.Forms.Button();
            this.main_rTxt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(427, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 78);
            this.panel1.TabIndex = 7;
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(426, 47);
            this.Start_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(281, 36);
            this.Start_btn.TabIndex = 5;
            this.Start_btn.Text = "Programa Geçiş";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // main_rTxt
            // 
            this.main_rTxt.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_rTxt.Location = new System.Drawing.Point(7, 47);
            this.main_rTxt.Margin = new System.Windows.Forms.Padding(2);
            this.main_rTxt.Name = "main_rTxt";
            this.main_rTxt.ReadOnly = true;
            this.main_rTxt.Size = new System.Drawing.Size(416, 160);
            this.main_rTxt.TabIndex = 8;
            this.main_rTxt.Text = " \n\t\tExcel Dosyası Üzerinde Konumlandırılan \n\t             Kayıtları MS CRM Sistem" +
    "ine Alınması Sağlar.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 229);
            this.Controls.Add(this.main_rTxt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Start_btn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.RichTextBox main_rTxt;
    }
}

