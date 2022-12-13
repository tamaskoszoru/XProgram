
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.Boolean
{
    //All subclasses are guarenteed to return XType.Boolean from Evaluate()

    public abstract class BooleanBase : Expression
    {
        public override XType ReturnType
        {
            get { return XTypes.Bool; }
        }

        protected XValue CreateReturn(bool ret)
        {
            return new XValue(XTypes.Bool, ret);
        }
    }
}
