using OCISDK.Core.DNS.Request;
using OCISDK.Core.DNS.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.DNS
{
    /// <summary>
    /// DNSClientAsync interface
    /// </summary>
    public interface IDNSClientAsync : IClientSetting
    {
        /// <summary>
        /// Gets a list of all zones in the specified compartment. The collection can be filtered by name, time created, and zone type.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListZonesResponse> ListZones(ListZonesRequest request);

        /// <summary>
        /// Gets a list of all steering policies in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListSteeringPoliciesResponse> ListSteeringPolicies(ListSteeringPoliciesRequest request);

        /// <summary>
        /// Lists the steering policy attachments in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListSteeringPolicyAttachmentsResponse> ListSteeringPolicyAttachments(ListSteeringPolicyAttachmentsRequest request);

        /// <summary>
        /// Gets information about the specified zone, including its creation date, zone type, and serial.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetZoneResponse> GetZone(GetZoneRequest request);

        /// <summary>
        /// Gets all records in the specified zone. The results are sorted by domain in alphabetical order by default.
        /// For more information about records, see Resource Record (RR) TYPEs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetZoneRecordsResponse> GetZoneRecords(GetZoneRecordsRequest request);

        /// <summary>
        /// Gets a list of all records at the specified zone and domain.
        /// The results are sorted by rtype in alphabetical order by default. You can optionally filter and/or sort the results using the listed parameters.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDomainRecordsResponse> GetDomainRecords(GetDomainRecordsRequest request);

        /// <summary>
        /// Gets a list of all records in the specified RRSet. The results are sorted by recordHash by default.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetRRSetResponse> GetRRSet(GetRRSetRequest request);

        /// <summary>
        /// Gets information about the specified steering policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetSteeringPolicyResponse> GetSteeringPolicy(GetSteeringPolicyRequest request);

        /// <summary>
        /// Gets information about the specified steering policy attachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetSteeringPolicyAttachmentResponse> GetSteeringPolicyAttachment(GetSteeringPolicyAttachmentRequest request);

        /// <summary>
        /// Moves a zone into a different compartment. When provided, If-Match is checked against ETag values of the resource. 
        /// Note: All SteeringPolicyAttachment objects associated with this zone will also be moved into the provided compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeZoneCompartmentResponse> ChangeZoneCompartment(ChangeZoneCompartmentRequest request);

        /// <summary>
        /// Moves a steering policy into a different compartment. When provided, If-Match is checked against ETag values of the resource.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeSteeringPolicyCompartmentResponse> ChangeSteeringPolicyCompartment(ChangeSteeringPolicyCompartmentRequest request);

        /// <summary>
        /// Creates a new zone in the specified compartment. 
        /// The compartmentId query parameter is required if the Content-Type header for the request is text/dns.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateZoneResponse> CreateZone(CreateZoneRequest request);

        /// <summary>
        /// Creates a new steering policy in the specified compartment.
        /// For more information on creating policies with templates, see Traffic Management API Guide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateSteeringPolicyResponse> CreateSteeringPolicy(CreateSteeringPolicyRequest request);

        /// <summary>
        /// Creates a new attachment between a steering policy and a domain, giving the policy permission to answer queries for the specified domain. 
        /// A steering policy must be attached to a domain for the policy to answer DNS queries for that domain.
        /// 
        /// For the purposes of access control, the attachment is automatically placed into the same compartment as the domain's zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateSteeringPolicyAttachmentResponse> CreateSteeringPolicyAttachment(CreateSteeringPolicyAttachmentRequest request);

        /// <summary>
        /// Updates the specified secondary zone with your new external master server information. 
        /// For more information about secondary zone, see Manage DNS Service Zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateZoneResponse> UpdateZone(UpdateZoneRequest request);

        /// <summary>
        /// Replaces records in the specified zone with the records specified in the request body. 
        /// If a specified record does not exist, it will be created. If the record exists, then it will be updated to represent the record in the body of the request. 
        /// If a record in the zone does not exist in the request body, the record will be removed from the zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateZoneRecordsResponse> UpdateZoneRecords(UpdateZoneRecordsRequest request);

        /// <summary>
        /// Replaces records in the specified zone at a domain with the records specified in the request body. 
        /// If a specified record does not exist, it will be created. If the record exists, then it will be updated to represent the record in the body of the request. 
        /// If a record in the zone does not exist in the request body, the record will be removed from the zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDomainRecordsResponse> UpdateDomainRecords(UpdateDomainRecordsRequest request);

        /// <summary>
        /// Replaces records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateRRSetResponse> UpdateRRSet(UpdateRRSetRequest request);

        /// <summary>
        /// Updates the configuration of the specified steering policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateSteeringPolicyResponse> UpdateSteeringPolicy(UpdateSteeringPolicyRequest request);

        /// <summary>
        /// Updates the specified steering policy attachment with your new information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateSteeringPolicyAttachmentResponse> UpdateSteeringPolicyAttachment(UpdateSteeringPolicyAttachmentRequest request);

        /// <summary>
        /// Updates a collection of records in the specified zone. 
        /// You can update one record or all records for the specified zone depending on the changes provided in the request body. 
        /// You can also add or remove records using this function.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PatchZoneRecordsResponse> PatchZoneRecords(PatchZoneRecordsRequest request);

        /// <summary>
        /// Updates records in the specified zone at a domain.
        /// You can update one record or all records for the specified zone depending on the changes provided in the request body.
        /// You can also add or remove records using this function.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PatchDomainRecordsResponse> PatchDomainRecords(PatchDomainRecordsRequest request);

        /// <summary>
        /// Updates records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PatchRRSetResponse> PatchRRSet(PatchRRSetRequest request);

        /// <summary>
        /// Deletes the specified zone and all its steering policy attachments. 
        /// A 204 response indicates that zone has been successfully deleted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteZoneResponse> DeleteZone(DeleteZoneRequest request);

        /// <summary>
        /// Deletes all records at the specified zone and domain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteDomainRecordsResponse> DeleteDomainRecords(DeleteDomainRecordsRequest request);

        /// <summary>
        /// Deletes all records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteRRSetResponse> DeleteRRSet(DeleteRRSetRequest request);

        /// <summary>
        /// Deletes the specified steering policy. A 204 response indicates that the delete has been successful.
        /// Deletion will fail if the policy is attached to any zones. To detach a policy from a zone, see DeleteSteeringPolicyAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteSteeringPolicyResponse> DeleteSteeringPolicy(DeleteSteeringPolicyRequest request);

        /// <summary>
        /// Deletes the specified steering policy attachment. A 204 response indicates that the delete has been successful.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteSteeringPolicyAttachmentResponse> DeleteSteeringPolicyAttachment(DeleteSteeringPolicyAttachmentRequest request);
    }
}
