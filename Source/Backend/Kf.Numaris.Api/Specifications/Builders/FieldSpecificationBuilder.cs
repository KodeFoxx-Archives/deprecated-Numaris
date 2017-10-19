namespace Kf.Numaris.Api.Specifications.Builders
{
    public sealed class FieldSpecificationBuilder : SpecificationBuilder<FieldSpecification>
    {
        public override FieldSpecification Build()
            => new FieldSpecification(_name);
    }
}
