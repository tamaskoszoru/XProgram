using System.Collections.Generic;
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    public class Program : IValidatable
    {
        private string _name;
        private List<VariableDefinition> _variables;                //global variables definitions
        private Dictionary<string, Function> _functions;            //function definitions

        public Program(string name)
        {
            _name = name;
            _variables = new List<VariableDefinition>();
            _functions = new Dictionary<string, Function>();
        }

        public string Name
        {
            get { return _name; }
        }

        public Program AddVariable(string name, XType type)
        {
            VariableDefinition v = new VariableDefinition(name, type);
            _variables.Add(v);

            return this;
        }
        public Program AddVariable(string name, XType type, object initialValue)
        {
            VariableDefinition v = new VariableDefinition(name, type, initialValue);
            _variables.Add(v);

            return this;
        }

        public List<VariableDefinition> VariableDefinitions
        {
            get { return _variables; }
        }

        public Program AddFunction(Function function)
        {
            _functions.Add(function.Name, function);
            return this;
        }

        internal Function GetFunction(string name)
        {
            return _functions[name];
        }

        internal bool HasFunction(string name)
        {
            return _functions.ContainsKey(name);
        }

        public virtual string GetName()
        {
            return $"Program ({_name})";
        }

        public void Validate()
        {
            using (ProgramValidationContext ctx = new ProgramValidationContext(this))
            {
                //validate program
                if (!_functions.ContainsKey(Constants.ENTRY_FUNCTION_NAME))
                    ctx.AddError($"Function '{Constants.ENTRY_FUNCTION_NAME}' not defined.");

                //validate variables
                //todo

                //validate functions
                foreach (KeyValuePair<string, Function> item in _functions)
                {
                    item.Value.Validate();
                }

                if (ctx.HasErrors)
                    throw new ProgramValidationException(ctx.Result);
            }
        }

    }
}
