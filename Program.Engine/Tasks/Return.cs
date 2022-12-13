using System;

using XProgram.Core;

namespace XProgram.Engine.Tasks
{
    internal class ReturnFunctionException : Exception
    {
        private XValue _returnValue;

        public ReturnFunctionException(XValue returnValue)
        {
            _returnValue = returnValue;
        }

        public XValue ReturnValue
        {
            get { return _returnValue; }
        }
    }


    public class Return : Task
    {
        private Expression _returnValue;

        public Return(Expression returnValue)
        {
            _returnValue = Guard.EnsureNotNull<Expression>(returnValue);
        }

        public override void Execute()
        {
            throw new ReturnFunctionException(_returnValue.Evaluate());
        }

        public override void Validate()
        {
            //todo: how to validate _returnValue's type against Function's type?
            //put current function on the ValidationContext?
        }
    }
}
