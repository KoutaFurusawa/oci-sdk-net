using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace OCISDK.Test.Common
{
    public class ExpandableEnumTest
    {
        /// <summary>
        /// Test ExpandableEnum
        /// </summary>
        public class TestEnum : ExpandableEnum<TestEnum>
        {
            public TestEnum(string value) : base(value) { }

            public static implicit operator TestEnum(string value)
            {
                return Parse(value);
            }

            public static readonly TestEnum ParamA = new TestEnum("ParamA");

            public static readonly TestEnum ParamB = new TestEnum("ParamB");

            public static readonly TestEnum ParamC = new TestEnum("ParamC");
        }

        [Fact]
        public void EqualParamA()
        {
            var param = TestEnum.ParamA;

            Assert.Equal("ParamA", param.Value);
        }

        [Fact]
        public void EqualParamB()
        {
            var param = TestEnum.ParamB;

            Assert.Equal("ParamB", param.Value);
        }

        [Fact]
        public void NotEqual()
        {
            var param = TestEnum.ParamC;

            Assert.NotEqual("ParamA", param.Value);
        }

        [Fact]
        public void ParamAToStringEquals()
        {
            var param = TestEnum.ParamA;

            Assert.Equal("ParamA", param.ToString());
        }

        [Fact]
        public void ParamACompareToEquals()
        {
            var param = TestEnum.ParamA;

            var res = param.CompareTo(TestEnum.ParamA);

            Assert.Equal(0, res);
        }

        [Fact]
        public void ParamBCompareToParamA()
        {
            var param = TestEnum.ParamB;

            var res = param.CompareTo(TestEnum.ParamA);

            Assert.Equal(1, res);
        }

        [Fact]
        public void ParamBCompareToParamC()
        {
            var param = TestEnum.ParamB;

            var res = param.CompareTo(TestEnum.ParamC);

            Assert.Equal(-1, res);
        }

        [Fact]
        public void ParamAEquals()
        {
            var param = TestEnum.ParamA;

            var res = param.Equals(TestEnum.ParamA);

            Assert.True(res);
        }

        [Fact]
        public void ParamANotEquals()
        {
            var param = TestEnum.ParamA;

            var res = param.Equals(TestEnum.ParamB);

            Assert.False(res);
        }

        [Fact]
        public void OperatorTestParamEqualValue()
        {
            var param = TestEnum.ParamA;

            var res = TestEnum.ParamA == param.Value;

            Assert.True(res);
        }

        [Fact]
        public void OperatorTestParamNotEqualValue()
        {
            var param = TestEnum.ParamA;

            var res = TestEnum.ParamB != param.Value;

            Assert.True(res);
        }

        [Fact]
        public void OperatorTestValueEqualParam()
        {
            var param = TestEnum.ParamA;

            var res = param.Value == TestEnum.ParamA;

            Assert.True(res);
        }

        [Fact]
        public void OperatorTestValueNotEqualParam()
        {
            var param = TestEnum.ParamA;

            var res = param.Value != TestEnum.ParamB;

            Assert.True(res);
        }
        
        [Fact]
        public void ValuesCollectionContain()
        {
            var values = TestEnum.GetValues();

            Assert.Contains(TestEnum.ParamA, values);
        }
    }
}