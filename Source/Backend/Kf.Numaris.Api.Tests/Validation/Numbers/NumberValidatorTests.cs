using System.Collections.Generic;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Tests.Specifications.Fields;
using Kf.Numaris.Api.Tests.Specifications.Numbers;
using Kf.Numaris.Api.Validation.Numbers;
using Xunit;

namespace Kf.Numaris.Api.Tests.Validation.Numbers
{
    public class NumberValidatorTests
    {
        [Fact]
        public void Returns_true_when_no_field_validators_are_given()
        {
            var sut = CreateSut();
            var actual = sut.Validate(new[] { "0033311", "40" });
            Assert.True(actual.IsValid);
        }

        private INumberValidator<FakeNumberSpecification> CreateSut()
        {
            return new FakeNumberValidator(
                fieldSpecifications: new List<IFieldSpecification<FakeNumberSpecification>> {
                    new FakeFieldSpecificationTwo(), new FakeFieldSpecificationOne()
                },
                fieldValidators: null,
                stringParser: null
            );
        }
    }
}
