using Newtonsoft.Json;
using System.IO;

namespace Example
{
    public class PropartyFileReader
    {
        public ConfigFileProparty Proparty;

        private string ConfigFileName;

        public PropartyFileReader(string environmentName)
        {
            ConfigFileName = $"ExampleConfig.{environmentName}.json";

            JsonSerializer serializer = new JsonSerializer();
            string assemblyLocation = typeof(PropartyFileReader).Assembly.Location;
            string endpointsPath = Path.Combine(Path.GetDirectoryName(assemblyLocation), ConfigFileName);
            if (File.Exists(endpointsPath))
            {
                using (FileStream s = File.Open(endpointsPath, FileMode.Open))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            Proparty = serializer.Deserialize<ConfigFileProparty>(reader);
                        }
                    }
                }
            }
        }
    }

    public class ConfigFileProparty
    {
        public string TenancyId { get; set; }

        public string UserId { get; set; }

        public string Fingerprint { get; set; }

        public string PrivateKeyPath { get; set; }

        public string PrivateKeyPassphrase { get; set; }
    }
}
