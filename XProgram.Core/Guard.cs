using System;

namespace XProgram.Core
{
    public static class Guard
    {
        public static bool IsNull(object value)
        {
            return Object.ReferenceEquals(value, null);
        }

        public static T EnsureNotNull<T>(T value)
        {
            if (Object.ReferenceEquals(value, null))
                throw new ArgumentNullException();

            return value;
        }
    }
}
