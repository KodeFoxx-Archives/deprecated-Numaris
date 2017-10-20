using Kf.Numaris.Api.Common;
using Kf.Numaris.Api.Specifications.Numbers;
using Kf.Numaris.Api.Tests.Specifications.Fields;
using Kf.Numaris.Api.Tests.Specifications.Numbers;
using Xunit;

namespace Kf.Numaris.Api.Tests.Common
{
    public class IdentifierTests
    {
        [Fact]
        public void Sets_Id_to_FullName_of_calling_type()
        {
            var sut = new FakeFieldSpecification();
            Assert.Equal(typeof(FakeFieldSpecification).FullName, sut.Identifier.Id);
        }

        [Fact]
        public void Sets_Name_to_Name_of_calling_type()
        {
            var sut = new FakeFieldSpecification();
            Assert.Equal(typeof(FakeFieldSpecification).Name, sut.Identifier.Name);
        }

        [Fact]
        public void Throws_UnsupportedInterfaceExcpetion_when_type_is_not_derived_from_INumberSpecification()
        {
            var exception = Assert.Throws<UnsupportedInterfaceException>(() =>
            {
                Identifier.For<INumberSpecification>(GetType());
            });

            Assert.Equal("The interfaces supported are INumberSpecification.", exception.Message);
        }
    }
}
