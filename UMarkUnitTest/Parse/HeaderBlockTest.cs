using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UMarkUnitTest.Parse
{
    [TestClass]
    public class HeaderBlockTest
    {
        [TestMethod]
        public void Header_Empty() => UnitBase.Test("# ", "# ");

        [TestMethod]
        public void Header_Text() => UnitBase.Test("123", "## 123");
    }
}
