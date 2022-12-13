
using XProgram.Core;
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Tasks
{
    public class SetVariable : Task
    {
        private string _variableName;
        private Expression _expression;

        public SetVariable(string variableName, Expression exp)
        {
            _variableName = Guard.EnsureNotNull<string>(variableName);
            _expression = Guard.EnsureNotNull<Expression>(exp);
        }

        public override void Validate()
        {
            //todo: validate: variable exists and of type _expression.Type
        }

        public override void Execute()
        {
            XType vtype = VariableResolver.GetVariableType(_variableName);

            //ensure value is in (or implicit converted to) variable's type
            XValue value = _expression.EvaluateAs(vtype);

            VariableResolver.SetVariableValue(_variableName, value);
        }
    }
}
