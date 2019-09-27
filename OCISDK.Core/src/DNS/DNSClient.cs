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
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

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
        /// Gets all records in the specified zone. The results are sorted by domain in alphabetical order by default.
        /// For more information about records, see Resource Record (RR) TYPEs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetZoneRecordsResponse GetZoneRecords(GetZoneRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records";

            var options = request.GetOptionQuery();

            if(!string.IsNullOrEmpty(options))
            {
                uriStr = $"{uriStr}?{options}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Get(uri, "", request.IfNoneMatch, request.IfModifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetZoneRecordsResponse()
                {
                    RecordCollection = this.JsonSerializer.Deserialize<RecordCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets a list of all records at the specified zone and domain.
        /// The results are sorted by rtype in alphabetical order by default. You can optionally filter and/or sort the results using the listed parameters.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetDomainRecordsResponse GetDomainRecords(GetDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            var options = request.GetOptionQuery();

            if (!string.IsNullOrEmpty(options))
            {
                uriStr = $"{uriStr}?{options}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Get(uri, "", request.IfNoneMatch, request.IfModifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetDomainRecordsResponse()
                {
                    RecordCollection = this.JsonSerializer.Deserialize<RecordCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
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
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

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
        /// Replaces records in the specified zone with the records specified in the request body. 
        /// If a specified record does not exist, it will be created. If the record exists, then it will be updated to represent the record in the body of the request. 
        /// If a record in the zone does not exist in the request body, the record will be removed from the zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateZoneRecordsResponse UpdateZoneRecords(UpdateZoneRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Put(uri, request.UpdateZoneRecordsDetails, request.IfMatch, "", "", request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateZoneRecordsResponse()
                {
                    RecordCollection = this.JsonSerializer.Deserialize<RecordCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Replaces records in the specified zone at a domain with the records specified in the request body. 
        /// If a specified record does not exist, it will be created. If the record exists, then it will be updated to represent the record in the body of the request. 
        /// If a record in the zone does not exist in the request body, the record will be removed from the zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateDomainRecordsResponse UpdateDomainRecords(UpdateDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            if(!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Put(uri, request.UpdateDomainRecordsDetails, request.IfMatch, "", "", request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateDomainRecordsResponse()
                {
                    RecordCollection = this.JsonSerializer.Deserialize<RecordCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates a collection of records in the specified zone. 
        /// You can update one record or all records for the specified zone depending on the changes provided in the request body. 
        /// You can also add or remove records using this function.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PatchZoneRecordsResponse PatchZoneRecords(PatchZoneRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Patch(uri, request.PatchZoneRecordsDetails, request.IfMatch, request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PatchZoneRecordsResponse()
                {
                    RecordCollection = this.JsonSerializer.Deserialize<RecordCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates records in the specified zone at a domain.
        /// You can update one record or all records for the specified zone depending on the changes provided in the request body.
        /// You can also add or remove records using this function.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PatchDomainRecordsResponse PatchDomainRecords(PatchDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Patch(uri, request.PatchDomainRecordsDetails, request.IfMatch, request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PatchDomainRecordsResponse()
                {
                    RecordCollection = this.JsonSerializer.Deserialize<RecordCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
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
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

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

        /// <summary>
        /// Deletes all records at the specified zone and domain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteDomainRecordsResponse DeleteDomainRecords(DeleteDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, request.IfMatch, "", "", request.IfUnmodifiedSince);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteDomainRecordsResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}
