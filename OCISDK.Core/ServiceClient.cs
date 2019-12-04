
using OCISDK.Core.Common;
using System;
using System.IO;
namespace OCISDK.Core
{
    /// <summary>
    /// Base Service Client
    /// </summary>
    public class ServiceClient
    {
        /// <summary>
        /// region name
        /// </summary>
        public string Region { get; set; }

        /// <summary> Core Services Name </summary>
        protected string ServiceName { get; set; }

        /// <summary>
        /// IOciSigner
        /// </summary>
        protected IOciSigner Signer { get; set; }

        /// <summary>
        /// ClientConfigStream
        /// </summary>
        public ClientConfigStream Config { get; set; }

        /// <summary>
        /// JsonSerializer interface
        /// </summary>
        public IJsonSerializer JsonSerializer;

        /// <summary>
        /// WebRequestPolicy interface
        /// </summary>
        public IWebRequestPolicy WebRequestPolicy { get; set; }

        /// <summary>
        /// RestClient interace
        /// </summary>
        protected IRestClient RestClient { get; set; }

        /// <summary>
        /// RestClientAsync interface
        /// </summary>
        protected IRestClientAsync RestClientAsync { get; set; }

        /// <summary>
        /// constructer
        /// </summary>
        /// <param name="config"></param>
        public ServiceClient(ClientConfig config)
        {
            var streamConfig = new ClientConfigStream
            {
                AccountId = config.AccountId,
                DomainName = config.DomainName,
                Fingerprint = config.Fingerprint,
                HomeRegion = config.HomeRegion,
                IdentityDomain = config.IdentityDomain,
                Password = config.Password,
                PrivateKeyPassphrase = config.PrivateKeyPassphrase,
                TenancyId = config.TenancyId,
                UserId = config.UserId,
                UserName = config.UserName
            };

            using (var key = File.OpenText(config.PrivateKey))
            {
                streamConfig.PrivateKey = key;

                Initialize(streamConfig);
            }
        }

        /// <summary>
        /// constructer
        /// </summary>
        /// <param name="config"></param>
        /// <param name="ociSigner"></param>
        public ServiceClient(ClientConfig config, IOciSigner ociSigner)
        {
            var streamConfig = new ClientConfigStream
            {
                AccountId = config.AccountId,
                DomainName = config.DomainName,
                Fingerprint = config.Fingerprint,
                HomeRegion = config.HomeRegion,
                IdentityDomain = config.IdentityDomain,
                Password = config.Password,
                PrivateKeyPassphrase = config.PrivateKeyPassphrase,
                TenancyId = config.TenancyId,
                UserId = config.UserId,
                UserName = config.UserName
            };

            using (var key = File.OpenText(config.PrivateKey))
            {
                streamConfig.PrivateKey = key;

                Initialize(streamConfig, ociSigner);
            }
        }

        /// <summary>
        /// constructer
        /// </summary>
        /// <param name="config"></param>
        public ServiceClient(ClientConfigStream config)
        {
            Initialize(config);
        }

        /// <summary>
        /// constructer
        /// </summary>
        /// <param name="config"></param>
        /// <param name="ociSigner"></param>
        public ServiceClient(ClientConfigStream config, IOciSigner ociSigner)
        {
            Initialize(config, ociSigner);
        }



        /// <summary>
        /// Initialize Client
        /// </summary>
        /// <param name="config"></param>
        public void Initialize(ClientConfigStream config)
        {
            var signer = new OciSigner(
                config.TenancyId,
                config.UserId,
                config.Fingerprint,
                config.PrivateKey,
                config.PrivateKeyPassphrase);

            Initialize(config, signer);
        }

        /// <summary>
        /// initialization
        /// </summary>
        /// <param name="config"></param>
        /// <param name="ociSigner"></param>
        public void Initialize(ClientConfigStream config, IOciSigner ociSigner)
        {
            Config = config;

            Signer = ociSigner;

            JsonSerializer = new JsonDefaultSerializer();
            
            WebRequestPolicy = new DefaultWebRequestPolicy();

            // default region setting
            if (string.IsNullOrEmpty(config.HomeRegion))
            {
                // set ashburn if no default region found
                Region = Regions.US_ASHBURN_1;
            }
            else
            {
                // home region
                Region = config.HomeRegion;
            }

            this.RestClient = new RestClient()
            {
                Signer = this.Signer,
                JsonSerializer = JsonSerializer,
                WebRequestPolicy = WebRequestPolicy,
                Option = new RestOption()
            };

            this.RestClientAsync = new RestClientAsync()
            {
                Signer = this.Signer,
                JsonSerializer = JsonSerializer,
                WebRequestPolicy = WebRequestPolicy,
                Option = new RestOption()
            };
        }

        /// <summary>
        /// IOciSigner
        /// </summary>
        /// <returns></returns>
        protected IOciSigner GetSigner()
        {
            return Signer;
        }

        /// <summary>
        /// setter Region
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            Region = region;
        }

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        public string GetRegion()
        {
            return Region;
        }

        /// <summary>
        /// Get WebRequestPolicy
        /// </summary>
        /// <returns></returns>
        public IWebRequestPolicy GetWebRequestPolicy()
        {
            return WebRequestPolicy;
        }

        /// <summary>
        /// Set WebRequestPolicy
        /// </summary>
        /// <param name="webRequestPolicy"></param>
        public void SetWebRequestPolicy(IWebRequestPolicy webRequestPolicy)
        {
            WebRequestPolicy = webRequestPolicy;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IJsonSerializer GetJsonSerializer()
        {
            return JsonSerializer;
        }

        /// <summary>
        /// Set JsonSerializer
        /// </summary>
        public void SetJsonSerializer(IJsonSerializer jsonSerializer)
        {
            JsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// GetEndpoint
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public string GetEndPoint(string serviceName, string region)
        {
            return $"https://" +
                $"{Config.GetHostName(ServiceName, region)}/" +
                $"{Config.GetServiceVersion(ServiceName)}/" +
                $"{serviceName}";
        }

        /// <summary>
        /// GetEndpoint
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public string GetEndPoint(string serviceName, string region, string domain)
        {
            return $"https://" +
                $"{Config.GetHostName(ServiceName, region, domain)}/" +
                $"{Config.GetServiceVersion(ServiceName)}/" +
                $"{serviceName}";
        }

        /// <summary>
        /// GetEndpoint
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public string GetEndPointNoneVersion(string serviceName, string region)
        {
            return $"https://" +
                $"{Config.GetHostName(ServiceName, region)}/" +
                $"{serviceName}";
        }

        /// <summary>
        /// GetEndpoint
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public string GetEndPointItas(string serviceName, string domainName)
        {
            return $"https://itra.oraclecloud.com/itas/" +
                $"{domainName}/" +
                $"{Config.GetHostName(ServiceName, "no-region")}/api/" +
                $"{Config.GetServiceVersion(ServiceName)}/" +
                $"{serviceName}";
        }
    }
}
