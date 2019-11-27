using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using static OCISDK.Core.Common.ConfigFileReader;

namespace OCISDK.Test.Common
{
    public class ConfigFileReaderTest
    {
        string ConfigPath = "./Resources/config";
        
        [Fact]
        public void NoLeadingFile()
        {
            Assert.Throws<FileNotFoundException>(
                delegate
                {
                    ConfigFile config = ConfigFileReader.Parse("abc");
                }
            );
        }

        [Fact]
        public void NoProfile()
        {
            Assert.Throws<Exception>(
                delegate
                {
                    ConfigFile config = ConfigFileReader.Parse(ConfigPath, "USER_A");
                }
            );
        }

        [Fact]
        public void LineWithNoValue()
        {
            Assert.Throws<KeyNotFoundException>(
                delegate
                {
                    ConfigFile config = ConfigFileReader.Parse(ConfigPath);
                    string tenancy = config.Get("unit_test_no_value_config");
                }
            );
        }

        [Fact]
        public void DefaultTest()
        {
            ConfigFile config = ConfigFileReader.Parse(ConfigPath);
            
            Assert.Equal("ocid1.tenancy.oc1..test", config.Get("tenancy"));
            Assert.Equal("ocid1.user.oc1..test", config.Get("user"));
            Assert.Equal("1a:2b:3c:4d:5e:6f", config.Get("fingerprint"));
            Assert.Equal("~/.oci/api_key.pem", config.Get("key_file"));
            Assert.Equal("ocid1.compartment.oc1..test", config.Get("custom_compartment_id"));
        }

        [Fact]
        public void ProfiletestDEFAULT()
        {
            ConfigFile config = ConfigFileReader.Parse(ConfigPath, "DEFAULT");

            Assert.Equal("ocid1.tenancy.oc1..test", config.Get("tenancy"));
            Assert.Equal("ocid1.user.oc1..test", config.Get("user"));
            Assert.Equal("1a:2b:3c:4d:5e:6f", config.Get("fingerprint"));
            Assert.Equal("~/.oci/api_key.pem", config.Get("key_file"));
            Assert.Equal("ocid1.compartment.oc1..test", config.Get("custom_compartment_id"));
        }


        [Fact]
        public void ProfiletestMyProfile()
        {
            ConfigFile config = ConfigFileReader.Parse(ConfigPath, "myProfile");

            Assert.Equal("ocid1.tenancy.oc1..test", config.Get("tenancy"));
            Assert.Equal("ocid1.user.oc1..myProfile", config.Get("user"));
            Assert.Equal("7g:8h:9i:0j:1k:2l", config.Get("fingerprint"));
            Assert.Equal("~/.oci/my_key.pem", config.Get("key_file"));
            Assert.Equal("ocid1.compartment.oc1..Mytest", config.Get("custom_compartment_id"));
        }
    }
}
