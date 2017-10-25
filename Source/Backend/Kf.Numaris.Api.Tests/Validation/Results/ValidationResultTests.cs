using System.Collections.Generic;
using Kf.Numaris.Api.Validation.Results;
using Xunit;

namespace Kf.Numaris.Api.Tests.Validation.Results
{
    public class ValidationResultTests
    {
        public static IEnumerable<object[]> Returns_true_when_null_or_empty_PartialValidationResult_is_given_TestData()
        {
            yield return new object[] { null };
            yield return new object[] { new List<IPartialValidationResult>() };
        }

        [Theory,
         MemberData(nameof(Returns_true_when_null_or_empty_PartialValidationResult_is_given_TestData))]
        public void Returns_true_when_null_or_empty_PartialValidationResult_is_given(IEnumerable<IPartialValidationResult> input)
        {
            var sut = new ValidationResult(input);
            Assert.True(sut.IsValid);
        }


        [Fact]
        public void Converts_null_to_empty_list_of_PartialValidationResults()
        {
            var sut = new ValidationResult(null);
            Assert.NotNull(sut.PartialResults);
            Assert.Equal(0, sut.PartialResults.Count);
        }
    }
}
