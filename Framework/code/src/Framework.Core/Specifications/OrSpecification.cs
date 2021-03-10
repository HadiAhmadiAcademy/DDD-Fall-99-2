namespace Framework.Core.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _left;
        private ISpecification<T> _right;
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);
        }
    }
}