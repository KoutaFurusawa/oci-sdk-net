using OCISDK.Core.Common;
using OCISDK.Core.DNS.Model;
using OCISDK.Core.DNS.Request;
using OCISDK.Core.DNS.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.DNS
{
    /// <summary>
    /// DNSClientAsync
    /// </summary>
    public class DNSClientAsync : ServiceClient, IDNSClientAsync
    {
        private readonly string DatabaseServiceName = "dns";

        /// <summary>
        /// Constructer
        /// </summary>
        public DNSClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public DNSClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public DNSClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public DNSClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }
        
        /// <summary>
        /// Gets a list of all zones in the specified compartment. The collection can be filtered by name, time created, and zone type.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListZonesResponse> ListZones(ListZonesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        /// Gets a list of all steering policies in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListSteeringPoliciesResponse> ListSteeringPolicies(ListSteeringPoliciesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.SteeringPolicies, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListSteeringPoliciesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<SteeringPolicySummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the steering policy attachments in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListSteeringPolicyAttachmentsResponse> ListSteeringPolicyAttachments(ListSteeringPolicyAttachmentsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.SteeringPolicyAttachments, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListSteeringPolicyAttachmentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<SteeringPolicyAttachmentSummary>>(response),
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
        public async Task<GetZoneResponse> GetZone(GetZoneRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfNoneMatch = request.IfNoneMatch,
                IfModifiedSince = request.IfModifiedSince
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

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
        public async Task<GetZoneRecordsResponse> GetZoneRecords(GetZoneRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records";

            var options = request.GetOptionQuery();

            if(!string.IsNullOrEmpty(options))
            {
                uriStr = $"{uriStr}?{options}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfNoneMatch = request.IfNoneMatch,
                IfModifiedSince = request.IfModifiedSince
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

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
        public async Task<GetDomainRecordsResponse> GetDomainRecords(GetDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            var options = request.GetOptionQuery();

            if (!string.IsNullOrEmpty(options))
            {
                uriStr = $"{uriStr}?{options}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfNoneMatch = request.IfNoneMatch,
                IfModifiedSince = request.IfModifiedSince
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

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
        /// Gets a list of all records in the specified RRSet. The results are sorted by recordHash by default.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetRRSetResponse> GetRRSet(GetRRSetRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}/{request.Rtype}";

            var options = request.GetOptionQuery();

            if (!string.IsNullOrEmpty(options))
            {
                uriStr = $"{uriStr}?{options}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfNoneMatch = request.IfNoneMatch,
                IfModifiedSince = request.IfModifiedSince
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetRRSetResponse()
                {
                    RRSet = this.JsonSerializer.Deserialize<RRSetDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcTotalItems = webResponse.Headers.Get("opc-total-items"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified steering policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetSteeringPolicyResponse> GetSteeringPolicy(GetSteeringPolicyRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.SteeringPolicies, this.Region)}/{request.SteeringPolicyId}";
            
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfNoneMatch = request.IfNoneMatch,
                IfModifiedSince = request.IfModifiedSince
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetSteeringPolicyResponse()
                {
                    SteeringPolicy = this.JsonSerializer.Deserialize<SteeringPolicyDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified steering policy attachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetSteeringPolicyAttachmentResponse> GetSteeringPolicyAttachment(GetSteeringPolicyAttachmentRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.SteeringPolicyAttachments, this.Region)}/{request.SteeringPolicyAttachmentId}";

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfNoneMatch = request.IfNoneMatch,
                IfModifiedSince = request.IfModifiedSince
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetSteeringPolicyAttachmentResponse()
                {
                    SteeringPolicyAttachment = this.JsonSerializer.Deserialize<SteeringPolicyAttachmentDetails>(response),
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
        public async Task<ChangeZoneCompartmentResponse> ChangeZoneCompartment(ChangeZoneCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = request.OpcRetryToken,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeZoneCompartmentDetails, httpRequestHeaderParam);

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
        /// Moves a steering policy into a different compartment. When provided, If-Match is checked against ETag values of the resource.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeSteeringPolicyCompartmentResponse> ChangeSteeringPolicyCompartment(ChangeSteeringPolicyCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.SteeringPolicies, this.Region)}/{request.SteeringPolicyId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeSteeringPolicyCompartmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeSteeringPolicyCompartmentResponse()
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
        public async Task<CreateZoneResponse> CreateZone(CreateZoneRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.Zones, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateZoneDetails);

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
        /// Creates a new steering policy in the specified compartment.
        /// For more information on creating policies with templates, see Traffic Management API Guide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateSteeringPolicyResponse> CreateSteeringPolicy(CreateSteeringPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.SteeringPolicies, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateSteeringPolicyDetails, new HttpRequestHeaderParam() { OpcRetryToken= request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateSteeringPolicyResponse()
                {
                    SteeringPolicy = this.JsonSerializer.Deserialize<SteeringPolicyDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Creates a new attachment between a steering policy and a domain, giving the policy permission to answer queries for the specified domain. 
        /// A steering policy must be attached to a domain for the policy to answer DNS queries for that domain.
        /// 
        /// For the purposes of access control, the attachment is automatically placed into the same compartment as the domain's zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateSteeringPolicyAttachmentResponse> CreateSteeringPolicyAttachment(CreateSteeringPolicyAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DNSServices.SteeringPolicyAttachments, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateSteeringPolicyAttachmentDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateSteeringPolicyAttachmentResponse()
                {
                    SteeringPolicyAttachment = this.JsonSerializer.Deserialize<SteeringPolicyAttachmentDetails>(response),
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
        public async Task<UpdateZoneResponse> UpdateZone(UpdateZoneRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateZoneDetails, httpRequestHeaderParam);

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
        public async Task<UpdateZoneRecordsResponse> UpdateZoneRecords(UpdateZoneRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateZoneRecordsDetails, httpRequestHeaderParam);

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
        public async Task<UpdateDomainRecordsResponse> UpdateDomainRecords(UpdateDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            if(!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDomainRecordsDetails, httpRequestHeaderParam);

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
        /// Replaces records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateRRSetResponse> UpdateRRSet(UpdateRRSetRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}/{request.Rtype}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateRRSetDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateRRSetResponse()
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
        /// Updates the configuration of the specified steering policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateSteeringPolicyResponse> UpdateSteeringPolicy(UpdateSteeringPolicyRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.SteeringPolicies, this.Region)}/{request.SteeringPolicyId}";
            
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateSteeringPolicyDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateSteeringPolicyResponse()
                {
                    SteeringPolicy = this.JsonSerializer.Deserialize<SteeringPolicyDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the specified steering policy attachment with your new information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateSteeringPolicyAttachmentResponse> UpdateSteeringPolicyAttachment(UpdateSteeringPolicyAttachmentRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.SteeringPolicyAttachments, this.Region)}/{request.SteeringPolicyAttachmentId}";

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateSteeringPolicyAttachmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateSteeringPolicyAttachmentResponse()
                {
                    SteeringPolicyAttachment = this.JsonSerializer.Deserialize<SteeringPolicyAttachmentDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
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
        public async Task<PatchZoneRecordsResponse> PatchZoneRecords(PatchZoneRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Patch(uri, request.PatchZoneRecordsDetails, httpRequestHeaderParam);

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
        public async Task<PatchDomainRecordsResponse> PatchDomainRecords(PatchDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Patch(uri, request.PatchDomainRecordsDetails, httpRequestHeaderParam);

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
        /// Updates records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PatchRRSetResponse> PatchRRSet(PatchRRSetRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}/{request.Rtype}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Patch(uri, request.PatchRRSetDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PatchRRSetResponse()
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
        public async Task<DeleteZoneResponse> DeleteZone(DeleteZoneRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

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
        public async Task<DeleteDomainRecordsResponse> DeleteDomainRecords(DeleteDomainRecordsRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

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

        /// <summary>
        /// Deletes all records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteRRSetResponse> DeleteRRSet(DeleteRRSetRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.Zones, this.Region)}/{request.ZoneNameOrId}/records/{request.Domain}/{request.Rtype}";

            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteRRSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified steering policy. A 204 response indicates that the delete has been successful.
        /// Deletion will fail if the policy is attached to any zones. To detach a policy from a zone, see DeleteSteeringPolicyAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteSteeringPolicyResponse> DeleteSteeringPolicy(DeleteSteeringPolicyRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.SteeringPolicies, this.Region)}/{request.SteeringPolicyId}";
            
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteSteeringPolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified steering policy attachment. A 204 response indicates that the delete has been successful.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteSteeringPolicyAttachmentResponse> DeleteSteeringPolicyAttachment(DeleteSteeringPolicyAttachmentRequest request)
        {
            var uriStr = $"{GetEndPoint(DNSServices.SteeringPolicyAttachments, this.Region)}/{request.SteeringPolicyAttachmentId}";

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfUnmodifiedSince = request.IfUnmodifiedSince
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteSteeringPolicyAttachmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}
