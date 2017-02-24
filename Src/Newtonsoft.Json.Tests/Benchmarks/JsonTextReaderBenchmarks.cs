using System.IO;
using BenchmarkDotNet.Attributes;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class JsonTextReaderBenchmarks
    {
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
    }
}