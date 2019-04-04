/// <summary>
/// Client Configuration Class
/// 
/// author: koutaro furusawa
/// </summary>


using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.src
{
    public class ClientConfig
    {
        /// <summary> user tenant OCID </summary>
        public string TenancyId { get; set; }

        /// <summary> user OCID </summary>
        public string UserId { get; set; }

        /// <summary> API Key Fingerprint </summary>
        public string Fingerprint { get; set; }

        /// <summary> private key path </summary>
        public string PrivateKeyPath { get; set; }

        /// <summary> private key password </summary>
        public string PrivateKeyPassphrase { get; set; }
        
        /// <summary>
        /// Gets or sets the time-out value in milliseconds for the 
        /// System.Net.HttpWebRequest.GetResponse and System.Net.HttpWebRequest.GetRequestStream methods.
        /// Default value is 100 seconds
        /// </summary>
        public int? Timeout { get; set; }

        public int? ReadWriteTimeout { get; set; }

        private int _maxErrorRetry = 3;
        /// <summary>
        /// request retry max count. min:1, defoult:3
        /// </summary>
        public int MaxErrorRetry
        {
            get { return _maxErrorRetry; }
            set
            {
                if (value >= 1)
                {
                    _maxErrorRetry = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private const string ConfigFileName = "src/endpoints.json";

        protected EndpointConfig EndPoint;

        public ClientConfig()
        {
            var jsonSerializer = new JsonDefaultSerializer();
            string assemblyLocation = typeof(ClientConfig).Assembly.Location;
            string endpointsPath = Path.Combine(Path.GetDirectoryName(assemblyLocation), ConfigFileName);
            if (File.Exists(endpointsPath))
            {
                using (StreamReader sr = new StreamReader(endpointsPath))
                {
                    string endp = sr.ReadToEnd();
                    EndPoint = jsonSerializer.Deserialize<EndpointConfig>(endp);
                }
            }
        }

        public virtual bool ContainRegion(string regionName)
        {
            return EndPoint.RegionShortNames.Values.Contains(regionName);
        }

        public virtual string GetRegionName(string regionShortName)
        {
            return EndPoint.RegionShortNames[regionShortName.ToLower()];
        }

        public virtual string GetServiceVersion(string serviceName)
        {
            return EndPoint.Services[serviceName].Version;
        }

        public virtual string GetHostName(string serviceName, string region)
        {
            return EndPoint.Services[serviceName].Endpoints[region].Hostname;
        }
    }

    public class EndpointConfig
    {
        public IDictionary<string, string> RegionShortNames { get; set; }
        
        public IDictionary<string, ServiceConfigs> Services { get; set; }
    }

    public class ServiceConfigs
    {
        public string Version { get; set; }
        
        public IDictionary<string, Endpoint> Endpoints;
    }

    public class Endpoint
    {
        public string Hostname { get; set; }
    }
}
