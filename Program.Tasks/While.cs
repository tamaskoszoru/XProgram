using System;
using System.Linq;

using XProgram.Core;
using XProgram.Engine;
using XProgram.Engine.Tasks;
using XProgram.Engine.Types;
using XProgram.Expressions.Boolean;

namespace XProgram.Tasks
{
    public class While : Sequence
    {
        private readonly BooleanBase _condition;

        public While(BooleanBase condition)
        {
            _condition = Guard.EnsureNotNull<BooleanBase>(condition);
        }

        public override void Execute()
        {
            //evaluate condition
            while ((bool)_condition.EvaluateAs(XTypes.Bool).RawValue)
            {
                //execute sequence
                base.Execute();
            }
        }

        public override void Validate()
        {
            foreach (var item in this.Select((task, i) => new { Task = task, Line = i + 1 }))
            {
                using (ItemValidationContext ctx = new ItemValidationContext(this, item.Line))
                {
                    item.Task.Validate();
                }
            }
        }
    }
}
