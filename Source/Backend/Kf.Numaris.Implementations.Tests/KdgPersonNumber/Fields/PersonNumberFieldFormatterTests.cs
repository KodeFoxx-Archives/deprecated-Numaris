using Kf.Numaris.Implementations.KdgPersonNumber.Formatting;
using Xunit;

namespace Kf.Numaris.Implementations.Tests.KdgPersonNumber.Fields
{
    public class PersonNumberFieldFormatterTests
    {
        [Theory,
         InlineData(
            "When the person number is given",
            "33311", "0033311"),
         InlineData(
            "When the person number is seven characters long, and already has it's padding applied",
            "0033311", "0033311"),
         InlineData(
            "When the person number exceeds the maximum length",
            "99933311", "99933311"),
         InlineData(
             "When the given number is empty",
             "", "0000000")]
        public void Returns_correct_formatting_given(string scenario, string input, string expected)
        {
            var sut = new PersonNumberFieldFormatter();
            var actual = sut.Format(input);
            Assert.Equal(expected, actual);
        }
    }
}
