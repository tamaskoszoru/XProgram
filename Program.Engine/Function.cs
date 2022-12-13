using System.Collections.Generic;
using System.Linq;
using XProgram.Engine.Tasks;
using XProgram.Engine.Threading;
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    public class Function : IValidatable
    {
        private string _name;
        private List<VariableDefinition> _arguments;
        private Sequence _sequence; //contained Sequence task. (as Function is intentionally not a Task.)

        public Function(string name)
        {
            _name = name;
            _arguments = new List<VariableDefinition>();
            _sequence = new Sequence();
        }

        public string Name
        {
            get { return _name; }
        }

        public Function AddArgument(string name, XType type)
        {
            _arguments.Add(new VariableDefinition(name, type));
            return this;
        }

        public Function AddTask(Task task)
        {
            _sequence.Add(task);

            return this;
        }

        public List<VariableDefinition> Arguments
        {
            get { return _arguments; }
        }

        internal XValue Execute(List<Expression> args) //empty list for void.
        {
            try
            {
                //add new stackframe
                using (StackFrame frame = Thread.Current.CallStack.AddFrame(_name))
                {
                    //add initial scope on frame
                    using (Scope scope = Thread.Current.CallStack.AddScope())
                    {
                        //match argument variables from function definition with parameters passed in _args, and put onto bottom of the stackframe just created
                        foreach (var v in _arguments.Zip(args, (ad, av) => new { Argument = ad, Value = av }))
                        {
                            VariableDefinition vd = v.Argument;
                            Expression value = v.Value;
                            try
                            {
                                scope.AddVariable(vd.CreateVariable(value.EvaluateAs(vd.Type)));
                            }
                            catch (ImplicitConversionException ex)
                            {
                                throw new ProgramEngineException($"Argument error {vd.Name}", ex);
                            }
                        }

                        //execute function body
                        _sequence.Execute();
                    }
                }
            }
            catch (ReturnFunctionException ex)
            {
                return ex.ReturnValue;
            }

            return null;
        }

        public virtual string GetName()
        {
            return $"Function({_name})";
        }

        public void Validate()
        {
            foreach (var item in _sequence.Select((task, i) => new {Task=task, Line=i+1 }))
            {
                using (ItemValidationContext ctx = new ItemValidationContext(this, item.Line))
                {
                    item.Task.Validate();
                }
            }
        }
    }
}
