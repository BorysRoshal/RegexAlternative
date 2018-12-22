using System.Text.RegularExpressions;
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
                .Then.Number.Repeated.ExactlyNTimes(3)
                .Then.WordSymbol.Which.EndOfString.Repeated.AtLeastNTimes(1)
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
                .BeginGroup
                    .String("qwe").Repeated.AtLeastNTimes(3).Then
                    .Number.Then
                .EndGroup.Which.EndOfString.Repeated.ExactlyNTimes(2)
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
                .BeginGroup
                    .Symbols("qwe").Then
                .EndGroup.Repeated.ExactlyNTimes(2)
                .Or
                .BeginGroup
                    .Symbols("asd").Then
                .EndGroup
                .Or
                .AnySymbol
                .ToString();

            //Assert
            Assert.AreEqual(result, @"([qwe]){2}|([asd])|.");
        }
    }
}
