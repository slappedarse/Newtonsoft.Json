using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
#if DNXCORE50
using Xunit;
using Test = Xunit.FactAttribute;
using Assert = Newtonsoft.Json.Tests.XUnitAssert;
#else
using NUnit.Framework;

#endif

namespace Newtonsoft.Json.Tests.Benchmarks
{
    [TestFixture]
    public class Runner : TestFixtureBase
    {
        [Test]
        [Ignore("Don't run with other unit tests")]
        public void RunBenchmarks()
        {
            new BenchmarkSwitcher(typeof(Runner).GetTypeInfo().Assembly).Run(new []{ "*" });
        }
    }
}
