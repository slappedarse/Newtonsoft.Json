using System.IO;
using System.Linq;
using System.Xml;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class JsonTextReaderBenchmarks
    {
        private static readonly string FloatArrayJson;

        static JsonTextReaderBenchmarks()
        {
            FloatArrayJson = new JArray(Enumerable.Range(0, 5000).Select(i => i * 1.1m)).ToString(Formatting.None);
        }

        [Benchmark]
        public void ReadLargeJson()
        {
            using (StreamReader fs = System.IO.File.OpenText("large.json"))
            using (JsonTextReader jsonTextReader = new JsonTextReader(fs))
            {
                while (jsonTextReader.Read())
                {
                }
            }
        }

        [Benchmark]
        public void ReadAsDecimal()
        {
            using (JsonTextReader jsonTextReader = new JsonTextReader(new StringReader(FloatArrayJson)))
            {
                jsonTextReader.Read();

                while (jsonTextReader.ReadAsDecimal() != null)
                {
                }
            }
        }

        [Benchmark]
        public void ReadAsDecimalOld()
        {
            using (JsonTextReaderOld jsonTextReader = new JsonTextReaderOld(new StringReader(FloatArrayJson)))
            {
                jsonTextReader.Read();

                while (jsonTextReader.ReadAsDecimal() != null)
                {
                }
            }
        }
    }
}