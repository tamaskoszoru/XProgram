using System;
using XProgram.Core;
using XProgram.Engine;

namespace XProgram.Tasks
{
    public class ConsoleWrite : Task
    {
        private Expression _expression;
        private bool _lineFeed;

        public ConsoleWrite(Expression exp, bool lineFeed)
        {
            _expression = Guard.EnsureNotNull<Expression>(exp);
            _lineFeed = lineFeed;
        }

        public override void Validate()
        {
            //validate if expression is null
        }

        public override void Execute()
        {
            XValue value = _expression.Evaluate();

            Console.Write(value.ToString().RawValue);
            if (_lineFeed)
                Console.WriteLine();
        }
    }
}
