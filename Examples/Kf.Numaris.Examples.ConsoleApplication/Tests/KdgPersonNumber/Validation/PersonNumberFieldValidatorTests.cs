using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Validation;
using Xunit;

namespace Kf.Numaris.Examples.ConsoleApplication.Tests.KdgPersonNumber.Validation
{
    public class PersonNumberFieldValidatorTests
    {
        [Theory,
         InlineData("0033311", null),
         InlineData("33311", "Contains no padding zeroes")]
        public void IsValid_in_scenario(string input, string expectedMessage)
        {
            var sut = new PersonNumberFieldValidator();
            var result = sut.Validate(input);
            Assert.True(result.IsValid);
            if (expectedMessage != null)
                Assert.Equal(expectedMessage, result.Message);
        }

        [Theory,
         InlineData(null, "Cannot be empty or white space"),
         InlineData("", "Cannot be empty or white space"),
         InlineData("  ", "Cannot be empty or white space"),
         InlineData("00033311", "Cannot be larger than seven characters"),
         InlineData("89533311", "Cannot be larger than seven characters"),
         InlineData("00333AB", "Cannot consist of anything other than digits ranging from 0 to 9")]
        public void IsNotValid_in_scenario(string input, string expectedMessage)
        {
            var sut = new PersonNumberFieldValidator();
            var result = sut.Validate(input);
            Assert.False(result.IsValid);
            Assert.Equal(expectedMessage, result.Message);
        }
    }
}
