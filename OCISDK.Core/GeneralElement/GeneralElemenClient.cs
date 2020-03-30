using OCISDK.Core.Identity;
using OCISDK.Core.ObjectStorage;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.ObjectStorage.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace OCISDK.Core.GeneralElement
{
    /// <summary>
    /// GeneralElemen Client
    /// </summary>
    public class GeneralElemenClient : ServiceClient, IGeneralElemenClient
    {
        private IIdentityClient IdentityClient { get; set; }

        private IObjectStorageClient ObjectStorageClient { get; set; }


        /// <summary>
        /// Constructer
        /// </summary>
        public GeneralElemenClient(ClientConfig config) : base(config)
        {
            IdentityClient = new IdentityClient(config);

            ObjectStorageClient = new ObjectStorageClient(config);
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public GeneralElemenClient(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            IdentityClient = new IdentityClient(config, ociSigner);

            ObjectStorageClient = new ObjectStorageClient(config, ociSigner);
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public GeneralElemenClient(ClientConfigStream config) : base(config)
        {
            IdentityClient = new IdentityClient(config);

            ObjectStorageClient = new ObjectStorageClient(config);
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public GeneralElemenClient(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            IdentityClient = new IdentityClient(config, ociSigner);

            ObjectStorageClient = new ObjectStorageClient(config, ociSigner);
        }

        /// <summary>
        /// Returns the Region the bucket resides in. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<string> GetBucketLocation(GetBucketLocationRequest request)
        {
            ListRegionSubscriptionsRequest listRegionSubscriptionsRequest = new ListRegionSubscriptionsRequest
            { 
                TenancyId = base.Config.TenancyId
            };
            var regions = IdentityClient.ListRegionSubscriptions(listRegionSubscriptionsRequest);

            var nameSpaceName = GetNamespace(request);

            List<string> res = new List<string>();

            foreach (var region in regions.Items)
            {
                ObjectStorageClient.SetRegion(region.RegionName);

                GetBucketRequest getBucketRequest = new GetBucketRequest
                {
                    NamespaceName = nameSpaceName,
                    BucketName = request.BucketName
                };

                try
                {
                    var b = ObjectStorageClient.GetBucket(getBucketRequest);

                    if (b.Bucket != null)
                    {
                        res.Add(region.RegionName);
                    }
                }
                catch (WebException we)
                {
                    if (!(we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound))
                    {
                        throw;
                    }
                }
            }

            if (res.Count <= 0)
            {
                throw new Exception("NoSuchBucket");
            }

            return res;
        }

        private string GetNamespace(GetBucketLocationRequest request)
        {
            string nameSpaceName;
            if (string.IsNullOrEmpty(request.NamespaceName))
            {
                nameSpaceName = ObjectStorageClient.GetNamespace(new GetNamespaceRequest());
            }
            else
            {
                nameSpaceName = request.NamespaceName;
            }

            if (string.IsNullOrEmpty(nameSpaceName))
            {
                throw new Exception("NamespaceNotFound");
            }

            return nameSpaceName;
        }
    }
}
