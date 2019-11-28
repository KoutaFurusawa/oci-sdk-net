using OCISDK.Core.Common;
using OCISDK.Core.Core.Request.VirtualNetwork;
using OCISDK.Core.Core.Response;
using Xunit;

namespace OCISDK.Test.Core.Request
{
    public class OptionsRequestTest
    {
        /*
        [Fact]
        public void ListDhcpOptionsOptionQuerySuccese()
        {
            ListDhcpOptionsRequest request = new ListDhcpOptionsRequest()
            {
                CompartmentId = "testComp",
                VcnId ="testVCN",
                DisplayName = "testName",
                LifecycleState = LifecycleState.TERMINATED,
                Limit = 10,
                Page = "1",
                SortBy = SortBy.TIMECREATED,
                SortOrder = SortOrder.ASC
            };

            var options = request.GetOptionQuery();

            var answer = "compartmentId=testComp&vcnId=testVCN&displayName=testName&lifecycleState=ACTIVE&limit=10&page=1&sortBy=TIMECREATED&sortOrder=ASC";

            Assert.Equal(answer, options);
        }

        [Fact]
        public void ListRouteTableOptionsOptionQuerySuccese()
        {
            ListRouteTableRequest request = new ListRouteTableRequest()
            {
                CompartmentId = "testComp",
                VcnId = "testVCN",
                DisplayName = "testName",
                LifecycleState = "ACTIVE",
                Limit = 10,
                Page = "1",
                SortBy = SortByParam.TIMECREATED,
                SortOrder = SortOrderParam.ASC
            };

            var options = request.GetOptionQuery();

            var answer = "compartmentId=testComp&vcnId=testVCN&displayName=testName&lifecycleState=ACTIVE&limit=10&page=1&sortBy=TIMECREATED&sortOrder=ASC";

            Assert.Equal(answer, options);
        }

        [Fact]
        public void ListIGOptionsOptionQuerySuccese()
        {
            ListInternetGatewaysRequest request = new ListInternetGatewaysRequest()
            {
                CompartmentId = "testComp",
                VcnId = "testVCN",
                DisplayName = "testName",
                LifecycleState = "ACTIVE",
                Limit = 10,
                Page = "1",
                SortBy = SortByParam.TIMECREATED,
                SortOrder = SortOrderParam.ASC
            };

            var options = request.GetOptionQuery();

            var answer = "compartmentId=testComp&vcnId=testVCN&displayName=testName&lifecycleState=ACTIVE&limit=10&page=1&sortBy=TIMECREATED&sortOrder=ASC";

            Assert.Equal(answer, options);
        }

        [Fact]
        public void ListVcnTableOptionsOptionQuerySuccese()
        {
            ListVcnRequest request = new ListVcnRequest()
            {
                CompartmentId = "testComp",
                DisplayName = "testName",
                LifecycleState = "ACTIVE",
                Limit = 10,
                Page = "1",
                SortBy = SortByParam.TIMECREATED,
                SortOrder = SortOrderParam.ASC
            };

            var options = request.GetOptionQuery();

            var answer = "compartmentId=testComp&displayName=testName&lifecycleState=ACTIVE&limit=10&page=1&sortBy=TIMECREATED&sortOrder=ASC";

            Assert.Equal(answer, options);
        }*/
    }
}
