
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.Boolean.Logical
{
    public class Neg : BooleanBase
    {
        private readonly BooleanBase _exp;

        public Neg(BooleanBase exp)
        {
            _exp = exp;
        }


        public override XValue Evaluate()
        {
            XValue v1 = _exp.EvaluateAs(XTypes.Bool);

            bool ret = !(bool)v1.RawValue;

            return CreateReturn(ret);
        }
    }
}
