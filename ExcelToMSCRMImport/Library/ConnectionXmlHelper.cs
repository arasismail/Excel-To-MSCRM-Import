using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExcelToMSCRMImport.Library
{
    /// <summary>
    /// XML Helper
    /// Bağlantı Bilgileri XML formatında kaydedilmektedir.
    /// Sınıf içerisinde yer alan metotlar ile XML dosyası üzerinde işlem yapılır.
    /// </summary>
    public class ConnectionXmlHelper
    {
        CriptoHepler criptoHelper = new CriptoHepler();
        private string connectionXmlPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        private string connectionXmlFolderPath;
        private string connectionXmlFilePath;

        public ConnectionXmlHelper()
        {
            connectionXmlFolderPath = connectionXmlPath + XmlStaticValue.MSCRMCustomizationToolFolderName;
            connectionXmlFilePath = connectionXmlPath + XmlStaticValue.MSCRMCustomizationToolFolderName + XmlStaticValue.connectionXmlFileName;
            if (!File.Exists(connectionXmlFilePath))
            {
                if (!File.Exists(connectionXmlFolderPath))
                {
                    Directory.CreateDirectory(connectionXmlFolderPath);
                }
                XmlTextWriter writer = new XmlTextWriter(connectionXmlFilePath, System.Text.Encoding.UTF8); writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement(XmlStaticValue.xmlMainTagName);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }

        }

        public void AddNewConnection(ConnectionObject connectionObject)
        {
            XmlDocument connectionXml = new XmlDocument();
            connectionXml.Load(connectionXmlFilePath);

            //Display all the book titles.
            XmlNodeList rootElementList = connectionXml.GetElementsByTagName(XmlStaticValue.xmlMainTagName);
            if (rootElementList.Count == 1)
            {

                string encryptPassword = EncryptPassword(connectionObject.Password);
                Guid systemId = Guid.NewGuid();
                XDocument doc = XDocument.Load(connectionXmlFilePath);
                XElement root = new XElement(XmlStaticValue.xmlRootElement);
                root.Add(new XAttribute(XmlStaticValue.rootAttributeForValue, connectionObject.SystemName));
                root.Add(new XAttribute(XmlStaticValue.rootAttributeForGuid, systemId));
                XElement child = new XElement(XmlStaticValue.xmlChildElement);
                child.Add(new XAttribute(XmlStaticValue.childAttributeForUrl, connectionObject.URL));
                child.Add(new XAttribute(XmlStaticValue.childAttributeForUserName, connectionObject.UserName));
                child.Add(new XAttribute(XmlStaticValue.childAttributeForPassword, encryptPassword));
                root.Add(child);
                doc.Element(XmlStaticValue.xmlMainTagName).Add(root);
                doc.Save(connectionXmlFilePath);
            }

        }

        public void UpdateConnection(ConnectionObject connectionObject)
        {

            XmlDocument connectionXml = new XmlDocument();
            connectionXml.Load(connectionXmlFilePath);

            XmlNodeList rootElementList = connectionXml.GetElementsByTagName(XmlStaticValue.xmlRootElement);
            foreach (XmlNode systemNode in rootElementList)
            {
                if (systemNode != null)
                {
                    XmlNode connectionIdNode = systemNode.Attributes.GetNamedItem(XmlStaticValue.rootAttributeForGuid);
                    string connectionId = connectionIdNode.Value;
                    if (connectionId == connectionObject.ConnectionId)
                    {

                        XmlNode valueNode = systemNode.Attributes.GetNamedItem(XmlStaticValue.rootAttributeForValue);
                        valueNode.Value = connectionObject.SystemName;

                        XmlNode connectionNode = systemNode.ChildNodes[0];

                        XmlNode urlNode = connectionNode.Attributes.GetNamedItem(XmlStaticValue.childAttributeForUrl);
                        urlNode.Value = connectionObject.URL;

                        XmlNode userNameNode = connectionNode.Attributes.GetNamedItem(XmlStaticValue.childAttributeForUserName);
                        userNameNode.Value = connectionObject.UserName;


                        string encryptPassword = EncryptPassword(connectionObject.Password);
                        XmlNode passwordNode = connectionNode.Attributes.GetNamedItem(XmlStaticValue.childAttributeForPassword);
                        passwordNode.Value = encryptPassword;
                        connectionXml.Save(connectionXmlFilePath);
                        break;
                    }
                }
            }
        }
        
        public List<ConnectionObject> ReadConnection()
        {
            List<ConnectionObject> connectionObjectList = new List<ConnectionObject>();

            XmlDocument connectionXml = new XmlDocument();
            connectionXml.Load(connectionXmlFilePath);

            XmlNodeList rootElementList = connectionXml.GetElementsByTagName(XmlStaticValue.xmlRootElement);
            foreach (XmlNode systemNode in rootElementList)
            {
                if (systemNode != null)
                {
                    ConnectionObject connectionObject = new ConnectionObject();
                    XmlNode valueNode = systemNode.Attributes.GetNamedItem(XmlStaticValue.rootAttributeForValue);
                    string systemValue = valueNode.Value;
                    XmlNode connectionIdNode = systemNode.Attributes.GetNamedItem(XmlStaticValue.rootAttributeForGuid);
                    string connectionId = connectionIdNode.Value;

                    XmlNode connectionNode = systemNode.ChildNodes[0];
                    XmlNode urlNode = connectionNode.Attributes.GetNamedItem(XmlStaticValue.childAttributeForUrl);
                    string urlValue = urlNode.Value;
                    XmlNode userNameNode = connectionNode.Attributes.GetNamedItem(XmlStaticValue.childAttributeForUserName);
                    string userNameValue = userNameNode.Value;
                    XmlNode passwordNode = connectionNode.Attributes.GetNamedItem(XmlStaticValue.childAttributeForPassword);
                    string encryptPasswordValue = passwordNode.Value;
                    string passwordValue = DecryptPassword(encryptPasswordValue);

                    connectionObject.SystemName = systemValue;
                    connectionObject.ConnectionId = connectionId;
                    connectionObject.URL = urlValue;
                    connectionObject.UserName = userNameValue;
                    connectionObject.Password = passwordValue;

                    connectionObjectList.Add(connectionObject);
                }
            }

            return connectionObjectList;
        }

        private string EncryptPassword(string text)
        {
            string encryptText = text;

            string criptoString = CriptoStaticValue.encryptString;
            if (!string.IsNullOrWhiteSpace(criptoString))
            {
                encryptText = criptoHelper.Encrypt(text, criptoString);
            }
            return encryptText;
        }

        private string DecryptPassword(string text)
        {
            string DecryptText = text;

            string criptoString = CriptoStaticValue.encryptString;
            if (!string.IsNullOrWhiteSpace(criptoString))
            {
                DecryptText = criptoHelper.Decrypt(text, criptoString);
            }
            return DecryptText;
        }
    }
}
