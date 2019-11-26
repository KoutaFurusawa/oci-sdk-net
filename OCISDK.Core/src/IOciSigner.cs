using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.src
{
    /// <summary>
    /// OciSigner interface
    /// </summary>
    public interface IOciSigner
    {
        /// <summary>
        /// SignRequest
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useLessHeadersForPut"></param>
        void SignRequest(HttpWebRequest request, bool useLessHeadersForPut = false);
    }
}
