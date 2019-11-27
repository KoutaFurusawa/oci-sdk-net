using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// RestClientAsync interface
    /// </summary>
    public interface IRestClientAsync
    {
        /// <summary>
        /// get
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<WebResponse> Get(HttpWebRequest request);
        /// <summary>
        /// get
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        Task<WebResponse> Get(Uri targetUri);
        /// <summary>
        /// get
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        /// <summary>
        /// get
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, List<string> fields);

        /// <summary>
        /// post
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        Task<WebResponse> Post(Uri targetUri);
        /// <summary>
        /// post
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        Task<WebResponse> Post(Uri targetUri, object requestBody);
        /// <summary>
        /// post
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        Task<WebResponse> Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        /// <summary>
        /// put
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        Task<WebResponse> Put(Uri targetUri);
        /// <summary>
        /// put
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        Task<WebResponse> Put(Uri targetUri, object requestBody);
        /// <summary>
        /// put
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        Task<WebResponse> Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        Task<WebResponse> Patch(Uri targetUri);
        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        Task<WebResponse> Patch(Uri targetUri, object requestBody);
        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        Task<WebResponse> Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        Task<WebResponse> Delete(Uri targetUri);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        Task<WebResponse> Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        Task<WebResponse> Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, object requestBody);

        /// <summary>
        /// Head
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        Task<WebResponse> Head(Uri targetUri);
        /// <summary>
        /// Head
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        Task<WebResponse> Head(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
    }
}
