using ExcelToMSCRMImport.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToMSCRMImport
{
    public partial class OrganizationDefine : Form
    {
        public OrganizationDefine()
        {
            InitializeComponent();
        }

        private ConnectionXmlHelper connectionXmlHelper = new ConnectionXmlHelper();
        private MSCRMHelper crmHelper = new MSCRMHelper();
        private ConnectionObject newConnectionObject = new ConnectionObject();
        private List<ConnectionObject> connectionObjectList = new List<ConnectionObject>();
        private ToolExcepiton toolException = new ToolExcepiton();
        private ComboboxItem comboBoxItem;
        private ComboboxItem updateComboBoxItem;

        private void OrganizationDefine_frm_Load(object sender, EventArgs e)
        {

            connectionObjectList=connectionXmlHelper.ReadConnection();
            foreach (ConnectionObject dnm in connectionObjectList) 
            {
                
                //connectionList_cbx.Items.Add(dnm.SystemName);
                //connectionList_cbx.SelectedIndex = 0;
            }
        }

        private void OrganizationDefine_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Connection_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            NewConnection();
            Cursor.Current = Cursors.Default;
        }

        private void listConnection_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            comboBoxItem = (ComboboxItem)connectionList_cbx.SelectedItem;
            ListConnection();
            Cursor.Current = Cursors.Default;
        }

        private void UpdateConnection_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateAndConnection();
            Cursor.Current = Cursors.Default;
        }

        private void connectionList_cbx_SelectedValueChanged(object sender, EventArgs e)
        {
            updateComboBoxItem = (ComboboxItem)connectionList_cbx.SelectedItem;
            ConnectionObject selectedConnectionObject = connectionObjectList.Where<ConnectionObject>(x => x.ConnectionId == Convert.ToString(updateComboBoxItem.Value)).FirstOrDefault();
            SystemName_txt.Text = selectedConnectionObject.SystemName;
            OrgUrl_txt.Text = selectedConnectionObject.URL;
            UserName_txt.Text = selectedConnectionObject.UserName;
            if (!UpdateConnection_btn.Visible || !UpdateConnection_btn.Enabled)
            {
                UpdateConnection_btn.Visible = true;
                UpdateConnection_btn.Enabled = true;
            }

            if (!listConnection_btn.Enabled)
            {
                listConnection_btn.Enabled = true;
            }
        }



        private void ListConnection()
        {
            ConnectionObject selectedConnectionObject = connectionObjectList.Where<ConnectionObject>(x => x.ConnectionId == Convert.ToString(comboBoxItem.Value)).FirstOrDefault();

            Result result = crmHelper.ControlMSCRMConnection(selectedConnectionObject);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
            }
            else
            {

            }
        }

        private void ControlAndFillConnectionObject()
        {
            string systemName = SystemName_txt.Text;
            string url = OrgUrl_txt.Text;
            string userName = UserName_txt.Text;
            string password = Password_txt.Text;

            Result result = new Result();

            if (string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(url))
            {
                toolException.CustomMessage = "Alanlar Doldurulmalıdır";
                throw toolException;
            }

            newConnectionObject.SystemName = systemName;
            newConnectionObject.URL = url;
            newConnectionObject.UserName = userName;
            newConnectionObject.Password = password;
        }

        private void NewConnection()
        {
            bool isSave = Save_Chk.Checked;
            try
            {
                ControlAndFillConnectionObject();

                Result result = crmHelper.ControlMSCRMConnection(newConnectionObject);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    if (isSave)
                    {
                        if (string.IsNullOrWhiteSpace(SystemName_txt.Text))
                        {
                            toolException.CustomMessage = "Kayıt Yapabilmek İçin Kayıt Adı Alanı Doldurulması Zorunludur.";
                            throw toolException;
                        }

                        connectionXmlHelper.AddNewConnection(newConnectionObject);

                    }
                    ImportExcelForm importExcelForm = new ImportExcelForm();
                    importExcelForm.Show();
                    this.Visible = false;
                }
            }
            catch (ToolExcepiton ex)
            {
                MessageBox.Show(ex.CustomMessage);
            }
        }

        private class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void UpdateAndConnection()
        {
            try
            {
                ConnectionObject selectedConnectionObject = connectionObjectList.Where<ConnectionObject>(x => x.ConnectionId == Convert.ToString(updateComboBoxItem.Value)).FirstOrDefault();
                ControlAndFillConnectionObject();
                Result result = crmHelper.ControlMSCRMConnection(newConnectionObject);
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    newConnectionObject.ConnectionId = selectedConnectionObject.ConnectionId;
                    connectionXmlHelper.UpdateConnection(newConnectionObject);

                    ImportExcelForm importExcelForm = new ImportExcelForm();
                    importExcelForm.Show();
                    this.Visible = false;
                }
            }
            catch (ToolExcepiton ex)
            {
                MessageBox.Show(ex.CustomMessage);
            }
        }
    }
}
