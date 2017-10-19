using System;

namespace Kf.Numaris.Api.Specifications.Builders
{
    public abstract class SpecificationBuilder<TSpecification> : ISpecificationBuilder<TSpecification>
        where TSpecification : ISpecification
    {
        protected string _name = Guid.NewGuid().ToString();

        public ISpecificationBuilder<TSpecification> WithName(string name)
            => SetField(() => _name = name);

        protected SpecificationBuilder<TSpecification> SetField(Action setFieldAction)
        {
            setFieldAction();
            return this;
        }

        public abstract TSpecification Build();
    }
}
