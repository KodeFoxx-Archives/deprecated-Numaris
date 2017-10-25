using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Tests.Specifications.Fields;
using Kf.Numaris.Api.Tests.Specifications.Numbers;

namespace Kf.Numaris.Api.Tests.Formatting.Fields
{
    public sealed class FakeFieldTwoFormatter : FieldFormatter<FakeFieldTwoSpecification, FakeNumberSpecification>
    {
        public override string Format(string input)
            => input;
    }
}
