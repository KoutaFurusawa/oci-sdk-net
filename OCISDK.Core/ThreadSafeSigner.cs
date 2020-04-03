using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core
{
    /// <summary>
    /// ThreadSafeSigner
    /// </summary>
    public class ThreadSafeSigner : IOciSigner
    {
        private IOciSigner Signer { get; }
        private static readonly Object _syncRoot = new Object();

        /// <summary>
        /// generate signer
        /// </summary>
        /// <param name="signer"></param>
        public ThreadSafeSigner(IOciSigner signer)
        {
            Signer = signer;
        }

        void IOciSigner.SignRequest(HttpWebRequest request, bool useLessHeadersForPut)
        {
            lock (_syncRoot)
                Signer.SignRequest(request, useLessHeadersForPut);
        }
    }
}
