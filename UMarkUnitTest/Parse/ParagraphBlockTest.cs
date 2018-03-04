using Microsoft.VisualStudio.TestTools.UnitTesting;
using UMarkLibrary.Parse;
using UMarkLibrary.Parse.Blocks;
using UMarkLibrary.Parse.Inlines;

namespace UMarkUnitTest.Parse
{
    [TestClass]
    public class ParagraphBlockTest
    {
        [TestMethod]
        public void Paragraph_Empty() => UnitBase.Test("", "");

        [TestMethod]
        public void Paragraph_Text() => UnitBase.Test("Hello\r\n123", "Hello\r\n123");
    }
}
