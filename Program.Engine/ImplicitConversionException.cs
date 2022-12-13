using System;

namespace XProgram.Engine
{
    public class ImplicitConversionException : Exception
    {
        public ImplicitConversionException(string message) : base(message)
        {
        }

        public static void Throw(string message)
        {
            throw new ImplicitConversionException(message);
        }
    }
}
