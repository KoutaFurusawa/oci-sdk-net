/// <summary>
/// Rest call client Class
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public class RestClient
    {
        public Signer Signer { get; set; }

        public ClientConfig Config { get; set; }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="TargetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Get(Uri targetUri, string opcRequestId = "") 
        {
            var attempts = 0;
            HttpWebResponse response = new HttpWebResponse();
            while (true)
            {
                var request = (HttpWebRequest)WebRequest.Create(targetUri);
                request.Method = "GET";
                request.Accept = "application/json";

                if (!String.IsNullOrEmpty(opcRequestId))
                {
                    request.Headers["opc-request-id"] = opcRequestId;
                }

                if (Config.Timeout.HasValue)
                {
                    request.Timeout = Config.Timeout.Value;
                }

                if (Config.ReadWriteTimeout.HasValue)
                {
                    request.ReadWriteTimeout = Config.ReadWriteTimeout.Value;
                }

                try
                {
                    Signer.SignRequest(request);

                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException we)
                {
                    if (++attempts < Config.MaxErrorRetry
                        && CanRetryRequestIfRefreshableAuthTokenUsed(we))
                    {
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return response;
        }

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="TargetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri, Object requestBody=null, string opcRetryToken="")
        {
            var attempts = 0;
            HttpWebResponse response = new HttpWebResponse();
            while (true)
            {
                var request = (HttpWebRequest)WebRequest.Create(targetUri);
                request.Method = "POST";
                request.Accept = "application/json";
                request.ContentType = "application/json";

                if (!String.IsNullOrEmpty(opcRetryToken))
                {
                    request.Headers["opc-retry-token"] = opcRetryToken;
                }

                if (requestBody != null)
                {
                    var body = JsonConvert.SerializeObject(
                        requestBody, 
                        new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                    var bytes = Encoding.UTF8.GetBytes(body);

                    request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
                    request.ContentLength = bytes.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }

                try
                {
                    Signer.SignRequest(request);

                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException we)
                {
                    if (++attempts < Config.MaxErrorRetry
                        && CanRetryRequestIfRefreshableAuthTokenUsed(we))
                    {
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            return response;
        }

        /// <summary>
        /// Put a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri, Object requestBody = null, string ifMatch="", string opcRetryToken = "")
        {
            var attempts = 0;
            HttpWebResponse response = new HttpWebResponse();
            HttpWebRequest request = null;
            while (true)
            {
                request = (HttpWebRequest)WebRequest.Create(targetUri);
                request.Method = "PUT";
                request.Accept = "application/json";
                request.ContentType = "application/json";

                if (!String.IsNullOrEmpty(ifMatch))
                {
                    request.Headers["if-match"] = ifMatch;
                }

                if (!String.IsNullOrEmpty(opcRetryToken))
                {
                    request.Headers["opc-retry-token"] = opcRetryToken;
                }

                if (requestBody != null)
                {
                    var body = JsonConvert.SerializeObject(
                        requestBody,
                        new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                    var bytes = Encoding.UTF8.GetBytes(body);

                    request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
                    request.ContentLength = bytes.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }

                try
                {
                    Signer.SignRequest(request);

                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException we)
                {
                    if (++attempts < Config.MaxErrorRetry
                        && CanRetryRequestIfRefreshableAuthTokenUsed(we))
                    {
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            return response;
        }

        /// <summary>
        /// Execute a delete on a resource and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public HttpWebResponse Delete(Uri targetUri, string ifMatch = "", Object requestBody = null)
        {
            var attempts = 0;
            HttpWebResponse response = new HttpWebResponse();
            HttpWebRequest request = null;
            while(true)
            {
                request = (HttpWebRequest)WebRequest.Create(targetUri);
                request.Method = "DELETE";

                if (!String.IsNullOrEmpty(ifMatch))
                {
                    request.Headers["if-match"] = ifMatch;
                }

                if (requestBody != null)
                {
                    var body = JsonConvert.SerializeObject(
                        requestBody,
                        new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                    var bytes = Encoding.UTF8.GetBytes(body);

                    request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
                    request.ContentLength = bytes.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }

                try
                {
                    Signer.SignRequest(request);

                    response = (HttpWebResponse)request.GetResponse();
                    break;
                }
                catch (WebException we)
                {
                    if (++attempts < Config.MaxErrorRetry
                        && CanRetryRequestIfRefreshableAuthTokenUsed(we))
                    {
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return response;
        }

        private bool CanRetryRequestIfRefreshableAuthTokenUsed(WebException we)
        {
            if (we.Status == WebExceptionStatus.ProtocolError)
            {
                var res = (HttpWebResponse)we.Response;
                var response = new StreamReader(res.GetResponseStream()).ReadToEnd();
                Console.WriteLine(response);
                if (res.StatusCode != HttpStatusCode.Unauthorized)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
