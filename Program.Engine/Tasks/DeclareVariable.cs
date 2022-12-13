using System;

using XProgram.Core;
using XProgram.Engine.Threading;
using XProgram.Engine.Types;

namespace XProgram.Engine.Tasks
{
    public class DeclareVariable : Task
    {
        private string _name;
        private XType _type;
        private Expression _initialValue;

        public DeclareVariable(string name, XType type)
        {
            _name = Guard.EnsureNotNull<string>(name);
            _type = Guard.EnsureNotNull<XType>(type);
        }

        public DeclareVariable(string name, XType type, Expression initialValue) : this(name, type)
        {
            _initialValue = initialValue;
        }

        public override void Execute()
        {
            var v = new Variable(_name, _type);

            Thread.Current.CallStack.TopFrame.TopScope.AddVariable(v);

            if (_initialValue != null)
                v.SetValue(_initialValue.EvaluateAs(_type));
        }

        public override void Validate()
        {
            using (ItemValidationContext ctx = new ItemValidationContext(this))
            {
                if (_initialValue != null && _type != _initialValue.ReturnType) //todo: change CanConvertTo
                    ctx.AddError($"Wrong initialValue type.");
            }
        }
    }
}
