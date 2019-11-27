using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OCISDK.Test.Common
{
    public class JsonDefaultSerializerTest
    {
        IJsonSerializer JsonSerializer;

        public JsonDefaultSerializerTest() {
            this.JsonSerializer = new JsonDefaultSerializer();
        }

        // Serializa class model to text Test
        [Fact]
        void SerializaSimpleTest() {
            var model = new TestModels() {
                Name = "John",
                Countury = "Japan"
            };
            var res = this.JsonSerializer.Serialize(model);

            Assert.Equal("{\"countury\":\"Japan\",\"name\":\"John\"}", res);
        }

        // Deserialize class test to model Test
        [Fact]
        void DeserializeSimpleTest()
        {
            var text = "{\"countury\":\"Japan\",\"name\":\"John\"}";

            var res = this.JsonSerializer.Deserialize<TestModels>(text);

            Assert.Equal("John",res.Name);
            Assert.Equal("Japan", res.Countury);

        }

        // null empty json test
        [Fact]
        void SerializaNullableTest()
        {
            var model = new TestModels()
            {
                Name = "John",
                Countury = null
            };
            var res = this.JsonSerializer.Serialize(model);

            Assert.Equal("{\"name\":\"John\"}", res);
        }

        // empty not Deserialize test
        [Fact]
        void DeserializeNullableTest()
        {
            var text = "{\"name\":\"John\"}";

            var res = this.JsonSerializer.Deserialize<TestModels>(text);

            Assert.Equal("John", res.Name);
            Assert.Null(res.Countury);

        }

        // SubModel calss Serializa
        [Fact]
        void SerializaSubModelTest()
        {
            var model = new TestModels()
            {
                Name = "John",
                Countury = "Japan",
                SubInfo = new SubModel() {
                    Company = "SmithCompany",
                    Department = "Development"
                }
            };
            var res = this.JsonSerializer.Serialize(model);

            Assert.Equal(
                "{\"subInfo\":{\"department\":\"Development\",\"company\":\"SmithCompany\"},\"countury\":\"Japan\",\"name\":\"John\"}",
                res);
        }

        // SubModel calss Deserialize
        [Fact]
        void DeserializeSubModelTest()
        {
            var text = "{\"subInfo\":{\"department\":\"Development\",\"company\":\"SmithCompany\"},\"countury\":\"Japan\",\"name\":\"John\"}";

            var res = this.JsonSerializer.Deserialize<TestModels>(text);

            Assert.Equal("John", res.Name);
            Assert.Equal("Japan", res.Countury);
            Assert.Equal("SmithCompany", res.SubInfo.Company);
            Assert.Equal("Development", res.SubInfo.Department);

        }

        private class TestModels
        {
            public string Name { get; set; }

            public string Countury { get; set; }

            public SubModel SubInfo { get; set; }
        }

        private class SubModel
        {
            public string Company { get; set; }

            public string Department { get; set; }
        }
    }
}
