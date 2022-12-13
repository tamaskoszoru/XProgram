using System;

namespace XProgram.Engine
{
    public class ProgramValidationException : Exception
    {
        public ProgramValidationException(string message) : base(message)
        {
        }

        public ProgramValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        public static void Throw(string message)
        {
            throw new ProgramValidationException(message);
        }
    }
}
