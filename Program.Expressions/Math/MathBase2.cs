using System;

using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.Math
{
    public abstract class MathBase2 : MathBase
    {
        protected readonly Expression _right;

        public MathBase2(Expression left, Expression right) : base(left)
        {
            _right = right;
        }

        public override XValue Evaluate()
        {
            XValue v1 = _left.EvaluateAs(XTypes.Number);
            XValue v2 = _right.EvaluateAs(XTypes.Number);

            double ret = Perform2(Convert.ToDouble(v1.RawValue), Convert.ToDouble(v2.RawValue));

            return CreateReturn(ret);
        }

        protected sealed override double Perform(double v)
        {
            throw new ProgramEngineException("2-operand expressions must implement Perform2");
        }

        protected abstract double Perform2(double v1, double v2);
    }
}
