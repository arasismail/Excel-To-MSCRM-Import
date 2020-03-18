using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToMSCRMImport.Library
{
    public interface ILogger
    {
        void Log();
        void Log(string path, string columnNo, string exMessage);
    }
}
