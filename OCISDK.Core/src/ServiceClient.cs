
using OCISDK.Core.src.Common;
using System;
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
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary> Core Services Name </summary>
        public string ServiceName { get; set; }

        protected Signer Signer { get; set; }

        public ClientConfig Config { get; set; }
        
        public IJsonSerializer JsonSerializer;

        public ServiceClient(ClientConfig config)
        {
            Config = config;

            Signer = new Signer(
                config.TenancyId,
                config.UserId,
                config.Fingerprint,
                config.PrivateKeyPath,
                config.PrivateKeyPassphrase);

            JsonSerializer = new JsonDefaultSerializer();
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
    }
}
