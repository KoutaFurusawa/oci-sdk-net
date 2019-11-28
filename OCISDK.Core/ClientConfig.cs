using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OCISDK.Core
{
    /// <summary>
    /// Client Configuration Class
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class ClientConfigBase<TKey>
    {
        /// <summary>
        /// private key
        /// </summary>
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

        /// <summary>
        /// deafault ConfigFileName
        /// </summary>
        public const string ConfigFileName = "Properties/endpoints.json";

        /// <summary>
        /// EndpointConfig
        /// </summary>
        protected EndpointConfig EndPoint;
        
        /// <summary>
        /// region contain
        /// </summary>
        /// <param name="regionName"></param>
        /// <returns></returns>
        public virtual bool ContainRegion(string regionName)
        {
            return EndPoint.RegionShortNames.Values.Contains(regionName);
        }

        /// <summary>
        /// regionname getter
        /// </summary>
        /// <param name="regionShortName"></param>
        /// <returns></returns>
        public virtual string GetRegionName(string regionShortName)
        {
            return EndPoint.RegionShortNames[regionShortName.ToLower()];
        }

        /// <summary>
        /// serviceVersion getter
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public virtual string GetServiceVersion(string serviceName)
        {
            return EndPoint.Services[serviceName].Version;
        }

        /// <summary>
        /// hostName getter
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public virtual string GetHostName(string serviceName, string region)
        {
            return GetHostName(serviceName, region, "oraclecloud.com");
        }

        /// <summary>
        /// hostName getter
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="region"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public virtual string GetHostName(string serviceName, string region, string domain)
        {
            var host = $"{EndPoint.Services[serviceName].Hosttag}.{region}.{domain}";
            return host;
        }

        /// <summary>
        /// constructer
        /// </summary>
        public ClientConfigBase()
        {
            var jsonSerializer = new JsonDefaultSerializer();

            var resourceName = "OCISDK.Core.Properties.endpoints.json";
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

    /// <summary>
    /// default ClientConfig
    /// </summary>
    public class ClientConfig : ClientConfigBase<string>
    {
    }

    /// <summary>
    /// stream ClientConfig
    /// </summary>
    public class ClientConfigStream : ClientConfigBase<StreamReader>
    {
    }

    /// <summary>
    /// EndpointConfig
    /// </summary>
    public class EndpointConfig
    {
        /// <summary>
        /// RegionShortNames
        /// </summary>
        public IDictionary<string, string> RegionShortNames { get; set; }

        /// <summary>
        /// Services
        /// </summary>
        public IDictionary<string, ServiceConfigs> Services { get; set; }
    }

    /// <summary>
    /// ServiceConfigs
    /// </summary>
    public class ServiceConfigs
    {
        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Hosttag
        /// </summary>
        public string Hosttag { get; set; }
    }
}
