using Kf.Numaris.Api.Specifications.Numbers;
using Xunit;

namespace Kf.Numaris.Api.Tests.Specifications.Numbers
{
    public class NumberSpecificationTests
    {
        [Fact]
        public void Shows_correct_NumberType()
        {
            var expected = new NumberType(typeof(FakeNumberSpecification));
            var sut = new FakeNumberSpecification();
            Assert.Equal(expected, sut.NumberType);
        }
    }
}
