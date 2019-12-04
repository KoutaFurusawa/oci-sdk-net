using OCISDK.Core.Common;
using OCISDK.Core.UnpublishedService.Commercial.Model;
using OCISDK.Core.UnpublishedService.Commercial.Request;
using OCISDK.Core.UnpublishedService.Commercial.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial
{
    /// <summary>
    /// Commercial client
    /// 
    /// In the future, these methods will move or change the namespace.
    /// </summary>
    public class CommercialClient : ServiceClient, ICommercialClient
    {
        private readonly string CommercialServiceName = "commercial";
        private readonly string DomainName = "oci.oraclecloud.com";

        /// <summary>
        /// Constructer
        /// </summary>
        public CommercialClient(ClientConfig config) : base(config)
        {
            ServiceName = CommercialServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public CommercialClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CommercialServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public CommercialClient(ClientConfigStream config) : base(config)
        {
            ServiceName = CommercialServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public CommercialClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CommercialServiceName;
        }
        
        /// <summary>
        /// GetPurchaseEntitlements
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListPurchaseEntitlementsResponse ListPurchaseEntitlements(ListPurchaseEntitlementsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CommercialServices.PurchaseEntitlements, this.Region, DomainName)}?compartmentId={request.CompartmentId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListPurchaseEntitlementsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<PurchaseEntitlements>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// ListServiceEntitlementRegistrations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListServiceEntitlementRegistrationsResponse ListServiceEntitlementRegistrations(ListServiceEntitlementRegistrationsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CommercialServices.ServiceEntitlementRegistrations, this.Region, DomainName)}?compartmentId={request.CompartmentId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListServiceEntitlementRegistrationsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<ServiceEntitlementRegistrations>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}
