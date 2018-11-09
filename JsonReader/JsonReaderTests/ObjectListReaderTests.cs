using WonderTools.JsonReader;
using NUnit.Framework;

namespace WonderTools.JsonReaderTests
{
    [TestFixture]
    public partial class ObjectListReaderTests
    {
        protected JsonSection GetSection(string name)
        {
            return new JsonSectionReader().Read("ObjectListReaderTests.json", name);
        }
    }
}