
using XProgram.Engine;
using XProgram.Engine.Tasks;
using XProgram.Engine.Types;
using XProgram.Expressions.Boolean;

namespace XProgram.Tasks
{
    //static Task Factory

    public static class Tasks
    {
        //variable 
        public static DeclareVariable DeclareVariable(string name, XType type)
        {
            return new DeclareVariable(name, type);
        }

        public static DeclareVariable DeclareVariable(string name, XType type, Expression initialValue)
        {
            return new DeclareVariable(name, type, initialValue);
        }

        public static SetVariable SetVariable(string name, Expression exp)
        {
            return new SetVariable(name, exp);
        }

        public static Increment Increment(string name)
        {
            return new Increment(name);
        }

        //console
        public static ConsoleWrite ConsoleWrite(Expression exp)
        {
            return new ConsoleWrite(exp, false);
        }

        public static ConsoleWrite ConsoleWriteLine(Expression exp)
        {
            return new ConsoleWrite(exp, true);
        }

        //threading
        public static CreateThread CreateThread(string functionName)
        {
            return new CreateThread(functionName);
        }

        public static Sleep Sleep(Expression period)
        {
            return new Sleep(period);
        }


        //functions
        public static InvokeFunction InvokeFunction(string name)
        {
            return new InvokeFunction(name);
        }

        public static Return Return(Expression value)
        {
            return new Return(value);
        }

        //control statements
        public static While While(BooleanBase condition)
        {
            return new While(condition);
        }


        //utility
        public static DumpThread DumpThread()
        {
            return new DumpThread();
        }

        public static DumpProcess DumpProcess()
        {
            return new DumpProcess();
        }


    }
}
