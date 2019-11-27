using OCISDK.Core.Common;
using Xunit;

namespace OCISDK.Test.Common
{
    public class OCIDTest
    {
        [Fact]
        public void ValidOcid()
        {
            Assert.True(OCID.IsValid(
                "ocid1.user.oc1..aaaaaaaaizi8k3lbfv747ul6qwazrutncoe8zciazibypbjtkxaiecoic1dq"));
        }

        [Fact]
        public void ValidLegacyOcid()
        {
            Assert.True(OCID.IsValid(
                "ocidv1:tenancy:oc1:phx:1829406592360:aaaaaaaab4faaopv32ecohhklpvjq463pu"));
        }

        [Theory]
        [InlineData("ocid1.user.oc1.")]
        [InlineData("ocid1.user.oc1.adsfasfsafdf")]
        [InlineData("ocid1.user.oc1.1354aasdf.")]
        public void InvalidOcid(string ocid)
        {
            Assert.False(OCID.IsValid(ocid));
        }
    }
}
