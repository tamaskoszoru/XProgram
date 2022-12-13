
using XProgram.Engine;

namespace XProgram.Expressions.Boolean.Conditional
{
    public class Gt : ConditionalBase
    {
        public Gt(Expression left, Expression right) : base(left, right)
        {
        }

        protected override bool Perform(bool v1, bool v2)
        {
            throw new ProgramEngineException("Operator > cannot be applied on type bool.");
        }

        protected override bool Perform(string v1, string v2)
        {
            throw new ProgramEngineException("Operator > cannot be applied on type string.");
        }

        protected override bool Perform(double v1, double v2)
        {
            return v1 > v2;
        }
    }
}
