using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace XProgram.Engine
{
    public class ProgramValidationContext : IDisposable
    {
        [ThreadStatic]
        private static ProgramValidationContext current = null;

        private Program _program;
        private List<string> _errors;
        private List<string> _warnings;
        private Stack<string> _path;

        internal ProgramValidationContext(Program program)
        {
            if (current != null)
                throw new Exception("ProgramValidationContext already installed.");

            current = this;
            _program = program;
            _path = new Stack<string>();
            _errors = new List<string>();
            _warnings = new List<string>();

            _path.Push($"Program ({_program.Name})");
        }

        public static ProgramValidationContext Current
        {
            get { return current; }
        }

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        public string Result
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Program validation result:");
                sb.AppendLine($"Errors: ({_errors.Count})");
                foreach(var item in _errors.Select((msg, idx) => new {Msg=msg, Idx=idx+1 }))
                {
                    sb.AppendLine($" {item.Idx}. {item.Msg}");
                }
                sb.AppendLine($"Warnings: ({_warnings.Count})");
                foreach (string msg in _warnings)
                {
                    sb.AppendLine($" - {msg}");
                }
                return sb.ToString();
            }
        }

        internal void AddError(string msg)
        {
            _errors.Add($"{msg}. Path: {GetPathTrace()}");
        }

        internal void AddWarning(string msg)
        {
            _warnings.Add(msg);
        }

        internal void PushPath(string item)
        {
            _path.Push(item);
        }

        internal void PopPath()
        {
            _path.Pop();
        }

        private string GetPathTrace()
        {
            string trace = "";
            foreach(string item in _path)
            {
                trace = trace + " -> " + item;
            }
            return trace;
        }

        //
        public bool HasFunction(string name)
        {
            return _program.HasFunction(name);
        }

        public Function GetFunction(string name)
        {
            return _program.GetFunction(name);
        }

        public bool HasVariable(string name)
        {
            throw new NotImplementedException();
            //todo: add support for variable resolution during Validation
        }

        //



        public void Dispose()
        {
            current = null;
        }
    }
}
