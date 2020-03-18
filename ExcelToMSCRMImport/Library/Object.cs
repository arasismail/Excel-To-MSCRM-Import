using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToMSCRMImport.Library
{

    /// <summary>
    /// Dynamics MS CRM bağlantı Objesi
    /// </summary>
    public class ConnectionObject
    {
        public string SystemName { get; set; }
        public string ConnectionId { get; set; }
        public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    /// <summary>
    /// Sonuc Objesi
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }


    /// <summary>
    /// Hata Objesi
    /// </summary>
    public class ToolExcepiton : Exception
    {
        public string CustomMessage { get; set; }

        public ToolExcepiton()
        {
        }
    }
    
    /// <summary>
    /// Excel Veri Objesi
    /// Excelden gelen verileri bu objeye doldurabilirsiniz.
    /// </summary>
    public class ExcelObject
    {
        public string AccountName { get; set; }

        public string Telephone1 { get; set; }

        public string Telephone2 { get; set; }

        public string EmailAddress1 { get; set; }

        public string EmailAddress2 { get; set; }

    }
}
