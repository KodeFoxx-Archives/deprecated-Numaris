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
            var expected = new Identifier(typeof(FakeFieldSpecification));
            var sut = new FakeFieldSpecification();
            Assert.Equal(expected, sut.Identifier);
        }

        [Fact]
        public void Shows_correct_NumberSpecification_identifier()
        {
            var expected = new Identifier(typeof(FakeNumberSpecification));
            var sut = new FakeFieldSpecification();
            Assert.Equal(expected, sut.NumberSpecificationIdentifier);
        }
    }
}
