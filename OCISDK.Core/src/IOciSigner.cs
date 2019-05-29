using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.src
{
    public interface IOciSigner
    {
        void SignRequest(HttpWebRequest request, bool useLessHeadersForPut = false);
    }
}
