using System;
using System.Collections.Generic;
using System.Text;

using XProgram.Core;

namespace XProgram.Engine.Threading
{
    internal class StackFrame : IDisposable
    {
        private string _functionName;
        private Stack<Scope> _scopes;

        public StackFrame(string functionName)
        {
            _functionName = functionName;
            _scopes = new Stack<Scope>();
        }

        internal string FunctionName
        {
            get { return _functionName; }
        }

        internal Scope TopScope
        {
            get
            {
                Scope topScope = null;
                if (!_scopes.TryPeek(out topScope))
                    ProgramEngineException.Throw("Critical error. No scopes on stackframe.");

                return topScope;
            }
        }

        internal Scope AddScope()
        {
            Scope scope = new Scope();
            _scopes.Push(scope);

            return scope;
        }

        internal void RemoveScope(Scope scope)
        {
            if (TopScope != scope)
                ProgramEngineException.Throw("Critical Error. Invalid Scope.");

            _scopes.Pop();
        }

        internal Variable GetVariable(string name)
        {
            foreach (Scope scope in _scopes)
            {
                Variable v = scope.GetVariable(name);
                if (v != null)
                    return v;
            }

            return null;
        }

        internal string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Function: {_functionName}");
            foreach (Scope s in _scopes)
            {
                sb.AppendLine(s.GetInfo().Indent());
            }
            sb.RemoveLastChar();
            return sb.ToString();
        }

        public void Dispose()
        {
            Thread.Current.CallStack.RemoveFrame(this);
        }
    }
}