using ExcelToMSCRMImport.Library;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace Namespace.Library
{
    /// <summary>
    /// MapHelper yardımı ile ExcelObject'i Dynamics MS CRM Account Varlığına (Objesine) çevirilecektir.
    /// </summary>
    public class MapHelper
    {
        
        public Entity ObjectConvertoEntity(ExcelObject excelobject)
        {
            Entity entity = new Entity("account");
            
            //entity["accountname"] = excelobject.AccountName;
            entity["emailaddress1"] = excelobject.EmailAddress1;
            entity["emailaddress2"] = excelobject.EmailAddress2;
            entity["telephone1"] = excelobject.Telephone1;
            entity["telephone2"] = excelobject.Telephone2;
            
            //Varlık alanları aşağıdadır.
            //Alanların varlık üzerine maplemesi gereklidir.
            //Objenin nasıl doldurulacağını araştıraak bulmanızı bekliyoruz.
            //Aşağıdaki 5 alan string tipindedir.
            //accountname,emailaddress1,emailaddress2,telephone1,telephone2

            return entity;
        }
    }
}
