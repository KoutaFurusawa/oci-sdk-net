/// <summary>
/// Client Configuration Class
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        public int MaxErrorRetry {
            get { return _maxErrorRetry; }
            set {
                if(value >= 1)
                {
                    _maxErrorRetry = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        protected EndpointConfig EndPoint;

        public ClientConfig()
        {
            var endpoints = Encoding.UTF8.GetString(Properties.Resources.endpoints);

            JsonSerializer serializer = new JsonSerializer();

            var stream = new MemoryStream(Properties.Resources.endpoints);
            using (StreamReader sr = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        EndPoint = serializer.Deserialize<EndpointConfig>(reader);
                    }
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
        [JsonProperty("regionShortNames")]
        public IDictionary<string, string> RegionShortNames { get; set; }

        [JsonProperty("services")]
        public IDictionary<string, ServiceConfigs> Services { get; set; }
    }

    public class ServiceConfigs
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        
        [JsonProperty("endpoints")]
        public IDictionary<string, Endpoint> Endpoints;
    }

    public class Endpoint
    {
        [JsonProperty("hostname")]
        public string Hostname { get; set; }
    }
}
