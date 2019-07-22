using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public interface IRestClient
    {
        HttpWebResponse Get(HttpWebRequest request);
        HttpWebResponse Get(Uri targetUri, string opcRequestId = "");
        HttpWebResponse GetIfMatch(Uri targetUri, string opcClientRequestId = "");
        HttpWebResponse GetIfMatch(Uri targetUri, string ifMatch = "", string ifNoneMatch = "", string opcClientRequestId = "", List<string> fields = null, string range = "");
        HttpWebResponse Post(Uri targetUri, Object requestBody = null, string opcRetryToken = "");
        HttpWebResponse Put(Uri targetUri, Object requestBody = null, string ifMatch = "", string opcRetryToken = "");
        HttpWebResponse Delete(Uri targetUri, string ifMatch = "", Object requestBody = null);
    }
}
