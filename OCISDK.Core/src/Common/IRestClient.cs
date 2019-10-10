using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public interface IRestClient
    {
        HttpWebResponse Get(HttpWebRequest request);
        HttpWebResponse Get(Uri targetUri);
        HttpWebResponse Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        HttpWebResponse Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, List<string> fields);

        HttpWebResponse Post(Uri targetUri);
        HttpWebResponse Post(Uri targetUri, object requestBody);
        HttpWebResponse Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        HttpWebResponse Put(Uri targetUri);
        HttpWebResponse Put(Uri targetUri, object requestBody);
        HttpWebResponse Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);

        HttpWebResponse Patch(Uri targetUri);
        HttpWebResponse Patch(Uri targetUri, object requestBody);
        HttpWebResponse Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam);
        
        HttpWebResponse Delete(Uri targetUri);
        HttpWebResponse Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
        HttpWebResponse Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, object requestBody);

        HttpWebResponse Head(Uri targetUri);
        HttpWebResponse Head(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam);
    }
}
