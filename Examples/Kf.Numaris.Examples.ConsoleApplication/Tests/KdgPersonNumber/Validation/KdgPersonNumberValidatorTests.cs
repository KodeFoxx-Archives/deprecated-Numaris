using System.Collections.Generic;
using System.Linq;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Validation.Fields;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Parsing;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Specification.Fields;
using Kf.Numaris.Examples.ConsoleApplication.Implementation.KdgPersonNumber.Validation;
using Xunit;

namespace Kf.Numaris.Examples.ConsoleApplication.Tests.KdgPersonNumber.Validation
{
    public class KdgPersonNumberValidatorTests
    {
        [Theory,
         InlineData("0033311-40"),
         InlineData("33311-40")]
        public void IsValid_in_scenario(string input)
        {
            var sut = CreateKdgPersonNumberValidator();
            var result = sut.Validate(input);
            Assert.True(result.IsValid);
        }

        [Theory,
         InlineData("0033311-4A", "Cannot consist of anything other than digits ranging from 0 to 9"),
         InlineData("3331A-40", "Cannot consist of anything other than digits ranging from 0 to 9"),
         InlineData("0033311-39", "Has to be mod 97 of the person number")]
        public void IsNotValid_in_scenario(string input, string message)
        {
            var sut = CreateKdgPersonNumberValidator();
            var result = sut.Validate(input);
            Assert.False(result.IsValid);

            if(message != null)
                Assert.Contains(message, result.PartialResults.Where(pr => pr.HasMessage).Select(pr => pr.Message));
        }

        private KdgPersonNumberValidator CreateKdgPersonNumberValidator()
            => new KdgPersonNumberValidator(
                fieldSpecifications: new List<IFieldSpecification<KdgPersonNumberSpecification>> {
                    new PersonNumberFieldSpecification(), new CheckDigitsFieldSpecification()
                },
                multipleFieldsValidators: new List<IMultipleFieldsValidator<KdgPersonNumberSpecification>> { 
                    new CheckDigitsMultipleFieldsValidator()
                }, 
                fieldValidators: new List<IFieldValidator<KdgPersonNumberSpecification>> {
                    new CheckDigitsFieldValidator(), new PersonNumberFieldValidator()
                },
                stringParser: new StringToKdgPersonNumberParser()
            );
    }
}
