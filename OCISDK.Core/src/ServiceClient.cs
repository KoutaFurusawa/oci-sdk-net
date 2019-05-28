
using OCISDK.Core.src.Common;
using System;
using System.IO;
/// <summary>
/// Service Client
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src
{
    /// <summary>
    /// Base Service Client
    /// </summary>
    public class ServiceClient
    {
        private string _region;
        public string Region
        {
            get { return _region; }
            set
            {
                // the region is not null and registered to endpoints.json
                if (!string.IsNullOrEmpty(value) && Config.ContainRegion(value))
                {
                    _region = value;
                }
                else
                {
                    throw new ArgumentException("Region unknown");
                }
            }
        }

        /// <summary> Core Services Name </summary>
        public string ServiceName { get; set; }

        protected Signer Signer { get; set; }

        public ClientConfigStream Config { get; set; }
        
        public IJsonSerializer JsonSerializer;

        protected RestClient RestClient { get; set; }

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
        
        public ServiceClient(ClientConfigStream config)
        {
            var streamConfig = new ClientConfigStream
            {
                AccountId = config.AccountId,
                DomainName = config.DomainName,
                Fingerprint = config.Fingerprint,
                HomeRegion = config.HomeRegion,
                IdentityDomain = config.IdentityDomain,
                Password = config.Password,
                PrivateKey = config.PrivateKey,
                PrivateKeyPassphrase = config.PrivateKeyPassphrase,
                TenancyId = config.TenancyId,
                UserId = config.UserId,
                UserName = config.UserName
            };

            Initialize(streamConfig);
        }

        public void Initialize(ClientConfigStream config)
        {
            Config = config;

            Signer = new Signer(
                config.TenancyId,
                config.UserId,
                config.Fingerprint,
                config.PrivateKey,
                config.PrivateKeyPassphrase);

            JsonSerializer = new JsonDefaultSerializer();

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
                JsonSerializer = JsonSerializer
            };
        }

        protected Signer Sign()
        {
            return Signer;
        }

        public string GetEndPoint(string serviceName, string region)
        {
            return $"https://" +
                $"{Config.GetHostName(ServiceName, region)}/" +
                $"{Config.GetServiceVersion(ServiceName)}/" +
                $"{serviceName}";
        }

        public string GetEndPointNoneVersion(string serviceName, string region)
        {
            return $"https://" +
                $"{Config.GetHostName(ServiceName, region)}/" +
                $"{serviceName}";
        }

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
