/// <summary>
/// ConfigFileReader Class
/// 
/// author: koutaro furusawa
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public static class ConfigFileReader
    {
        /// <summary>
        /// Default location of the config file.
        /// </summary>
        public static readonly string DEFAULT_FILE_PATH = "~/.oci/config";

        /// <summary>
        /// The fallback default location of the config file. If and only if the DEFAULT_FILE_PATH
        /// does not exist, this fallback default location will be used.
        /// </summary>
        public static readonly string FALLBACK_DEFAULT_FILE_PATH = "~/.oraclebmc/config";
        
        private static readonly string DEFAULT_PROFILE_NAME = "DEFAULT";

        /// <summary>
        /// Creates a new ConfigFile instance using the configuration at the default location,
        /// using the default profile.
        /// </summary>
        /// <returns></returns>
        public static ConfigFile ParseDefault()
        {
            return ParseDefault(null);
        }

        /// <summary>
        /// Creates a new ConfigFile instance using the configuration at the default location,
        /// using the given profile.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static ConfigFile ParseDefault(string profile)
        {
            string effectiveFile = null;

            if (File.Exists(DEFAULT_FILE_PATH)) {
                effectiveFile = DEFAULT_FILE_PATH;
            } else if (File.Exists(FALLBACK_DEFAULT_FILE_PATH)) {
                effectiveFile = FALLBACK_DEFAULT_FILE_PATH;
            }

            if (effectiveFile != null) {
                Console.WriteLine($"Loading config file from: {effectiveFile}");
                //LOG.debug("Loading config file from: {}", effectiveFile);
                return Parse(effectiveFile, profile);
            } else {
                throw new Exception(
                    $"Can't load the default config from " +
                    $"{DEFAULT_FILE_PATH} or " +
                    $"{FALLBACK_DEFAULT_FILE_PATH} because it does not exist or it is not a file.");
            }
        }

        /// <summary>
        /// Create a new instance using a file at a given location.
        /// This method is the same as calling parse(String, String) with "DEFAULT" as the profile.
        /// </summary>
        /// <param name="configurationFilePath"></param>
        /// <returns></returns>
        public static ConfigFile Parse(string configurationFilePath)
        {
            return Parse(configurationFilePath, null);
        }

        /// <summary>
        /// Create a new instance using an UTF-8 input stream.
        /// </summary>
        /// <param name="configurationFilePath"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static ConfigFile Parse(string configurationFilePath, string profile)
        {
            return Parse(configurationFilePath, profile, Encoding.UTF8);
        }

        /// <summary>
        /// Create a new instance using an input stream.
        /// </summary>
        /// <param name="ConfigurationStream"></param>
        /// <param name="profile"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static ConfigFile Parse(string configurationFilePath, string profile, Encoding encoding)
        {
            ConfigAccumulator accumulator = new ConfigAccumulator();
            try
            {
                using (StreamReader ConfigurationStream = new StreamReader(configurationFilePath, encoding))
                {
                    string line = null;
                    while ((line = ConfigurationStream.ReadLine()) != null)
                    {
                        accumulator.Accept(line);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!accumulator.FoundDefaultProfile) {
                Console.WriteLine("No DEFAULT profile was specified in the configuration");
                //LOG.info("No DEFAULT profile was specified in the configuration");
            }
            if (profile != null && !accumulator.ConfigurationByProfile.ContainsKey(profile)) {
                throw new Exception($"No profile named {profile} exists in the configuration file");
            }

            return new ConfigFile(accumulator, profile);
        }   

        /// <summary>
        /// ConfigFile represents a simple lookup mechanism for a OCI config file.
        /// </summary>
        public class ConfigFile
        {
            private ConfigAccumulator Accumulator;
            private readonly string Profile;

            public ConfigFile(ConfigAccumulator accumulator, string profile)
            {
                Accumulator = accumulator;
                Profile = profile;
            }

            public string Get(string key)
            {
                if (Profile != null && (Accumulator.ConfigurationByProfile[Profile].ContainsKey(key)))
                {
                    return Accumulator.ConfigurationByProfile[Profile][key];
                }
                return Accumulator.FoundDefaultProfile ?
                        Accumulator.ConfigurationByProfile[DEFAULT_PROFILE_NAME][key]
                        : null;
            }
        }

        public class ConfigAccumulator
        {
            public Dictionary<string, Dictionary<string, string>> ConfigurationByProfile 
                = new Dictionary<string, Dictionary<string, string>>();

            public string CurrentProfile = null;
            public bool FoundDefaultProfile = false;

            public void Accept(string line)
            {
                string trimmedLine = line.Trim();

                // no blank
                if (string.IsNullOrEmpty(trimmedLine))
                {
                    return;
                }

                // skip comment
                if (trimmedLine.ToCharArray()[0] == '#')
                {
                    return;
                }

                // tag
                if (trimmedLine.ToCharArray()[0] == '[' &&
                    trimmedLine.ToCharArray()[trimmedLine.Length - 1] == ']')
                {
                    CurrentProfile = trimmedLine.Substring(1, (trimmedLine.Length - 1)-1).Trim();
                    if (string.IsNullOrEmpty(CurrentProfile))
                    {
                        throw new Exception("Cannot have empty profile name: " + line);
                    }
                    if (CurrentProfile.Equals(DEFAULT_PROFILE_NAME))
                    {
                        FoundDefaultProfile = true;
                    }
                    if (!ConfigurationByProfile.ContainsKey(CurrentProfile))
                    {
                        ConfigurationByProfile.Add(CurrentProfile, new Dictionary<string, string>());
                    }

                    return;
                }

                int splitIndex = trimmedLine.IndexOf('=');
                if (splitIndex == -1)
                {
                    throw new Exception("Found line with no key-value pair: " + line);
                }

                string key = trimmedLine.Substring(0, splitIndex).Trim();
                string value = trimmedLine.Substring(splitIndex + 1).Trim();
                if (string.IsNullOrEmpty(key))
                {
                    throw new Exception("Found line with no key: " + line);
                }
                
                if (CurrentProfile == null)
                {
                    throw new Exception("Config parse error, attempted to read configuration without specifying a profile: "
                                    + line);
                }

                ConfigurationByProfile[CurrentProfile].Add(key, value);
            }
        }
    }

}
