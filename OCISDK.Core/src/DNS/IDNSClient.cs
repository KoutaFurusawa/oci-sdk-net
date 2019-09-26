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
        /// Deletes the specified zone and all its steering policy attachments. 
        /// A 204 response indicates that zone has been successfully deleted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteZoneResponse DeleteZone(DeleteZoneRequest request);
    }
}
