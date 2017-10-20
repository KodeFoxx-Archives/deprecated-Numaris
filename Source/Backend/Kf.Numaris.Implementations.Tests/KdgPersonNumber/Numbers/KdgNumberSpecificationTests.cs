using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Implementations.KdgPersonNumber.Fields;
using Kf.Numaris.Implementations.KdgPersonNumber.Numbers;
using Xunit;

namespace Kf.Numaris.Implementations.Tests.KdgPersonNumber.Numbers
{
    public class KdgNumberSpecificationTests
    {
        [Theory,
         InlineData(
             "When the numbers are given",
             "0033311", "40", "0033311-40"),
         InlineData(
             "When the numbers are given without padding",
             "33311", "40", "0033311-40"),
         InlineData(
             "When the numbers are all empty",
             "", "", "0000000-00")]
        public void Returns_correct_formatting_given(string scenario, string personNumberInput, string checkDigitsInput, string expected)
        {
            var input = new[] { personNumberInput, checkDigitsInput };
            var sut = CreateNumberFormatter();
            var actual = sut.Format(input);
            Assert.Equal(expected, actual);
        }

        private INumberFormatter CreateNumberFormatter()
        {
            return new KdgNumberFormatter(new IFieldFormatter<KdgNumberSpecification>[] {
                new PersonNumberFieldFormatter(),
                new CheckDigitsFieldFormatter()
            });
        }
    }
}