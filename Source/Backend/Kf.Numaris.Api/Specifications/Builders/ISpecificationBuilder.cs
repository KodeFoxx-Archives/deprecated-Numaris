namespace Kf.Numaris.Api.Specifications.Builders
{
    public interface ISpecificationBuilder<TSpecification, TSpecificationBuilder>
        where TSpecification : ISpecification
        where TSpecificationBuilder : ISpecificationBuilder<TSpecification, TSpecificationBuilder>
    {
        TSpecificationBuilder WithName(string name);
        TSpecification Build();
    }
}
