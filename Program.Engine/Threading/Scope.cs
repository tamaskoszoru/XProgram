using System;
using System.Collections.Generic;
using System.Text;

using XProgram.Core;

namespace XProgram.Engine.Threading
{
    internal class Scope : IDisposable
    {
        private Dictionary<string, Variable> _variables;

        public Scope()
        {
            _variables = new Dictionary<string, Variable>();
        }

        internal void AddVariable(Variable v)
        {
            _variables.Add(v.Name, v);
        }

        internal Variable GetVariable(string name)
        {
            Variable v = null;
            _variables.TryGetValue(name, out v);

            return v;
        }

        internal string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("_scope:");
            foreach (string vn in _variables.Keys)
            {
                sb.AppendLine(vn);
            }
            sb.RemoveLastChar();
            return sb.ToString();
        }

        public void Dispose()
        {
            Thread.Current.CallStack.RemoveScope(this);
        }
    }
}
