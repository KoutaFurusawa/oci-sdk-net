using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// RestClient interface
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HttpWebResponse Get(HttpWebRequest request);
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        HttpWebResponse Get(Uri targetUri);
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        HttpWebResponse Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        HttpWebResponse Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, List<string> fields);

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        HttpWebResponse Post(Uri targetUri);
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        HttpWebResponse Post(Uri targetUri, object requestBody);
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        HttpWebResponse Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        HttpWebResponse Put(Uri targetUri);
        /// <summary>
        /// Put
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        HttpWebResponse Put(Uri targetUri, object requestBody);
        /// <summary>
        /// Put
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        HttpWebResponse Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        HttpWebResponse Patch(Uri targetUri);
        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        HttpWebResponse Patch(Uri targetUri, object requestBody);
        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        HttpWebResponse Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        HttpWebResponse Delete(Uri targetUri);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        HttpWebResponse Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        HttpWebResponse Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, object requestBody);

        /// <summary>
        /// Head
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        HttpWebResponse Head(Uri targetUri);
        /// <summary>
        /// Head
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        HttpWebResponse Head(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
    }
}
