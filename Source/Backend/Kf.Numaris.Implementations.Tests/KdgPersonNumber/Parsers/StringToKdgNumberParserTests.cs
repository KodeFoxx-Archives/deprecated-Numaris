using System.Collections.Generic;
using Kf.Numaris.Implementations.KdgPersonNumber.Parsing;
using Xunit;

namespace Kf.Numaris.Implementations.Tests.KdgPersonNumber.Parsers
{
    public class StringToKdgNumberParserTests
    {
        public static IEnumerable<object[]> Returns_correct_parsed_string_array_given_TestData()
        {
            yield return new object[] {
                "Number is given",
                "0033311-40",
                new [] { "0033311", "40" }
            };

            yield return new object[] {
                "Number is given without padding",
                "33311-40",
                new [] { "33311", "40" }
            };

            yield return new object[] {
                "Number is given without seperator",
                "003331140",
                new [] { "0033311", "40" }
            };

            yield return new object[] {
                "Number is given without seperator and without padding",
                "3331140",
                new [] { "33311", "40" }
            };

            yield return new object[] {
                "Number of three characters long is given",
                "140",
                new [] { "1", "40" }
            };

            yield return new object[] {
                "Number is given with spaces around",
                " 0033311-40  ",
                new [] { "0033311", "40" }
            };

            yield return new object[] {
                "Number is given with spaces around and in between",
                " 0033 311  -4 0  ",
                new [] { "0033311", "40" }
            };

            yield return new object[] {
                "Number is given without padding and with spaces around and in between",
                " 33311-40  ",
                new [] { "33311", "40" }
            };

            yield return new object[] {
                "Number is given without padding and with spaces around and in between",
                " 33  31 1 -4  0  ",
                new [] { "33311", "40" }
            };
        }

        [Theory,
         MemberData(nameof(Returns_correct_parsed_string_array_given_TestData))]
        public void Returns_correct_parsed_string_array_given(string scenario, string input, string[] expected)
        {
            var sut = new StringToKdgNumberParser();
            var actual = sut.Parse(input);
            Assert.Equal(expected, actual);
        }

        [Theory,
         InlineData(null),
         InlineData(""),
         InlineData("  ")]
        public void Returns_zeroes_when_string_is_null_whitespace_or_empty(string input)
        {
            var sut = new StringToKdgNumberParser();
            var actual = sut.Parse(input);
            Assert.Equal(new[] { "0", "0" }, actual);
        }

        [Theory,
         InlineData(" "), InlineData("-"), InlineData("*"),
         InlineData("_"), InlineData("."), InlineData("/"),
         InlineData(@"\"), InlineData("|"), InlineData(":")]
        public void Returns_correct_number_with_given_seperator(string seperator)
        {
            var sut = new StringToKdgNumberParser();
            var actual = sut.Parse($"0033311{seperator}40");
            Assert.Equal(new[] { "0033311", "40" }, actual);
        }
    }
}
