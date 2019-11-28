using OCISDK.Core.Common;
using OCISDK.Core.Core.Request.Compute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OCISDK.Test.Common
{
    public class EnumParamTest
    {
        [Fact]
        public void OrderByDisplaynameEqualASC()
        {
            var getDisplayname = SortOrder.ASC.Value;

            Assert.Equal("ASC", getDisplayname);
        }

        [Fact]
        public void OrderByDisplaynameEqualDESC()
        {
            var getDisplayname = SortOrder.DESC.Value;

            Assert.Equal("DESC", getDisplayname);
        }
    }
}
