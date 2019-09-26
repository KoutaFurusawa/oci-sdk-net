using OCISDK.Core.src.DNS.Model;
using OCISDK.Core.src.DNS.Request;
using OCISDK.Core.src.DNS.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.DNS
{
    public class DNSClient : ServiceClient, IDNSClient
    {
        private readonly string DatabaseServiceName = "dns";
        /// <summary>
        /// Constructer
        /// </summary>
        public DNSClient(ClientConfig config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        public DNSClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        public DNSClient(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        public DNSClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
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
        /// Gets a list of all zones in the specified compartment. The collection can be filtered by name, time created, and zone type.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListZonesResponse ListZones(ListZonesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListZonesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<ZoneSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified zone, including its creation date, zone type, and serial.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetZoneResponse GetZone(GetZoneRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}?compartmentId={request.CompartmentId}");

            var webResponse = this.RestClient.Get(uri, "", request.IfNoneMatch, request.IfModifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetZoneResponse()
                {
                    Zone = this.JsonSerializer.Deserialize<ZoneDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Moves a zone into a different compartment. When provided, If-Match is checked against ETag values of the resource. 
        /// Note: All SteeringPolicyAttachment objects associated with this zone will also be moved into the provided compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ChangeZoneCompartmentResponse ChangeZoneCompartment(ChangeZoneCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, request.ChangeZoneCompartmentDetails, request.OpcRetryToken, "", request.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeZoneCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new zone in the specified compartment. 
        /// The compartmentId query parameter is required if the Content-Type header for the request is text/dns.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateZoneResponse CreateZone(CreateZoneRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}");

            var webResponse = this.RestClient.Post(uri, request.CreateZoneDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateZoneResponse()
                {
                    Zone = this.JsonSerializer.Deserialize<ZoneDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the specified secondary zone with your new external master server information. 
        /// For more information about secondary zone, see Manage DNS Service Zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateZoneResponse UpdateZone(UpdateZoneRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}?compartmentId={request.CompartmentId}");

            var webResponse = this.RestClient.Put(uri, request.UpdateZoneDetails, request.IfMatch, "", "", request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateZoneResponse()
                {
                    Zone = this.JsonSerializer.Deserialize<ZoneDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Deletes the specified zone and all its steering policy attachments. 
        /// A 204 response indicates that zone has been successfully deleted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteZoneResponse DeleteZone(DeleteZoneRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}?compartmentId={request.CompartmentId}");

            var webResponse = this.RestClient.Delete(uri, request.IfMatch, "", "", request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteZoneResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}
