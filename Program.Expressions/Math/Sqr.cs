
using XProgram.Engine;

namespace XProgram.Expressions.Math
{
    public class Sqr : MathBase
    {

        public Sqr(Expression exp) : base(exp)
        {
        }

        protected override double Perform(double v)
        {
            return v * v;
        }
    }
}
