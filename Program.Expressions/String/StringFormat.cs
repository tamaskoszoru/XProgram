using System.Linq;

using XProgram.Engine;
using XProgram.Engine.Types;

namespace XProgram.Expressions.String
{
    public class StringFormat : Expression
    {
        private Expression _format;
        private Expression[] _args;

        public StringFormat(Expression format, params Expression[] args)
        {
            _format = format;
            _args = args;
        }

        public override XType ReturnType
        {
            get { return XTypes.String; }
        }

        public override XValue Evaluate()
        {
            string raw = System.String.Format((string)_format.EvaluateAs(XTypes.String).RawValue, _args.Select((exp) => (string)(exp.Evaluate().ToString().RawValue)).ToArray());

            return new XValue(XTypes.String, raw);
        }
    }
}
