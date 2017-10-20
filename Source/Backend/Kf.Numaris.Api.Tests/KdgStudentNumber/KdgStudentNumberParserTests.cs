using System;
using System.Collections.Generic;
using Xunit;

namespace Kf.Numaris.Api.Tests.KdgStudentNumber
{
    public class KdgStudentNumberParserTests
    {
        public static IEnumerable<object[]> Parser_can_handle_scenario_TestData()
        {
            yield return new object[] {
                "Where number contains hyphen",
                "0033311-40", new [] { "0033311", "40" }
            };

            yield return new object[] {
                "Where number contains hyphen, but no trailing zeroes",
                "33311-40", new [] { "33311", "40" }
            };

            yield return new object[] {
                "Where number contains hyphen, and only one number before hyphen",
                "1-40", new [] { "1", "40" }
            };

            yield return new object[] {
                "Where number doesn't contain a hyphen",
                "003331140", new [] { "0033311", "40" }
            };

            yield return new object[] {
                "Where number doesn't contain a hyphen, and has no trailing zeroes",
                "3331140", new [] { "33311", "40" }
            };

            yield return new object[] {
                "Where number doesn't contain a hyphen, and consists of only three numbers in a whole",
                "140", new [] { "1", "40" }
            };
        }

        [Theory, MemberData(nameof(Parser_can_handle_scenario_TestData))]
        public void Parser_can_handle_scenario(string scenario, string input, string[] expected)
        {
            var sut = new KdgStudentNumberParser();
            var actual = sut.Parse(input);
            Assert.Equal(actual, expected);
        }

        [Theory,
         InlineData(""),
         InlineData(" "),
         InlineData("  "),
         InlineData(null)]
        public void Parser_throws_NumberParserException_with_ArgumentNullExcpetion_when_input_is(string input)
        {
            var sut = new KdgStudentNumberParser();
            var exception = Assert.Throws<NumberParserException>(() =>
            {
                sut.Parse(input);
            });
            Assert.Equal(typeof(ArgumentNullException), exception.InnerException.GetType());
        }

        [Theory,
         InlineData("00333-11-40", "The input can only contain 0 or 1 hyphen"),
         InlineData("0033311-", "The input needs at least one character before and after the hyphen"),
         InlineData("-003331140", "The input needs at least one character before and after the hyphen"),
         InlineData("-", "The input needs at least one character before and after the hyphen"),
         InlineData("22", "The input needs to have at least three characters")]
        public void Parser_throws_NumberParserException_when_input_is(string input, string partialExceptionMessage)
        {
            var sut = new KdgStudentNumberParser();
            var exception = Assert.Throws<NumberParserException>(() =>
            {
                sut.Parse(input);
            });
            Assert.Contains(partialExceptionMessage, exception.Message);
        }
    }
}
