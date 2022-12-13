
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    internal class Variable : VariableDefinition
    {
        private XValue _value;

        public Variable(string name, XType type) : base(name, type)
        {
        }
        public Variable(string name, XType type, XValue value) : this(name, type)
        {
            SetValue(value);
        }

        internal XValue GetValue()
        {
            return _value;
        }

        internal void SetValue(XValue value)
        {
            _value = value.Convert(this.Type);
        }
    }
}
