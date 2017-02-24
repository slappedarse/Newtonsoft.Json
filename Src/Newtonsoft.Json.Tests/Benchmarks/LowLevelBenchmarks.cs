using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Tests.Benchmarks
{
    public class LowLevelBenchmarks
    {
        [Benchmark]
        public void DecimalTryParse()
        {
            decimal value;
            decimal.TryParse("100.1", NumberStyles.Number | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out value);
        }

        [Benchmark]
        public void WriteEscapedJavaScriptString()
        {
            string text = @"The general form of an HTML element is therefore: <tag attribute1=""value1"" attribute2=""value2"">content</tag>.
Some HTML elements are defined as empty elements and take the form <tag attribute1=""value1"" attribute2=""value2"" >.
Empty elements may enclose no content, for instance, the BR tag or the inline IMG tag.
The name of an HTML element is the name used in the tags.
Note that the end tag's name is preceded by a slash character, ""/"", and that in empty elements the end tag is neither required nor allowed.
If attributes are not mentioned, default values are used in each case.

The general form of an HTML element is therefore: <tag attribute1=""value1"" attribute2=""value2"">content</tag>.
Some HTML elements are defined as empty elements and take the form <tag attribute1=""value1"" attribute2=""value2"" >.
Empty elements may enclose no content, for instance, the BR tag or the inline IMG tag.
The name of an HTML element is the name used in the tags.
Note that the end tag's name is preceded by a slash character, ""/"", and that in empty elements the end tag is neither required nor allowed.
If attributes are not mentioned, default values are used in each case.

The general form of an HTML element is therefore: <tag attribute1=""value1"" attribute2=""value2"">content</tag>.
Some HTML elements are defined as empty elements and take the form <tag attribute1=""value1"" attribute2=""value2"" >.
Empty elements may enclose no content, for instance, the BR tag or the inline IMG tag.
The name of an HTML element is the name used in the tags.
Note that the end tag's name is preceded by a slash character, ""/"", and that in empty elements the end tag is neither required nor allowed.
If attributes are not mentioned, default values are used in each case.
";

            using (StringWriter w = StringUtils.CreateStringWriter(text.Length))
            {
                char[] buffer = null;
                JavaScriptUtils.WriteEscapedJavaScriptString(w, text, '"', true, JavaScriptUtils.DoubleQuoteCharEscapeFlags, StringEscapeHandling.Default, null, ref buffer);
            }
        }
    }
}
