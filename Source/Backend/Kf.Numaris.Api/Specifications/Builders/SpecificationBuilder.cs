using System;

namespace Kf.Numaris.Api.Specifications.Builders
{
    public abstract class SpecificationBuilder<TSpecification, TSpecificationBuilder> : ISpecificationBuilder<TSpecification, TSpecificationBuilder>
        where TSpecification : ISpecification
        where TSpecificationBuilder : SpecificationBuilder<TSpecification, TSpecificationBuilder>
    {
        protected string _name = Guid.NewGuid().ToString();

        public virtual TSpecificationBuilder WithName(string name)
            => SetField(() => _name = name);

        public TSpecificationBuilder WithName(object name)
            => SetField(() => _name = name.ToString());

        protected TSpecificationBuilder SetField(Action setFieldAction)
        {
            setFieldAction();
            return (TSpecificationBuilder)this;
        }

        public abstract TSpecification Build();
    }
}
