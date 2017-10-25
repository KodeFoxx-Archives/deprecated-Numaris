using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Tests.Specifications.Numbers;
using Xunit;

namespace Kf.Numaris.Api.Tests.Specifications.Fields
{
    public class FieldSpecificationTests
    {
        [Fact]
        public void Shows_correct_identifier()
        {
            var expected = new Identifier(typeof(FakeFieldTwoSpecification));
            var sut = new FakeFieldTwoSpecification();
            Assert.Equal(expected, sut.Identifier);
        }

        [Fact]
        public void Shows_correct_NumberSpecification_identifier()
        {
            var expected = new Identifier(typeof(FakeNumberSpecification));
            var sut = new FakeFieldOneSpecification();
            Assert.Equal(expected, sut.NumberSpecificationIdentifier);
        }
    }
}
