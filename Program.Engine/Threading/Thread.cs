using System;
using System.Collections.Generic;
using System.Text;

namespace XProgram.Engine.Threading
{
    internal class Thread : IDisposable
    {
        [ThreadStatic]
        private static Thread _current;
        private bool _mainThread;
        private System.Threading.Thread _physicalThread;

        private Process _process;
        private CallStack _callStack;
        private Function _entryFunction;

        public Thread()
        {
            _callStack = new CallStack();
        }

        public Thread(Process process) : this()
        {
            if (_current != null)
                throw new Exception("Main thread cannot be started as a worker.");

            _mainThread = true;
            _process = process;
            _entryFunction = _process.Program.GetFunction(Constants.ENTRY_FUNCTION_NAME);
        }

        public Thread(string functionName) : this()
        {
            if (_current == null)
                throw new Exception("Caller physical thread is not attached.");

            _mainThread = false;
            _process = Thread.Current.Process;
            _entryFunction = _process.Program.GetFunction(functionName);
        }

        public static Thread Current
        {
            get { return _current; }
        }

        public bool MainThread
        {
            get { return _mainThread; }
        }

        public Process Process
        {
            get { return _process; }
        }

        public CallStack CallStack
        {
            get { return _callStack; }
        }

        public Variable GetVariable(string name)
        {
            //resolution process: (NOTE: local stack variable CAN hide program global variable)
            //1. lookup in current thread's current stackframe
            Variable v = CallStack.TopFrame.GetVariable(name);
            if (v != null)
                return v;

            //2. search for program globals
            v = _process.GetVariable(name);
            
            if (v == null)
                ProgramEngineException.Throw("Variable is not defined.");

            return v;
        }

        public static Thread CreateMain(Process process)
        {
            return new Thread(process);
        }

        public static Thread CreateNew(string functionName)
        {
            return new Thread(functionName);
        }

        public void Start(bool async)
        {
            if (_physicalThread != null)
                throw new ProgramEngineException("Thread already started.");

            System.Threading.ThreadStart ts = () =>
            {
                _current = this;
                _process.AddThread(this);

                try
                {
                    //invoke thread entry function
                    _entryFunction.Execute(new List<Expression>());
                }
                finally
                {
                    _process.RemoveThread(this);
                    _current = null;
                }
            };

            _physicalThread = new System.Threading.Thread(ts);
            _physicalThread.Start();
            if (!async)
                _physicalThread.Join();
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Thread ({_physicalThread.ManagedThreadId})");
            sb.Append(CallStack.GetInfo());
            return sb.ToString();
        }


        public void Dispose()
        {

        }
    }
}
