using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexAlternative;

namespace RegexAlternativeTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test1()
        {
            //Act
            var regexBuilder = RegexBuilder.Create();

            var result = regexBuilder
                .Symbols("a-z").WhichStartOfString
                .Then.Number.Repeated.NTimes(3)
                .Then.TextSymbol.WhichEndOfString.Repeated.FromNTimes(1)
                .ToString();

            //Assert
            Assert.AreEqual(result, @"^[a-z]\d{3}\w+$");
        }

        [TestMethod]
        public void Test2()
        {
            //Act
            var regexBuilder = RegexBuilder.Create();

            var result = regexBuilder
                .Symbols("a-z")
                .Then.Group.Symbols("qwe").Repeated.FromNTimes(3)
                .Then.Number.Repeated.NTimes(1)
                .Then.EndOfGroup.WhichEndOfString.Repeated.NTimes(2)
                .ToString();

            //Assert
            Assert.AreEqual(result, @"[a-z]([qwe]{3,}\d{1}){2}$");
        }
    }
}
