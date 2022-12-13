using System;

using XProgram.Core;
using XProgram.Engine.Threading;

namespace XProgram.Engine.Tasks
{
    public class CreateThread : Task
    {
        private string _functionName;

        public CreateThread(string functionName)
        {
            _functionName = Guard.EnsureNotNull<string>(functionName);
        }


        public override void Execute()
        {
            var t = Thread.CreateNew(_functionName);
            t.Start(true);
        }

        public override void Validate()
        {
            using (ItemValidationContext ctx = new ItemValidationContext(this))
            {
                if (Guard.IsNull(_functionName))
                    ctx.AddError($"Parameter functionname is not defined (null).");

                if (!ProgramValidationContext.Current.HasFunction(_functionName))
                    ctx.AddError($"Function: '{_functionName}' is not defined.");
            }
        }
    }
}
