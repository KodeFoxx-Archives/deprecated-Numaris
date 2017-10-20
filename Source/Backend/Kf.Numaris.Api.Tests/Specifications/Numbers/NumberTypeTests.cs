using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;
using Xunit;

namespace Kf.Numaris.Api.Tests.Specifications.Numbers
{
    public class NumberTypeTests
    {
        [Fact]
        public void Sets_Id_to_FullName_of_calling_type()
        {
            var sut = new FakeNumberSpecification();
            Assert.Equal(typeof(FakeNumberSpecification).FullName, sut.NumberType.Id);
        }

        [Fact]
        public void Sets_Name_to_Name_of_calling_type()
        {
            var sut = new FakeNumberSpecification();
            Assert.Equal(typeof(FakeNumberSpecification).Name, sut.NumberType.Name);
        }

        [Fact]
        public void Throws_UnsupportedInterfaceExcpetion_when_type_is_not_derived_from_INumberSpecification()
        {
            var exception = Assert.Throws<UnsupportedInterfaceException>(() =>
            {
                NumberType.FromNumberSpecification(GetType());
            });

            Assert.Equal("The interfaces supported are INumberSpecification.", exception.Message);
        }
    }
}
