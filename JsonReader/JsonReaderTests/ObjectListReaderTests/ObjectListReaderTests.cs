using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonReaderTests.ObjectListReaderTests
{
    [TestFixture]
    public abstract class ObjectListReaderTests
    {
        protected JsonSection GetSection(string name)
        {
            return new JsonSectionReader.JsonSectionReader().Read("ObjectListReaderTests.json").GetSection(name);
        }
    }
}