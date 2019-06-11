/// <summary>
/// Client Configuration Class
/// 
/// author: koutaro furusawa
/// </summary>
using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OCISDK.Core.src
{
    public class ClientConfigBase<TKey>
    {
        public TKey PrivateKey { get; set; }

        /// <summary> user tenant OCID </summary>
        public string TenancyId { get; set; }

        /// <summary> user OCID </summary>
        public string UserId { get; set; }

        /// <summary> API Key Fingerprint </summary>
        public string Fingerprint { get; set; }
        
        /// <summary> private key password </summary>
        public string PrivateKeyPassphrase { get; set; }

        /// <summary> oracle cloud account ID </summary>
        public string AccountId { get; set; }

        /// <summary> my domain name </summary>
        public string DomainName { get; set; }

        /// <summary> identity domain </summary>
        public string IdentityDomain { get; set; }

        /// <summary> oracle cloud signin user </summary>
        public string UserName { get; set; }

        /// <summary> oracle cloud signin user password </summary>
        public string Password { get; set; }

        /// <summary> oracle cloud home region </summary>
        public string HomeRegion { get; set; }

        public const string ConfigFileName = "Resources/endpoints.json";

        protected EndpointConfig EndPoint;

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

        public ClientConfigBase()
        {
            var jsonSerializer = new JsonDefaultSerializer();

            var resourceName = "OCISDK.Core.Resources.endpoints.json";
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        string endp = sr.ReadToEnd();
                        EndPoint = jsonSerializer.Deserialize<EndpointConfig>(endp);
                    }
                }
            }
        }
    }

    public class ClientConfig : ClientConfigBase<string>
    {
    }

    public class ClientConfigStream : ClientConfigBase<StreamReader>
    {
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
