using System;

using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.Math
{
    //All subclasses MUST return XType.Number from Evaluate()

    public abstract class MathBase : Expression
    {
        protected readonly Expression _left;

        public MathBase(Expression exp)
        {
            _left = exp;
        }

        public override XType ReturnType
        {
            get { return XTypes.Number; }
        }

        public override XValue Evaluate()
        {
            XValue v = _left.EvaluateAs(XTypes.Number);

            double ret = Perform(Convert.ToDouble(v.RawValue));

            return CreateReturn(ret);
        }

        protected abstract double Perform(double v);

        protected XValue CreateReturn(double ret)
        {
            return new XValue(XTypes.Number, ret);
        }
    }
}
