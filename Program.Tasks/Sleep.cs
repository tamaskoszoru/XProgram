using System;

using XProgram.Core;
using XProgram.Engine;
using XProgram.Engine.Types;


namespace XProgram.Tasks
{
    public class Sleep : Task
    {
        private Expression _period;

        public Sleep(Expression exp)
        {
            _period = Guard.EnsureNotNull<Expression>(exp);
        }

        public override void Validate()
        {
            using (ItemValidationContext ctx = new ItemValidationContext(this))
            {
                if (_period.ReturnType != XTypes.Number) //todo: canconvertto
                    ctx.AddError($"Parameter period must be of type Number.");
            }
        }

        public override void Execute()
        {
            int period = Convert.ToInt32(_period.EvaluateAs(XTypes.Number).RawValue);
            System.Threading.Tasks.Task.Delay(period).Wait();
        }
    }
}
