using System.Collections.Generic;
using Framework.Domain;

namespace Scoring.Domain.Model.Rules.CalculationMethods
{
    public class Point : ValueObject<Point>
    {
        public int Value { get; private set; }
        protected Point() { }
        public Point(int value)
        {
            if (value < 1 || value > 100) throw new InvalidPointException();
            Value = value;
        }
        public Point Add(Point point)
        {
            return new Point(this.Value + point.Value);
        }
        public Point Subtract(Point point)
        {
            return new Point(this.Value - point.Value);
        }

        public static Point operator +(Point left, Point right)
        {
            return left.Add(right);
        }
        public static Point operator -(Point left, Point right)
        {
            return left.Subtract(right);
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}