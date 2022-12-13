using System;
using System.Collections.Generic;
using System.Linq;
using XProgram.Core;
using XProgram.Engine.Threading;

namespace XProgram.Engine.Tasks
{
    public sealed class InvokeFunction : Task
    {
        private string _functionName;
        private List<Expression> _args;

        public InvokeFunction(string functionName)
        {
            _functionName = Guard.EnsureNotNull<string>(functionName);
            _args = new List<Expression>();
        }

        public InvokeFunction AddArgument(Expression arg)
        {
            _args.Add(arg);
            return this;
        }

        public override void Execute()
        {
            Function function = Thread.Current.Process.Program.GetFunction(_functionName);

            function.Execute(_args);
        }

        public override void Validate()
        {
            using (ItemValidationContext ctx = new ItemValidationContext(this))
            {
                if (!ProgramValidationContext.Current.HasFunction(_functionName))
                    ctx.AddError($"Function '{_functionName}' is not defined.");

                Function f = ProgramValidationContext.Current.GetFunction(_functionName);

                if (f.Arguments.Count != _args.Count)
                    ctx.AddError($"Function '{_functionName}' expects {f.Arguments.Count} argument(s).");

                int i = 1;
                foreach (var item in f.Arguments.Zip(_args, (vd, arg) => new { Vd = vd, Arg = arg }))
                {
                    if (item.Arg.ReturnType == null)    //type is undetermined, no validation. (can cause runtime error)
                        continue;
                    if(item.Arg.ReturnType != item.Vd.Type) //todo: change to CanConvertTo (implicit conversion)
                        ctx.AddError($"Function '{_functionName}' argument {i} type mismatch.");

                    i++;
                }
            }
        }
    }
}
