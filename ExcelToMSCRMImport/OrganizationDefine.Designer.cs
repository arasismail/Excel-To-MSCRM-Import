namespace ExcelToMSCRMImport
{
    partial class OrganizationDefine
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UpdateConnection_btn = new System.Windows.Forms.Button();
            this.SystemName_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Save_Chk = new System.Windows.Forms.CheckBox();
            this.Connection_btn = new System.Windows.Forms.Button();
            this.OrgUrl_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.UserName_txt = new System.Windows.Forms.TextBox();
            this.connectionList_cbx = new System.Windows.Forms.ComboBox();
            this.listConnection_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(11, 11);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.UpdateConnection_btn);
            this.splitContainer1.Panel1.Controls.Add(this.SystemName_txt);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.Save_Chk);
            this.splitContainer1.Panel1.Controls.Add(this.Connection_btn);
            this.splitContainer1.Panel1.Controls.Add(this.OrgUrl_txt);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Password_txt);
            this.splitContainer1.Panel1.Controls.Add(this.UserName_txt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel2.Controls.Add(this.connectionList_cbx);
            this.splitContainer1.Panel2.Controls.Add(this.listConnection_btn);
            this.splitContainer1.Size = new System.Drawing.Size(663, 242);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 16;
            // 
            // UpdateConnection_btn
            // 
            this.UpdateConnection_btn.Location = new System.Drawing.Point(291, 186);
            this.UpdateConnection_btn.Margin = new System.Windows.Forms.Padding(2);
            this.UpdateConnection_btn.Name = "UpdateConnection_btn";
            this.UpdateConnection_btn.Size = new System.Drawing.Size(148, 29);
            this.UpdateConnection_btn.TabIndex = 2;
            this.UpdateConnection_btn.Text = "Düzenle ve Bağlan";
            this.UpdateConnection_btn.UseVisualStyleBackColor = true;
            this.UpdateConnection_btn.Click += new System.EventHandler(this.UpdateConnection_btn_Click);
            // 
            // SystemName_txt
            // 
            this.SystemName_txt.Location = new System.Drawing.Point(126, 133);
            this.SystemName_txt.Margin = new System.Windows.Forms.Padding(2);
            this.SystemName_txt.Name = "SystemName_txt";
            this.SystemName_txt.Size = new System.Drawing.Size(314, 20);
            this.SystemName_txt.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Kayıt Adı";
            // 
            // Save_Chk
            // 
            this.Save_Chk.AutoSize = true;
            this.Save_Chk.Location = new System.Drawing.Point(16, 186);
            this.Save_Chk.Margin = new System.Windows.Forms.Padding(2);
            this.Save_Chk.Name = "Save_Chk";
            this.Save_Chk.Size = new System.Drawing.Size(99, 17);
            this.Save_Chk.TabIndex = 21;
            this.Save_Chk.Text = "Kaydedilsin Mi?";
            this.Save_Chk.UseVisualStyleBackColor = true;
            // 
            // Connection_btn
            // 
            this.Connection_btn.Location = new System.Drawing.Point(126, 186);
            this.Connection_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Connection_btn.Name = "Connection_btn";
            this.Connection_btn.Size = new System.Drawing.Size(147, 29);
            this.Connection_btn.TabIndex = 20;
            this.Connection_btn.Text = "Bağlan";
            this.Connection_btn.UseVisualStyleBackColor = true;
            this.Connection_btn.Click += new System.EventHandler(this.Connection_btn_Click);
            // 
            // OrgUrl_txt
            // 
            this.OrgUrl_txt.Location = new System.Drawing.Point(126, 93);
            this.OrgUrl_txt.Margin = new System.Windows.Forms.Padding(2);
            this.OrgUrl_txt.Name = "OrgUrl_txt";
            this.OrgUrl_txt.Size = new System.Drawing.Size(314, 20);
            this.OrgUrl_txt.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Organizayon Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Şifre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // Password_txt
            // 
            this.Password_txt.Location = new System.Drawing.Point(126, 54);
            this.Password_txt.Margin = new System.Windows.Forms.Padding(2);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(314, 20);
            this.Password_txt.TabIndex = 15;
            // 
            // UserName_txt
            // 
            this.UserName_txt.Location = new System.Drawing.Point(126, 20);
            this.UserName_txt.Margin = new System.Windows.Forms.Padding(2);
            this.UserName_txt.Name = "UserName_txt";
            this.UserName_txt.Size = new System.Drawing.Size(314, 20);
            this.UserName_txt.TabIndex = 14;
            // 
            // connectionList_cbx
            // 
            this.connectionList_cbx.FormattingEnabled = true;
            this.connectionList_cbx.Location = new System.Drawing.Point(14, 16);
            this.connectionList_cbx.Margin = new System.Windows.Forms.Padding(2);
            this.connectionList_cbx.Name = "connectionList_cbx";
            this.connectionList_cbx.Size = new System.Drawing.Size(180, 21);
            this.connectionList_cbx.TabIndex = 1;
            this.connectionList_cbx.SelectedValueChanged += new System.EventHandler(this.connectionList_cbx_SelectedValueChanged);
            // 
            // listConnection_btn
            // 
            this.listConnection_btn.Location = new System.Drawing.Point(14, 186);
            this.listConnection_btn.Margin = new System.Windows.Forms.Padding(2);
            this.listConnection_btn.Name = "listConnection_btn";
            this.listConnection_btn.Size = new System.Drawing.Size(178, 29);
            this.listConnection_btn.TabIndex = 0;
            this.listConnection_btn.Text = "Bağlan";
            this.listConnection_btn.UseVisualStyleBackColor = true;
            this.listConnection_btn.Click += new System.EventHandler(this.listConnection_btn_Click);
            // 
            // OrganizationDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 270);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OrganizationDefine";
            this.Text = "OrganizationDefine";
            this.Load += new System.EventHandler(this.OrganizationDefine_frm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button UpdateConnection_btn;
        private System.Windows.Forms.TextBox SystemName_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Save_Chk;
        private System.Windows.Forms.Button Connection_btn;
        private System.Windows.Forms.TextBox OrgUrl_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.TextBox UserName_txt;
        private System.Windows.Forms.ComboBox connectionList_cbx;
        private System.Windows.Forms.Button listConnection_btn;
    }
}