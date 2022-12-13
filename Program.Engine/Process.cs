using System;
using System.Collections.Generic;
using System.Text;

using XProgram.Core;
using XProgram.Engine.Threading;

namespace XProgram.Engine
{
    public class Process
    {
        private ProcessState _state;
        private Program _program;
        private List<Thread> _threads;
        private Dictionary<string, Variable> _variables;    //global variables

        public Process(Program program)
        {
            _state = ProcessState.New;
            _program = program;
            _threads = new List<Thread>();
            _variables = new Dictionary<string, Variable>();
        }

        public int ExitCode
        {
            get { throw new NotImplementedException(); }
        }

        public ProcessState State
        {
            get { return _state; }
        }

        internal Variable GetVariable(string name)
        {
            return _variables[name];
        }

        public void Dump()
        {
            lock (_threads)
            {
                //todo: dump thread info
            }
        }

        public void Start(bool async = true)
        {
            if (_state != ProcessState.New)
                throw new ProgramEngineException("Process already started.");

            Run(async);
        }

        private void Run(bool async = true)
        {
            //1. validation
            _program.Validate();

            //2. execution
            Execute(async);
        }

        private void Execute(bool async = true)
        {
            _state = ProcessState.Running;

            //allocate global variables
            foreach (VariableDefinition vd in _program.VariableDefinitions)
            {
                _variables.Add(vd.Name, vd.CreateVariable());
            }

            //create and start main thread
            Thread t = Thread.CreateMain(this);
            t.Start(async);
        }

        internal Program Program
        {
            get { return _program; }
        }

        internal void AddThread(Thread t)
        {
            lock (_threads)
            {
                _threads.Add(t);
            }
        }
        internal void RemoveThread(Thread t)
        {
            lock (_threads)
            {
                _threads.Remove(t);
                if (_threads.Count == 0)
                {
                    _state = ProcessState.Exited;
                }
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Process ({"PROC_ID"}, Program: {_program.Name})");
            sb.AppendLine($"State: {_state}");
            sb.AppendLine("Globals:");
            foreach (string vn in _variables.Keys)
            {
                sb.AppendLine(vn.Indent());
            }
            //todo: remove last char if no global
            sb.AppendLine("Threads:");
            foreach (Thread t in _threads)
            {
                sb.AppendLine(t.GetInfo().Indent());
            }
            //todo: remove last char if no thread
            return sb.ToString();
        }
    }
}
