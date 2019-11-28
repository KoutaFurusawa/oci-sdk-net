using OCISDK.Core.Common;
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
        public void Equal_ParamA()
        {
            var param = TestEnum.ParamA;

            Assert.Equal("ParamA", param.Value);
        }

        [Fact]
        public void Equal_ParamB()
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
        public void Equal_ToString()
        {
            var param = TestEnum.ParamA;

            Assert.Equal("ParamA", param.ToString());
        }

        [Fact]
        public void CompareTo_Equivalent()
        {
            var param = TestEnum.ParamA;

            var res = param.CompareTo(TestEnum.ParamA);

            Assert.Equal(0, res);
        }

        [Fact]
        public void CompareTo_TargetToFront()
        {
            var param = TestEnum.ParamB;

            var res = param.CompareTo(TestEnum.ParamA);

            Assert.Equal(1, res);
        }

        [Fact]
        public void CompareTo_TargetToBack()
        {
            var param = TestEnum.ParamB;

            var res = param.CompareTo(TestEnum.ParamC);

            Assert.Equal(-1, res);
        }

        [Fact]
        public void Equals_True()
        {
            var param = TestEnum.ParamA;

            var res = param.Equals(TestEnum.ParamA);

            Assert.True(res);
        }

        [Fact]
        public void Equals_False()
        {
            var param = TestEnum.ParamA;

            var res = param.Equals(TestEnum.ParamB);

            Assert.False(res);
        }

        [Fact]
        public void Equal_Null()
        {
            var param = TestEnum.ParamA;

            var res = param.Equals(null);

            Assert.False(res);
        }


        [Fact]
        public void OperatorEqual_True()
        {
            var param = TestEnum.ParamA;

            var res = TestEnum.ParamA == param.Value;

            Assert.True(res);
        }

        [Fact]
        public void OperatorNotEqual_True()
        {
            var param = TestEnum.ParamA;

            var res = TestEnum.ParamB != param.Value;

            Assert.True(res);
        }

        [Fact]
        public void OperatorNotEqual_False()
        {
            var param = TestEnum.ParamA;

            var res = TestEnum.ParamA != param.Value;

            Assert.False(res);
        }


        [Fact]
        public void OperatorEqual_ValueToParam_True()
        {
            var param = TestEnum.ParamA;

            var res = param.Value == TestEnum.ParamA;

            Assert.True(res);
        }

        [Fact]
        public void OperatorNotEqual_ValueToParam_True()
        {
            var param = TestEnum.ParamA;

            var res = param.Value != TestEnum.ParamB;

            Assert.True(res);
        }

        [Fact]
        public void OperatorNotEqual_ValueToParam_False()
        {
            var param = TestEnum.ParamA;

            var res = param.Value != TestEnum.ParamA;

            Assert.False(res);
        }

        [Fact]
        public void Parse_True()
        {
            var res = TestEnum.Parse("ParamA");

            Assert.Equal(TestEnum.ParamA, res);
        }

        [Fact]
        public void Parse_Exception()
        {
            Assert.Throws<InvalidCastException>(()=> TestEnum.Parse("ParamD"));
        }

        [Fact]
        public void Contain_True()
        {
            var values = TestEnum.GetValues();

            Assert.Contains(TestEnum.ParamA, values);
        }
    }
}