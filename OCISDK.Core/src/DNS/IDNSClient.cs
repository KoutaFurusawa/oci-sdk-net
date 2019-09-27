using OCISDK.Core.src.DNS.Request;
using OCISDK.Core.src.DNS.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.DNS
{
    public interface IDNSClient
    {
        /// <summary>
        /// Gets a list of all zones in the specified compartment. The collection can be filtered by name, time created, and zone type.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListZonesResponse ListZones(ListZonesRequest request);

        /// <summary>
        /// Gets information about the specified zone, including its creation date, zone type, and serial.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetZoneResponse GetZone(GetZoneRequest request);

        /// <summary>
        /// Gets all records in the specified zone. The results are sorted by domain in alphabetical order by default.
        /// For more information about records, see Resource Record (RR) TYPEs.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetZoneRecordsResponse GetZoneRecords(GetZoneRecordsRequest request);

        /// <summary>
        /// Gets a list of all records at the specified zone and domain.
        /// The results are sorted by rtype in alphabetical order by default. You can optionally filter and/or sort the results using the listed parameters.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDomainRecordsResponse GetDomainRecords(GetDomainRecordsRequest request);

        /// <summary>
        /// Gets a list of all records in the specified RRSet. The results are sorted by recordHash by default.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetRRSetResponse GetRRSet(GetRRSetRequest request);

        /// <summary>
        /// Moves a zone into a different compartment. When provided, If-Match is checked against ETag values of the resource. 
        /// Note: All SteeringPolicyAttachment objects associated with this zone will also be moved into the provided compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeZoneCompartmentResponse ChangeZoneCompartment(ChangeZoneCompartmentRequest request);

        /// <summary>
        /// Creates a new zone in the specified compartment. 
        /// The compartmentId query parameter is required if the Content-Type header for the request is text/dns.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateZoneResponse CreateZone(CreateZoneRequest request);

        /// <summary>
        /// Updates the specified secondary zone with your new external master server information. 
        /// For more information about secondary zone, see Manage DNS Service Zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateZoneResponse UpdateZone(UpdateZoneRequest request);

        /// <summary>
        /// Replaces records in the specified zone with the records specified in the request body. 
        /// If a specified record does not exist, it will be created. If the record exists, then it will be updated to represent the record in the body of the request. 
        /// If a record in the zone does not exist in the request body, the record will be removed from the zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateZoneRecordsResponse UpdateZoneRecords(UpdateZoneRecordsRequest request);

        /// <summary>
        /// Replaces records in the specified zone at a domain with the records specified in the request body. 
        /// If a specified record does not exist, it will be created. If the record exists, then it will be updated to represent the record in the body of the request. 
        /// If a record in the zone does not exist in the request body, the record will be removed from the zone.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDomainRecordsResponse UpdateDomainRecords(UpdateDomainRecordsRequest request);

        /// <summary>
        /// Replaces records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateRRSetResponse UpdateRRSet(UpdateRRSetRequest request);

        /// <summary>
        /// Updates a collection of records in the specified zone. 
        /// You can update one record or all records for the specified zone depending on the changes provided in the request body. 
        /// You can also add or remove records using this function.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PatchZoneRecordsResponse PatchZoneRecords(PatchZoneRecordsRequest request);

        /// <summary>
        /// Updates records in the specified zone at a domain.
        /// You can update one record or all records for the specified zone depending on the changes provided in the request body.
        /// You can also add or remove records using this function.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PatchDomainRecordsResponse PatchDomainRecords(PatchDomainRecordsRequest request);

        /// <summary>
        /// Updates records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PatchRRSetResponse PatchRRSet(PatchRRSetRequest request);

        /// <summary>
        /// Deletes the specified zone and all its steering policy attachments. 
        /// A 204 response indicates that zone has been successfully deleted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteZoneResponse DeleteZone(DeleteZoneRequest request);

        /// <summary>
        /// Deletes all records at the specified zone and domain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteDomainRecordsResponse DeleteDomainRecords(DeleteDomainRecordsRequest request);

        /// <summary>
        /// Deletes all records in the specified RRSet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteRRSetResponse DeleteRRSet(DeleteRRSetRequest request);
    }
}
