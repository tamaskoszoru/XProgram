
using XProgram.Engine.Threading;
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    public class VariableResolver
    {
        internal static Variable GetVariable(string name)
        {
            return Thread.Current.GetVariable(name);
        }

        public static XType GetVariableType(string name)
        {
            return Thread.Current.GetVariable(name).Type;
        }

        public static void SetVariableValue(string name, XValue value)
        {
            Variable v = GetVariable(name);
            v.SetValue(value);
        }

        public static XValue GetVariableValue(string name)
        {
            Variable v = GetVariable(name);
            return v.GetValue();
        }
    }
}
