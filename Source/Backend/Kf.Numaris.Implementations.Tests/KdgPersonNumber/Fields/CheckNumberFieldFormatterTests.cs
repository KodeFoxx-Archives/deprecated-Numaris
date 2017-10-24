using Kf.Numaris.Implementations.KdgPersonNumber.Formatting;
using Xunit;

namespace Kf.Numaris.Implementations.Tests.KdgPersonNumber.Fields
{
    public class CheckNumberFormatterTests
    {
        [Theory,
         InlineData(
             "When the check digits are given",
             "40", "40"),
         InlineData(
             "When the check digits are given, but with only one character",
             "4", "04"),
         InlineData(
             "When the check digits exceed the maximum length",
             "400", "40"),
         InlineData(
             "When the given check digit is empty",
             "", "00")]
        public void Returns_correct_formatting_given(string scenario, string input, string expected)
        {
            var sut = new CheckDigitsFieldFormatter();
            var actual = sut.Format(input);
            Assert.Equal(expected, actual);
        }
    }
}
