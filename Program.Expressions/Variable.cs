
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions
{
    public class Variable : Expression
    {
        private string _name;

        public Variable(string name)
        {
            _name = name;
        }

        public override XType ReturnType
        {
            get { return null; }            //type cannot be determined when not in runtime, yet. 
        }

        public override XValue Evaluate()
        {
            return VariableResolver.GetVariableValue(_name);
        }
    }
}
