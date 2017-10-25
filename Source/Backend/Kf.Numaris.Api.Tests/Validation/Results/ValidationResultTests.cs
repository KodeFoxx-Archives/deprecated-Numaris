using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Validation.Results;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
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
        public void Returns_true_when_all_PartialValidationResults_are_true()
        {
            var sut = new ValidationResult(new List<IPartialValidationResult> { new PartialValidationResult(true), new PartialValidationResult(true), new PartialValidationResult(true) });
            Assert.True(sut.IsValid);
        }

        public static IEnumerable<object[]> Returns_false_when_at_least_one_PartialValidationResult_is_false_TestData()
        {
            yield return GeneratePartialValidationResultsFrom(false);
            yield return GeneratePartialValidationResultsFrom(true, true, false, true);
            yield return GeneratePartialValidationResultsFrom(false, false, false);
            yield return GeneratePartialValidationResultsFrom(false, false, false, true);

            object[] GeneratePartialValidationResultsFrom(params bool[] booleanValues)
                => new object[] { booleanValues.Select(bv => new PartialValidationResult(bv)) };
        }

        [Theory,
         MemberData(nameof(Returns_false_when_at_least_one_PartialValidationResult_is_false_TestData))]
        public void Returns_false_when_at_least_one_PartialValidationResult_is_false(IEnumerable<IPartialValidationResult> input)
        {
            var sut = new ValidationResult(input);
            Assert.False(sut.IsValid);
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
