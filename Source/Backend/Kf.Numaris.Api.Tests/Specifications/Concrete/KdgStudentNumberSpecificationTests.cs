using System;
using System.Collections.Generic;
using Kf.Numaris.Api.Specifications.Concrete;
using Xunit;

namespace Kf.Numaris.Api.Tests.Specifications.Concrete
{
    public class KdgStudentNumberSpecificationTests
    {
        public static IEnumerable<object[]> Can_parse_a_valid_student_number_data()
        {
            yield return new object[] { "003331140", new[] { "0033311", "40" } };
            yield return new object[] { "3331140", new[] { "33311", "40" } };
            yield return new object[] { "0033311-40", new[] { "0033311", "40" } };
            yield return new object[] { "33311-40", new[] { "33311", "40" } };
            yield return new object[] { "140", new[] { "1", "40" } };
        }

        [Theory,
         MemberData(nameof(Can_parse_a_valid_student_number_data))]
        public void Can_parse_a_valid_student_number(string input, string[] expected)
        {
            var sut = new KdgStudentNumberSpecification().Create();
            var actual = sut.ParseAlgorithm(input);

            Assert.Equal(actual, expected);
        }

        [Theory,
         InlineData(""),
         InlineData("  "),
         InlineData(null)]
        public void Parse_returns_empty_array_of_strings_when_input_is_(string input)
        {
            var expected = new List<string>().ToArray();

            var sut = new KdgStudentNumberSpecification().Create();
            var actual = sut.ParseAlgorithm(input);

            Assert.Equal(actual, expected);
        }

        [Theory,
         InlineData("less than three characters", "54"),
         InlineData("less than three characters", "5")]
        public void Parse_throws_ArgumentException_when_input_is_(string reason, string input)
        {
            var sut = new KdgStudentNumberSpecification().Create();
            Assert.Throws<ArgumentException>(() =>
            {
                sut.ParseAlgorithm(input);
            });
        }
    }
}
