using System;

using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.Boolean.Conditional
{
    public abstract class ConditionalBase : BooleanBase
    {
        private readonly Expression _left;
        private readonly Expression _right;

        public ConditionalBase(Expression left, Expression right)
        {
            _left = left;
            _right = right;
        }

        public override XValue Evaluate()
        {
            //ensure types are same
            XValue v1 = _left.Evaluate();
            XValue v2 = _right.EvaluateAs(v1.Type);

            bool ret = false;
            if (v1.Type == XTypes.Bool)
                ret = Perform((bool)v1.RawValue, (bool)v2.RawValue);
            if (v1.Type == XTypes.String)
                ret = Perform((string)v1.RawValue, (string)v2.RawValue);
            if (v1.Type == XTypes.Number)
                ret = Perform(Convert.ToDouble(v1.RawValue), Convert.ToDouble(v2.RawValue));

            return CreateReturn(ret);
        }

        //low level raw type operations
        protected abstract bool Perform(bool v1, bool v2);
        protected abstract bool Perform(string v1, string v2);
        protected abstract bool Perform(double v1, double v2);
    }
}
