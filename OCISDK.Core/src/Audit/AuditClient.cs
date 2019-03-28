/// <summary>
/// Audit Service Client
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using OCISDK.Core.src.Audit.Model;
using OCISDK.Core.src.Audit.Request;
using OCISDK.Core.src.Audit.Response;
using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.src.Audit
{
    public class AuditClient : ServiceClient
    {
        private string _region;
        public string Region
        {
            get { return _region; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _region = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private RestClient RestClient { get; set; }

        /// <summary>
        /// Constructer
        /// </summary>
        public AuditClient(ClientConfig config) : base(config)
        {
            ServiceName = "audit";

            this.RestClient = new RestClient()
            {
                Signer = Signer,
                Config = config
            };
        }

        public AuditClient(ClientConfig config, RestClient restClient) : base(config)
        {
            ServiceName = "audit";

            this.RestClient = new RestClient()
            {
                Signer = Signer,
                Config = config
            };

            RestClient = restClient;
        }

        /// <summary>
        /// Returns all the audit events processed for the specified compartment within the specified time range.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListEventsResponse ListEvents(ListEventsRequest listRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(AuditServices.EVENT, this.Region)}?" +
                $"{listRequest.GetOptionQuery()}");

            try
            {
                var webResponse = this.RestClient.Get(uri, listRequest.OpcRequestId);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListEventsResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<AuditEvent>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the configuration
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetConfigurationResponse GetConfiguration(GetConfigurationRequest request)
        {
            var uri = new Uri($"{GetEndPoint(AuditServices.CONFIGURATION, this.Region)}?compartmentId={request.CompartmentId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetConfigurationResponse()
                {
                    Configuration = JsonConvert.DeserializeObject<Configuration>(response)
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update the configuration
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateConfigurationResponse UpdateConfiguration(UpdateConfigurationRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(AuditServices.CONFIGURATION, this.Region)}?compartmentId={updateRequest.CompartmentId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.updateConfigurationDetails);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateConfigurationResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
