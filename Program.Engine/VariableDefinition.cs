
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    public class VariableDefinition
    {
        private readonly string _name;
        private readonly XType _type;
        private readonly XValue _initialValue;

        public VariableDefinition(string name, XType type)
        {
            _name = name;
            _type = type;
        }

        public VariableDefinition(string name, XType type, object initialValue) : this(name, type)
        {
            XValue iv = XValue.CreateFromRaw(initialValue);
            iv = iv.Convert(type);
            _initialValue = iv;
        }

        internal string Name
        {
            get { return _name; }
        }

        internal XType Type
        {
            get { return _type; }
        }

        internal Variable CreateVariable()
        {
            Variable v = new Variable(_name, _type);
            if (_initialValue != null)
                v.SetValue(_initialValue);
            return v;
        }

        internal Variable CreateVariable(XValue value)
        {
            Variable v = new Variable(_name, _type);
            v.SetValue(value);
            return v;
        }
    }
}
