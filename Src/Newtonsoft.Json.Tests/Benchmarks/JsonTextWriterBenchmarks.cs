using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class JsonTextWriterBenchmarks
    {
        private static readonly string UnicodeCharsString = (new string('\0', 30));

        [Benchmark]
        public string SerializeUnicodeChars()
        {
            StringWriter sw = new StringWriter();
            JsonTextWriter jsonTextWriter = new JsonTextWriter(sw);
            jsonTextWriter.WriteValue(UnicodeCharsString);
            jsonTextWriter.Flush();

            return sw.ToString();
        }
    }
}