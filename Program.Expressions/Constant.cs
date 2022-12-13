
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions
{

    public class Constant : Expression
    {
        private XValue _value;

        public Constant(object value)
        {
            _value = XValue.CreateFromRaw(value);   //type is inferred from raw constant value
        }

        public override XType ReturnType
        {
            get { return _value.Type; }
        }

        public override XValue Evaluate()
        {
            return _value;
        }
    }
}
