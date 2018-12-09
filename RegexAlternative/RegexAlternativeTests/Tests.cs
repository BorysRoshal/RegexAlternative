using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegexAlternative;

namespace RegexAlternativeTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestSymbols()
        {
            //Act
            var regexBuilder = RegexBuilder.Create();

            var result = regexBuilder
                .Symbols("a-z").Which.StartOfString
                .Then.Number.Repeated.NTimes(3)
                .Then.TextSymbol.Which.EndOfString.Repeated.FromNTimes(1)
                .ToString();

            //Assert
            Assert.AreEqual(result, @"^[a-z]\d{3}\w+$");
        }

        [TestMethod]
        public void TestGroup()
        {
            //Act
            var regexBuilder = RegexBuilder.Create();

            var result = regexBuilder
                .Symbols("a-z").Which.StartOfString.Then
                .Group
                    .String("qwe").Repeated.FromNTimes(3).Then
                    .Number.Then
                .EndOfGroup.Which.EndOfString.Repeated.NTimes(2)
                .ToString();

            //Assert
            Assert.AreEqual(result, @"^[a-z]((?:qwe){3,}\d){2}$");
        }

        [TestMethod]
        public void TestOr()
        {
            //Act
            var regexBuilder = RegexBuilder.Create();

            var result = regexBuilder
                .Group
                    .Symbols("qwe").Then
                .EndOfGroup.Repeated.NTimes(2).Or
                .Group
                    .Symbols("asd").Then
                .EndOfGroup.Or
                .AnySymbol
                .ToString();

            //Assert
            Assert.AreEqual(result, @"([qwe]){2}|([asd])|.");
        }
    }
}
