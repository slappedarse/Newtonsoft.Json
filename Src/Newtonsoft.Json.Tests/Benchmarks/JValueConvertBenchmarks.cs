using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class JValueConvertBenchmarks
    {
        private static readonly JValue StringJValue = new JValue("String!");

        [Benchmark]
        public string JTokenToObjectFast()
        {
            return (string)StringJValue.ToObject(typeof(string));
        }

        [Benchmark]
        public string JTokenToObjectWithSerializer()
        {
            return (string)StringJValue.ToObject(typeof(string), new JsonSerializer());
        }

        [Benchmark]
        public string JTokenToObjectConvert()
        {
            return StringJValue.Value<string>();
        }

        [Benchmark]
        public string JTokenToObjectCast()
        {
            return (string)StringJValue;
        }
    }
}