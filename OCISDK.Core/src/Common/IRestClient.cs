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
        HttpWebResponse Get(Uri targetUri, string opcRequestId);
        HttpWebResponse Get(Uri targetUri, string opcClientRequestId, string opcRequestId);
        HttpWebResponse Get(Uri targetUri, string ifMatch, string ifNoneMatch, string opcClientRequestId, List<string> fields, string range, string opcRequestId);
        HttpWebResponse Post(Uri targetUri, Object requestBody = null, string opcRetryToken = "", string opcRequestId = "", string ifMatch = "", string OpcClientRequestId = "");
        HttpWebResponse Put(Uri targetUri, Object requestBody = null, string ifMatch = "", string opcRetryToken = "");
        HttpWebResponse Delete(Uri targetUri, string ifMatch = "", Object requestBody = null, string OpcClientRequestId = "");
        HttpWebResponse Head(Uri targetUri, string ifMatch = "", string ifNoneMatch = "", string OpcClientRequestId = "");
    }
}
