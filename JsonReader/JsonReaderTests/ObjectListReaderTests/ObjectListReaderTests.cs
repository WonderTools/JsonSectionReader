using NUnit.Framework;
using WonderTools.JsonReader;

namespace WonderTools.JsonReaderTests.ObjectListReaderTests
{
    [TestFixture]
    public abstract class ObjectListReaderTests
    {
        protected JsonSection GetSection(string name)
        {
            return new JsonSectionReader().Read("ObjectListReaderTests.json").GetSection(name);
        }
    }
}