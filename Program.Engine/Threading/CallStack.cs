using System.Text;

using XProgram.Core;

namespace XProgram.Engine.Threading
{
    internal class CallStack
    {
        private System.Collections.Generic.Stack<StackFrame> _frames;

        public CallStack()
        {
            _frames = new System.Collections.Generic.Stack<StackFrame>();
        }

        internal StackFrame TopFrame
        {
            get
            {
                StackFrame topFrame = null;
                if (!_frames.TryPeek(out topFrame))
                    ProgramEngineException.Throw("Critical error. No frames on callstack.");

                return topFrame;
            }
        }

        internal StackFrame AddFrame(string functionName)
        {
            StackFrame frame = new StackFrame(functionName);
            _frames.Push(frame);

            return frame;
        }

        internal void RemoveFrame(StackFrame frame)
        {
            if (TopFrame != frame)
                ProgramEngineException.Throw("Critical Error. Invalid Stackframe.");

            _frames.Pop();
        }

        internal Scope AddScope()
        {
            return TopFrame.AddScope();
        }

        internal void RemoveScope(Scope scope)
        {
            TopFrame.RemoveScope(scope);
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (StackFrame s in _frames)
            {
                sb.AppendLine(s.GetInfo().Indent());
            }
            sb.RemoveLastChar();
            return sb.ToString();
        }
    }
}
