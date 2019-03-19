using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Test.Core
{
    public class RestClientMock : RestClient
    {
        public new HttpWebResponse Get(Uri targetUri)
        {
            targetUri = new Uri("http://localhost");

            var maxTries = Config.MaxErrorRetry;

            HttpWebResponse response = new HttpWebResponse();
            Exception exception = null;
            for (var tried = 0; tried < maxTries; ++tried)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(targetUri);
                    request.Method = "GET";
                    request.Accept = "application/json";

                    if (Config.Timeout.HasValue)
                    {
                        request.Timeout = Config.Timeout.Value;
                    }

                    if (Config.ReadWriteTimeout.HasValue)
                    {
                        request.ReadWriteTimeout = Config.ReadWriteTimeout.Value;
                    }

                    Signer.SignRequest(request);

                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException we)
                {
                    exception = we;
                }
                catch (Exception e)
                {
                    exception = e;
                }
            }

            if (exception != null)
            {
                throw exception;
            }

            return response;
        }

        public new HttpWebResponse Post(Uri targetUri, Object requestBody = null, string opcRetryToken = "")
        {
            return null;
        }

        public new HttpWebResponse Put(Uri targetUri, Object requestBody = null, string ifMatch = "", string opcRetryToken = "")
        {
            return null;
        }

        public new HttpWebResponse Delete(Uri targetUri, string ifMatch = "", Object requestBody = null)
        {
            return null;
        }
    }
}
