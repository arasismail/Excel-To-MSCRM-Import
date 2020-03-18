using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToMSCRMImport.Library
{
    /// <summary>
    /// Dynamics MS CRM üzerinde işlem yapabilmek için kullanılanacak oluşturma (Insert) işlemidir.
    /// </summary>

    public class MSCRMHelper
    {
        private static IOrganizationService CrmService;
        private static RetrieveAllEntitiesResponse CrmAllEntityResponse;

        public Result ControlMSCRMConnection(ConnectionObject connectionObject)
        {
            Result returnValue = new Result();

            MSCRMConnection crmConnection = new MSCRMConnection(connectionObject);
            try
            {
                IOrganizationService service = MSCRMConnection.AdminOrgService;
                CrmService = service;
                returnValue.IsSuccess = true;
            }
            catch (Exception ex)
            {
                returnValue.IsSuccess = false;
                returnValue.Message = ex.Message;
            }

            return returnValue;
        }

        /// <summary>
        /// Dynamics MS CRM uygulamasında veri oluşturmak için bu metodu kullanamanız gerekmektedir.
        /// </summary>
        /// <param name="account"></param>
        public void CreateEntityRecord(Entity account)
        {
            CrmService.Create(account);
        }
    }
}
