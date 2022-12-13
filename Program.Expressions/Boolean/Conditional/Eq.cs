
using XProgram.Engine;

namespace XProgram.Expressions.Boolean.Conditional
{
    public class Eq : ConditionalBase
    {
        public Eq(Expression left, Expression right) : base(left, right)
        {
        }

        protected override bool Perform(bool v1, bool v2)
        {
            return v1 == v2;
        }

        protected override bool Perform(string v1, string v2)
        {
            return v1 == v2;
        }

        protected override bool Perform(double v1, double v2)
        {
            return v1 == v2;
        }
    }
}
