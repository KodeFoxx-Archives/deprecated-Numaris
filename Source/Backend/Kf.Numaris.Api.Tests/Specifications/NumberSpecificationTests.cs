using Kf.Numaris.Api.Specifications;
using Xunit;

namespace Kf.Numaris.Api.Tests.Specifications
{
    public class NumberSpecificationTests
    {
        [Fact]
        public void Building_a_new_NumberSpecification_without_options_returns_an_empty_list_of_FieldSpecifications()
        {
            var sut = NumberSpecification
                .New()
                .Build();

            Assert.Equal(sut.FieldSpecifications.Count, 0);
        }

        [Fact]
        public void Building_a_new_NumberSpecification_with_name_returns_identical_name()
        {
            var expectedName = "Excpected name";
            var sut = NumberSpecification
                .New()
                .WithName(expectedName)
                .Build();

            Assert.Equal(sut.Name, expectedName);
        }
    }
}
