using FluentAssertions;
using WonderTools.JsonSectionReader;
using NUnit.Framework;

namespace WonderTools.JsonReaderTests
{
    [TestFixture]
    public class TablePartOfArrayTests
    {
        [Test]
        public void Tests()
        {
            var reader = new JsonSectionReader.JsonSectionReader();
            var actual = reader.Read("TablePartOfArrayTests.json").GetSection("node1", 1).GetTable(typeof(int), typeof(int));
            var expected = reader.Read("TablePartOfArrayTests.json").GetSection("node2").GetTable(typeof(int), typeof(int));
            actual.Should().BeEquivalentTo(expected);
        }
    }
}