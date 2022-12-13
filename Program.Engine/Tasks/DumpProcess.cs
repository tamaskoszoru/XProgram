using System;

using XProgram.Engine.Threading;

namespace XProgram.Engine.Tasks
{
    public class DumpProcess : Task
    {
        public override void Execute()
        {
            Console.WriteLine(" ------- DUMP PROCESS ----------");
            Console.WriteLine(Thread.Current.Process.GetInfo());
            Console.WriteLine(" ------------------------------");
        }

        public override void Validate()
        {
        }
    }
}
