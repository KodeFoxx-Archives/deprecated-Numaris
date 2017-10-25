using Kf.Numaris.Api.Validation.Results;
using Xunit;

namespace Kf.Numaris.Api.Tests.Validation.Results
{
    public class PartialValidationResultTests
    {
        [Theory, InlineData(true, true), InlineData(false, false)]
        public void Returns_correct_boolean_according_to_given_input_boolean(bool input, bool expected)
        {
            var sut = new PartialValidationResult(input);
            Assert.Equal(expected, sut.IsValid);
        }
    }
}
