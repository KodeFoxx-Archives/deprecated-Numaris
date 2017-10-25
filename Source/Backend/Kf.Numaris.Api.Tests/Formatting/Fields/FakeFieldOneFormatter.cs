using Kf.Numaris.Api.Formatting.Fields;
using Kf.Numaris.Api.Tests.Specifications.Fields;
using Kf.Numaris.Api.Tests.Specifications.Numbers;

namespace Kf.Numaris.Api.Tests.Formatting.Fields
{
    public sealed class FakeFieldOneFormatter : FieldFormatter<FakeFieldOneSpecification, FakeNumberSpecification>
    {
        public override string Format(string input)
            => input;
    }
}
