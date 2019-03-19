using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core.Request.Compute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OCISDK.Test.Common
{
    public class EnumAttributeTest
    {
        [Theory]
        [InlineData(SortBy.ID, "ID")]
        [InlineData(SortBy.TIMECREATED, "TIMECREATED")]
        [InlineData(SortBy.DISPLAYNAME, "DISPLAYNAME")]
        public void SortByDisplayname(SortBy sortBy, string displayname)
        {
            var getDisplayname = EnumAttribute.GetDisplayName(sortBy);

            Assert.Equal(displayname, getDisplayname);
        }

        [Theory]
        [InlineData(SortOrder.ASC, "ASC")]
        [InlineData(SortOrder.DESC, "DESC")]
        public void OrderByDisplayname(SortOrder order, string displayname)
        {
            var getDisplayname = EnumAttribute.GetDisplayName(order);

            Assert.Equal(displayname, getDisplayname);
        }

        [Theory]
        [InlineData(ServerType.VcnLocal, "VcnLocal")]
        [InlineData(ServerType.CustomDnsServer, "CustomDnsServer")]
        [InlineData(ServerType.VcnLocalPlusInternet, "VcnLocalPlusInternet")]
        public void ServerTypeTest(ServerType type, string displayname)
        {
            var getDisplayname = EnumAttribute.GetDisplayName(type);

            Assert.Equal(displayname, getDisplayname);
        }
        
        [Theory]
        [InlineData(ListInstancesRequest.LifecycleStates.CREATING_IMAGE, "CREATING_IMAGE")]
        [InlineData(ListInstancesRequest.LifecycleStates.PROVISIONING, "PROVISIONING")]
        [InlineData(ListInstancesRequest.LifecycleStates.RUNNING, "RUNNING")]
        [InlineData(ListInstancesRequest.LifecycleStates.STARTING, "STARTING")]
        [InlineData(ListInstancesRequest.LifecycleStates.STOPPED, "STOPPED")]
        [InlineData(ListInstancesRequest.LifecycleStates.STOPPING, "STOPPING")]
        [InlineData(ListInstancesRequest.LifecycleStates.TERMINATED, "TERMINATED")]
        [InlineData(ListInstancesRequest.LifecycleStates.TERMINATING, "TERMINATING")]
        public void LifecycleStateTest(ListInstancesRequest.LifecycleStates type, string displayname)
        {
            var getDisplayname = EnumAttribute.GetDisplayName(type);

            Assert.Equal(displayname, getDisplayname);
        }

        [Fact]
        public void SortNotFound()
        {
            var sortbyDiscription = EnumAttribute.GetDisplayName(9999);

            Assert.Equal("", sortbyDiscription);
        }
    }
}
