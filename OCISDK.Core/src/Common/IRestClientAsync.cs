using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Common
{
    public interface IRestClientAsync
    {
        Task<WebResponse> Get(HttpWebRequest request);
        Task<WebResponse> Get(Uri targetUri);
        Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, List<string> fields);

        Task<WebResponse> Post(Uri targetUri);
        Task<WebResponse> Post(Uri targetUri, object requestBody);
        Task<WebResponse> Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        Task<WebResponse> Put(Uri targetUri);
        Task<WebResponse> Put(Uri targetUri, object requestBody);
        Task<WebResponse> Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        Task<WebResponse> Patch(Uri targetUri);
        Task<WebResponse> Patch(Uri targetUri, object requestBody);
        Task<WebResponse> Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        Task<WebResponse> Delete(Uri targetUri);
        Task<WebResponse> Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        Task<WebResponse> Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, object requestBody);

        Task<WebResponse> Head(Uri targetUri);
        Task<WebResponse> Head(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
    }
}
