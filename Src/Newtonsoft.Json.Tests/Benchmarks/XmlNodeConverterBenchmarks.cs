using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class XmlNodeConverterBenchmarks
    {
        [Benchmark]
        public void ConvertXmlNode()
        {
            XmlDocument doc = new XmlDocument();
            using (FileStream file = System.IO.File.OpenRead("large_sample.xml"))
            {
                doc.Load(file);
            }

            JsonConvert.SerializeXmlNode(doc);
        }

        [Benchmark]
        public void ConvertXNode()
        {
            XDocument doc;
            using (FileStream file = System.IO.File.OpenRead("large_sample.xml"))
            {
                doc = XDocument.Load(file);
            }

            JsonConvert.SerializeXNode(doc);
        }
    }
}