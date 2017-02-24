using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class LargeJArrayBenchmarks
    {
        private JArray _largeJArraySample;

        [Setup]
        public void SetupData()
        {
            _largeJArraySample = new JArray();
            for (int i = 0; i < 100000; i++)
            {
                _largeJArraySample.Add(i);
            }
        }

        [Benchmark]
        public string JTokenPathFirstItem()
        {
            JToken first = _largeJArraySample.First;

            return first.Path;
        }

        [Benchmark]
        public string JTokenPathLastItem()
        {
            JToken last = _largeJArraySample.Last;

            return last.Path;
        }

        [Benchmark]
        public void AddPerformance()
        {
            _largeJArraySample.Add(1);
            _largeJArraySample.RemoveAt(_largeJArraySample.Count - 1);
        }
    }
}