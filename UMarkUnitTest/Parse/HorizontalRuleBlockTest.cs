using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UMarkUnitTest.Parse
{
    [TestClass]
    public class HorizontalRuleBlockTest
    {
        [TestMethod]
        public void HorizontalRule_Empty() => UnitBase.Test("* -", "* * -"); // List

        [TestMethod]
        public void HorizontalRule_Text() => UnitBase.Test("hello\r\n---\r\n", "hello\r\n* * * * * ");
    }
}
