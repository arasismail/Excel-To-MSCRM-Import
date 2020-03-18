using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToMSCRMImport.Library
{

    /// <summary>
    /// Dynamics MS CRM'e bağlantı yapılmasını sağlayan Sınıf
    /// </summary>
    public class MSCRMConnection
    {
        private static string CRMUrl;

        private static string UserName;

        private static string Password;

        public MSCRMConnection(ConnectionObject connectionObject)
        {
            string realURL = connectionObject.URL + "/XRMServices/2011/Organization.svc";
            CRMUrl = realURL;
            UserName = connectionObject.UserName;
            Password = connectionObject.Password;
        }

        private static ManagedTokenOrganizationServiceProxy adminService;

        public static Uri ServiceUri { get; set; }

        private static object _locker = new object();

        private static IServiceManagement<IOrganizationService> _orgServiceManagement;

        private static SecurityTokenResponse _adminSecurityToken;

        private static void ReNewAdminSecurityTokenIfNeeds()
        {
            lock (MSCRMConnection._locker)
            {
                if (MSCRMConnection._adminSecurityToken == null || DateTime.UtcNow.AddMinutes(15) >= _adminSecurityToken.Response.Lifetime.Expires)
                {
                    if (adminService != null)
                    {
                        adminService.Dispose();
                    }


                    AuthenticationCredentials authCredentials = new AuthenticationCredentials();
                    authCredentials.ClientCredentials.UserName.UserName = MSCRMConnection.UserName;
                    authCredentials.ClientCredentials.UserName.Password = MSCRMConnection.Password;
                    authCredentials.ClientCredentials.UseIdentityConfiguration = true;

                    MSCRMConnection._adminSecurityToken = MSCRMConnection._orgServiceManagement.Authenticate(authCredentials).SecurityTokenResponse;
                }
            }
        }

        public static OrganizationServiceProxy AdminOrgService
        {
            get
            {
                ServiceUri = new Uri(MSCRMConnection.CRMUrl);

                if (MSCRMConnection._orgServiceManagement == null)
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    MSCRMConnection._orgServiceManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(ServiceUri);
                }

                ReNewAdminSecurityTokenIfNeeds();

                adminService = new ManagedTokenOrganizationServiceProxy(MSCRMConnection._orgServiceManagement, MSCRMConnection._adminSecurityToken);

                return adminService;
            }
        }


        public void Dispose()
        {
            if (adminService != null)
            {
                try { adminService.Dispose(); }
                catch { }
            }
            adminService = null;
        }

    }
}
/// <summary>
/// Wrapper class for OrganizationServiceProxy to support auto refresh security token
/// </summary>
internal sealed class ManagedTokenOrganizationServiceProxy : OrganizationServiceProxy
{
    private readonly AutoRefreshSecurityToken<OrganizationServiceProxy, IOrganizationService> _proxyManager;

    public ManagedTokenOrganizationServiceProxy(Uri serviceUri, ClientCredentials userCredentials)
        : base(serviceUri, null, userCredentials, null)
    {
        this._proxyManager = new AutoRefreshSecurityToken<OrganizationServiceProxy, IOrganizationService>(this);
    }

    public ManagedTokenOrganizationServiceProxy(IServiceManagement<IOrganizationService> serviceManagement,
        SecurityTokenResponse securityTokenRes)
        : base(serviceManagement, securityTokenRes)
    {
        this._proxyManager = new AutoRefreshSecurityToken<OrganizationServiceProxy, IOrganizationService>(this);
    }

    public ManagedTokenOrganizationServiceProxy(IServiceManagement<IOrganizationService> serviceManagement,
        ClientCredentials userCredentials)
        : base(serviceManagement, userCredentials)
    {
        this._proxyManager = new AutoRefreshSecurityToken<OrganizationServiceProxy, IOrganizationService>(this);
    }

    //protected override SecurityTokenResponse AuthenticateDeviceCore()
    //{
    //    return this._proxyManager.AuthenticateDevice();
    //}

    protected override void AuthenticateCore()
    {
        this._proxyManager.PrepareCredentials();
        base.AuthenticateCore();
    }

    protected override void ValidateAuthentication()
    {
        this._proxyManager.RenewTokenIfRequired();
        base.ValidateAuthentication();
    }
}

/// <summary>
/// Class that wraps acquiring the security token for a service
/// </summary>
public sealed class AutoRefreshSecurityToken<TProxy, TService>
    where TProxy : ServiceProxy<TService>
    where TService : class
{
    private readonly TProxy _proxy;

    /// <summary>
    /// Instantiates an instance of the proxy class
    /// </summary>
    /// <param name="proxy">Proxy that will be used to authenticate the user</param>
    public AutoRefreshSecurityToken(TProxy proxy)
    {
        if (null == proxy)
        {
            //throw new ArgumentNullException("proxy");
        }

        this._proxy = proxy;
    }

    /// <summary>
    /// Prepares authentication before authen6ticated
    /// </summary>
    public void PrepareCredentials()
    {
        if (null == this._proxy.ClientCredentials)
        {
            return;
        }

        switch (this._proxy.ServiceConfiguration.AuthenticationType)
        {
            case AuthenticationProviderType.ActiveDirectory:
                this._proxy.ClientCredentials.UserName.UserName = null;
                this._proxy.ClientCredentials.UserName.Password = null;
                break;
            case AuthenticationProviderType.Federation:
            case AuthenticationProviderType.LiveId:
                this._proxy.ClientCredentials.Windows.ClientCredential = null;
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// Renews the token (if it is near expiration or has expired)
    /// </summary>
    public void RenewTokenIfRequired()
    {
        if (null != this._proxy.SecurityTokenResponse &&
            DateTime.UtcNow.AddMinutes(15) >= this._proxy.SecurityTokenResponse.Response.Lifetime.Expires)
        {
            try
            {
                this._proxy.Authenticate();
            }
            catch (CommunicationException)
            {
                if (null == this._proxy.SecurityTokenResponse ||
                    DateTime.UtcNow >= this._proxy.SecurityTokenResponse.Response.Lifetime.Expires)
                {
                    throw;
                }

                // Ignore the exception 
            }
        }
    }
}
