using System;

using XProgram.Core;
using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Tasks
{
    public class Increment : Task
    {
        private readonly string _variableName;

        public Increment(string variableName)
        {
            _variableName = Guard.EnsureNotNull<string>(variableName);
        }

        public override void Execute()
        {
            XValue v = VariableResolver.GetVariableValue(_variableName);
            if (v.Type != XTypes.Number)
                throw new ProgramEngineException("Increment works on number variables.");

            double dv = Convert.ToDouble(v.RawValue);
            dv++;
            VariableResolver.SetVariableValue(_variableName, new XValue(XTypes.Number, dv));
        }

        public override void Validate()
        {
            //validate if: variable is defined. of type Number.
        }
    }
}
