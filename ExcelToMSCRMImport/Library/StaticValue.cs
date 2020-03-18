using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToMSCRMImport.Library
{

    /// <summary>
    /// Projede kullanılan statik değerleri içermektedir.
    /// </summary>
    public static class XmlStaticValue
    {
        public const string MSCRMCustomizationToolFolderName = "\\MSCRMCustomizationTool";
        public const string connectionXmlFileName = "\\ConnectionFile.xml";
        public const string templateFileName = "\\MSCRMToolTaslak.xlsx";
        public const string userDocumentFileName = "\\MSCRMCustomizationTool UserGuide.pdf";
        public const string xmlMainTagName = "ConnectionInformation";
        public const string xmlRootElement = "System";
        public const string rootAttributeForValue = "Value";
        public const string rootAttributeForGuid = "Id";
        public const string xmlChildElement = "Connection";
        public const string childAttributeForUrl = "Url";
        public const string childAttributeForUserName = "UserName";
        public const string childAttributeForPassword = "Password";
    }

    public class CriptoStaticValue
    {
        public const string encryptString = "Developer";
    }
    
}
