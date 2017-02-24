using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class DeserializeBenchmarks
    {
        private static readonly string LargeJson;
        private static readonly string DoubleArrayJson;

        static DeserializeBenchmarks()
        {
            LargeJson = System.IO.File.ReadAllText("large.json");

            DoubleArrayJson = new JArray(Enumerable.Range(0, 5000).Select(i => (double)i)).ToString(Formatting.None);
        }

        [Benchmark]
        public IList<PerformanceTests.RootObject> DeserializeLargeJson()
        {
            return JsonConvert.DeserializeObject<IList<PerformanceTests.RootObject>>(LargeJson);
        }

        [Benchmark]
        public IList<double> DeserializeDoubleList()
        {
            return JsonConvert.DeserializeObject<IList<double>>(DoubleArrayJson);
        }
    }
}