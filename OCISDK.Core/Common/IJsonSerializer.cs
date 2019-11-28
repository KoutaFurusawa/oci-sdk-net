using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// JsonSerializer
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        string Serialize<T>(T data);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        T Deserialize<T>(string text);
    }
}
