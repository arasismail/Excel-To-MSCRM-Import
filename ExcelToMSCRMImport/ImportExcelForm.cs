using ExcelDataReader;
using ExcelToMSCRMImport.Library;
using Namespace.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelToMSCRMImport
{
    public partial class ImportExcelForm : Form
    {
        MapHelper mapHelper = new MapHelper();
        MSCRMHelper mSCRMHelper = new MSCRMHelper();
        public ImportExcelForm()
        {
            InitializeComponent();
        }


        DataTableCollection tableCollection;
        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            

            ExcelObject newexcelObject = new ExcelObject();
            
            foreach (DataGridViewRow account in dataGridView1.Rows)
            {
                
                newexcelObject.AccountName = account.Cells["AccountName"].Value.ToString();
                newexcelObject.Telephone1 = account.Cells["Telephone1"].Value.ToString();
                newexcelObject.Telephone2 = account.Cells["Telephone2"].Value.ToString();
                newexcelObject.EmailAddress1 = account.Cells["EmailAddress1"].Value.ToString();
                newexcelObject.EmailAddress2 = account.Cells["EmailAddress2"].Value.ToString();
                
                var entity = mapHelper.ObjectConvertoEntity(newexcelObject);
                mSCRMHelper.CreateEntityRecord(entity);
            }
            
        }

        //Form üzerinde FileUploader ile masaüstündeki dosya alıancaktır.
        //Alınan dosyadaki alanlar okunacak.
        //Okunan alanlar ExcelObject objesine map edilecektir
        //Map edilen obje, MapHelper içerisindeki ObjectConvertoEntity metot ile Entity'e çevirilektir.
        //MSCRMHelper içerisindeki CreateEntityRecord metodu ile MS CRM sistemine alınacaktır.
    }
}
