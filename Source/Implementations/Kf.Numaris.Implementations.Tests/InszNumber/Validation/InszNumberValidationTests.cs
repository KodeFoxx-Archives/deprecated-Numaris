using Kf.Numaris.Implementations.InszNumber.Parsing;
using Kf.Numaris.Implementations.InszNumber.Validation;
using Xunit;
using System.Linq;

namespace Kf.Numaris.Implementations.Tests.InszNumber.Validation
{
    public class InszNumberValidationTests
    {
        [Theory,
         InlineData("85101142731"),
         InlineData("85.10.11-427.31"),
         InlineData("851011427-31"),
         InlineData("85 10 11 427 31"),
         InlineData("42012205181"),
         InlineData("12345612345"),
         InlineData("12345612374"),
         InlineData("93051822361"),
         InlineData("17112612345"),
         InlineData("17112612444"),
         InlineData("17112612444"),
         InlineData("00000000097"),
         InlineData("40000095381"),
         InlineData("40000095313")]
        public void IsValid_in_scenario(string input)
        {
            var sut = CreateInszNumberValidator();
            var result = sut.Validate(input);
            Assert.True(result.IsValid);
        }

        [Theory,
         InlineData("40000095300", nameof(ValidationErrorMessages.CheckDigitsDoNotMatch))]
        public void IsNotValid_in_scenario(string input, string message)
        {
            var sut = CreateInszNumberValidator();
            var result = sut.Validate(input);
            Assert.False(result.IsValid);

            if (message != null)
                Assert.Contains(message, result.PartialResults.Where(pr => pr.HasMessage).Select(pr => pr.Message));
        }

        private InszNumberValidator CreateInszNumberValidator()
            => new InszNumberValidator(
                fieldSpecifications: InszNumberTestData.FieldSpecifications,
                multipleFieldsValidators: InszNumberTestData.MultipleFieldsValidators,
                fieldValidators: InszNumberTestData.FieldValidators,
                stringParser: new StringToInszNumberParser()
            );
    }
}
