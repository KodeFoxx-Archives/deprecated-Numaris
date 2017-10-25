using System.Collections.Generic;
using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Formatting.Numbers;
using Kf.Numaris.Api.Specifications.Field;
using Kf.Numaris.Api.Tests.Formatting.Fields;
using Kf.Numaris.Api.Tests.Specifications.Fields;
using Kf.Numaris.Api.Tests.Specifications.Numbers;
using Xunit;

namespace Kf.Numaris.Api.Tests.Formatting.Numbers
{
    public class NumberFormatterTests
    {
        [Fact]
        public void Formatters_are_loaded_in_correct_order()
        {
            var sut = CreateNumberFormatter();
            Assert.Equal(typeof(FakeFieldOneFormatter), sut.FieldFormatters[1].GetType());
            Assert.Equal(typeof(FakeFieldTwoFormatter), sut.FieldFormatters[2].GetType());
        }

        private INumberFormatter<FakeNumberSpecification> CreateNumberFormatter()
            => new FakeNumberFormatter(
                fieldFormatters: new List<IFieldFormatter<FakeNumberSpecification>> {
                    new FakeFieldOneFormatter(), new FakeFieldTwoFormatter()
                },
                fieldSpecifications: new List<IFieldSpecification<FakeNumberSpecification>> {
                    new FakeFieldTwoSpecification(), new FakeFieldOneSpecification()
                },
                stringParser: null
            );
    }
}
