
using XProgram.Engine;

namespace XProgram.Expressions.Math
{
    public class Mul : MathBase2
    {
        public Mul(Expression left, Expression right) : base(left, right)
        {
        }

        protected override double Perform2(double v1, double v2)
        {
            return v1 * v2;
        }
    }
}
