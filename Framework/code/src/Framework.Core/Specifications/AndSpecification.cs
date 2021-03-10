namespace Framework.Core.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public ISpecification<T> Left { get; private set; }
        public ISpecification<T> Right { get; private set; }
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }
        public override bool IsSatisfiedBy(T entity)
        {
            return Left.IsSatisfiedBy(entity) && Right.IsSatisfiedBy(entity);
        }
    }
}