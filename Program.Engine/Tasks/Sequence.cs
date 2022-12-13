using System;
using System.Collections;
using System.Collections.Generic;

using XProgram.Engine.Threading;

namespace XProgram.Engine.Tasks
{
    public class Sequence : Task, IEnumerable<Task>
    {
        private List<Task> _tasks;

        public Sequence()
        {
            _tasks = new List<Task>();
        }

        public Sequence Add(Task task)
        {
            _tasks.Add(task);
            return this;
        }

        public override void Execute()
        {
            using (Scope scope = Thread.Current.CallStack.AddScope())
            {
                foreach (Task task in _tasks)
                {
                    task.Execute();
                }
            }
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
