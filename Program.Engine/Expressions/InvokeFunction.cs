using System;
using System.Collections.Generic;

using XProgram.Engine.Threading;
using XProgram.Engine.Types;

namespace XProgram.Engine.Expressions
{
    public sealed class InvokeFunction : Expression
    {
        private string _functionName;
        private List<Expression> _args;

        public InvokeFunction(string functionName)
        {
            _functionName = functionName;
            _args = new List<Expression>();
        }

        public override XType ReturnType
        {
            get { return null; }
        }

        public void AddArgument(Expression arg)
        {
            _args.Add(arg);
        }

        public override XValue Evaluate()
        {
            Function function = Thread.Current.Process.Program.GetFunction(_functionName);

            return function.Execute(_args);
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
