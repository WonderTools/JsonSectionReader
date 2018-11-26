using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests.ObjectListReaderTests
{
    [TestFixture]
    public abstract class ObjectListReaderTests
    {
        protected JSection GetSection(string name)
        {
            return new JSectionReader().Read("ObjectListReaderTests.json").GetSection(name);
        }
    }
}