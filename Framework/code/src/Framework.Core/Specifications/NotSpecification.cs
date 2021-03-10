using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Specifications
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        public ISpecification<T> Specification { get; private set; }
        public NotSpecification(ISpecification<T> specification)
        {
            Specification = specification;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return !Specification.IsSatisfiedBy(entity);
        }
    }
}
