
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.Boolean.Logical
{
    public abstract class LogicalBase : BooleanBase
    {
        private readonly BooleanBase _left;
        private readonly BooleanBase _right;

        public LogicalBase(BooleanBase left, BooleanBase right)
        {
            _left = left;
            _right = right;
        }


        public override XValue Evaluate()
        {
            XValue v1 = _left.EvaluateAs(XTypes.Bool);
            XValue v2 = _right.EvaluateAs(XTypes.Bool);

            bool ret = Perform((bool)v1.RawValue, (bool)v2.RawValue);

            return CreateReturn(ret);
        }

        protected abstract bool Perform(bool v1, bool v2);
    }
}
