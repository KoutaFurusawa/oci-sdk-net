using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T data);

        T Deserialize<T>(string text);
    }
}
