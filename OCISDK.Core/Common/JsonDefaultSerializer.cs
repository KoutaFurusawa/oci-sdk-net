using Jil;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// Default JsonSerializer(Jil)
    /// </summary>
    public class JsonDefaultSerializer : IJsonSerializer
    {
        static readonly Options Options = new Options(
            serializationNameFormat: SerializationNameFormat.CamelCase,
            excludeNulls: true
        );

        /// <summary>
        /// deafult Serialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Serialize<T>(T data)
        {
            if (data == null) {
                return null;
            }
            return JSON.Serialize(data, Options);
        }

        /// <summary>
        /// deafault Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public T Deserialize<T>(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return JSON.Deserialize<T>("", Options);
            }
            
            return JSON.Deserialize<T>(text, Options);
        }
    }
}
