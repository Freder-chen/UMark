using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UMarkUnitTest.Parse
{
    [TestClass]
    public class ListBlockText
    {
        [TestMethod]
        public void List_Empty() => UnitBase.Test("* ", "* ");

        [TestMethod]
        public void List_Text() => UnitBase.Test("List1\r\nList2", "* List1\r\n* List2");
    }
}
