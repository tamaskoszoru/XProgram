
using XProgram.Engine;

namespace XProgram.Expressions.Math
{
    public class Sqrt : MathBase
    {

        public Sqrt(Expression exp) : base(exp)
        {
        }

        protected override double Perform(double v)
        {
            return System.Math.Sqrt(v);
        }
    }
}
