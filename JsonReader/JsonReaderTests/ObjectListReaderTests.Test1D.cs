using System.Collections.Generic;
using FluentAssertions;
using WonderTools.JsonReader;
using NUnit.Framework;

namespace WonderTools.JsonReaderTests
{
    public partial class ObjectListReaderTests
    {
        public class Test1D : ObjectListReaderTests
        {
            [Test]
            public void Test()
            {
                var section = GetSection("objectList1");
                var result = section.GetTableAsObjectList<Test1, int>((num) => new Test1() { Value = num });
                var expected = GetExpected();
                result.Should().BeEquivalentTo(expected);
            }

            public class Test1
            {
                public int Value { get; set; }
            }

            List<Test1> GetExpected()
            {
                return new List<Test1>()
                {
                    new Test1() { Value = 1, },
                    new Test1() { Value = 2, },
                    new Test1() { Value = 3, },
                };
            }
        }
    }
}