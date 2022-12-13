
using XProgram.Engine;

namespace XProgram.Expressions.Math
{
    public class Sub : MathBase2
    {
        public Sub(Expression left, Expression right) : base(left, right)
        {
        }

        protected override double Perform2(double v1, double v2)
        {
            return v1 - v2;
        }
    }
}
