namespace Scoring.Domain.Model.Rules.CalculationMethods
{
    public abstract class CalculationMethod
    {
        public Point Point { get; private set; }
        protected CalculationMethod(Point point)
        {
            Point = point;
        }

        public abstract long Calculate();
    }

    public class Reward : CalculationMethod
    {
        public Reward(Point point) : base(point)
        {
        }
        public override long Calculate() => Point.Value;

    }
    public class Penalty : CalculationMethod
    {
        public Penalty(Point point) : base(point)
        {
        }
        public override long Calculate() => Point.Value * -1;
    }
}