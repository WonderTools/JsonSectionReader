using FluentAssertions;
using JsonReader;
using NUnit.Framework;

namespace JsonReaderTests
{
    [TestFixture]
    public class TablePartOfArrayTests
    {
        [Test]
        public void Tests()
        {
            var reader = new JsonSectionReader();
            var actual = reader.Read("TablePartOfArrayTests.json", "node1", 1).GetTable(typeof(int), typeof(int));
            var expected = reader.Read("TablePartOfArrayTests.json", "node2").GetTable(typeof(int), typeof(int));
            actual.Should().BeEquivalentTo(expected);
        }
    }
}