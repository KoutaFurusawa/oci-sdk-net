using OCISDK.Core.Audit.Model;
using OCISDK.Core.Audit.Request;
using OCISDK.Core.Audit.Response;
using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.Audit
{
    /// <summary>
    /// Audit service
    /// </summary>
    public class AuditClient : ServiceClient, IAuditClient
    {
        private readonly string AuditServiceName = "audit";

        /// <summary>
        /// Constructer
        /// </summary>
        public AuditClient(ClientConfig config) : base(config)
        {
            ServiceName = AuditServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public AuditClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = AuditServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public AuditClient(ClientConfigStream config) : base(config)
        {
            ServiceName = AuditServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public AuditClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = AuditServiceName;
        }

        /// <summary>
        /// Returns all the audit events processed for the specified compartment within the specified time range.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListEventsResponse ListEvents(ListEventsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(AuditServices.EVENT, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = listRequest.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();
                return new ListEventsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<AuditEvent>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
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
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetConfigurationResponse()
                {
                    Configuration = JsonSerializer.Deserialize<Configuration>(response)
                };
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
            
            var webResponse = this.RestClient.Put(uri, updateRequest.updateConfigurationDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateConfigurationResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }
    }
}
