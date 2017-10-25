using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Formatting;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification.Fields;
using Xunit;

namespace Kf.Numaris.Examples.ConsoleApplication.Tests.KdgPersonNumber.Formatting
{
    public class KdgNumberFormatterTests
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

        private INumberFormatter<KdgPersonNumberSpecification> CreateNumberFormatter()
            => new KdgPersonNumberFormatter(
                    fieldFormatters: new List<IFieldFormatter<KdgPersonNumberSpecification>> {
                        new CheckDigitsFieldFormatter(), new PersonNumberFieldFormatter()
                    },
                    fieldSpecifications: new List<IFieldSpecification<KdgPersonNumberSpecification>> {
                        new PersonNumberFieldSpecification(), new CheckDigitsFieldSpecification()
                    },
                    stringParser: null
                );
    }
}
