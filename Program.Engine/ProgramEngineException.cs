using System;

namespace XProgram.Engine
{
    public class ProgramEngineException : Exception
    {
        public ProgramEngineException(string message) : base(message)
        {
        }

        public ProgramEngineException(string message, Exception inner) : base(message, inner)
        {
        }

        public static void Throw(string message)
        {
            throw new ProgramEngineException(message);
        }
    }
}
