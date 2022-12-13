using System;

using XProgram.Engine.Threading;

namespace XProgram.Engine.Tasks
{
    public class DumpThread : Task
    {
        public override void Execute()
        {
            Console.WriteLine(" ------- DUMP THREAD ----------");
            Console.WriteLine(Thread.Current.GetInfo());
            Console.WriteLine(" ------------------------------");
        }

        public override void Validate()
        {
        }
    }
}
