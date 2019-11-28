using System;
using Xunit;

using OCISDK.Core;

namespace OCISDK.Test
{
    public class ClientConfigTest
    {
        ClientConfig Config;

        public ClientConfigTest()
        {
            Config = new ClientConfig();
        }

        [Theory]
        [InlineData("phx", "us-phoenix-1")]
        [InlineData("iad", "us-ashburn-1")]
        [InlineData("fra", "eu-frankfurt-1")]
        [InlineData("lhr", "uk-london-1")]
        [InlineData("yyz", "ca-toronto-1")]
        public void CheckRegionName(string regionShortName, string reshionName)
        {
            var re = Config.GetRegionName(regionShortName);

            Assert.Equal(reshionName, re);
        }
        
        [Fact]
        public void ServiceVersion()
        {
            var phoenix = Config.GetServiceVersion("core");

            Assert.Equal("20160918", phoenix);
        }

        [Theory]
        [InlineData("us-phoenix-1", "iaas.us-phoenix-1.oraclecloud.com")]
        [InlineData("us-ashburn-1", "iaas.us-ashburn-1.oraclecloud.com")]
        [InlineData("eu-frankfurt-1", "iaas.eu-frankfurt-1.oraclecloud.com")]
        [InlineData("uk-london-1", "iaas.uk-london-1.oraclecloud.com")]
        [InlineData("ca-toronto-1", "iaas.ca-toronto-1.oraclecloud.com")]
        public void CheckHostname(string region, string hostname)
        {
            var hn = Config.GetHostName("core", region);

            Assert.Equal(hostname, hn);
        }

        [Theory]
        [InlineData("us-phoenix-1", true)]
        [InlineData("us-ashburn-1", true)]
        [InlineData("eu-frankfurt-1", true)]
        [InlineData("uk-london-1", true)]
        [InlineData("ca-toronto-1", true)]
        [InlineData("us-langley-1", false)]
        public void ContainRegionName(string region, bool result)
        {
            var res = Config.ContainRegion(region);

            Assert.Equal(res, result);
        }
    }
}
