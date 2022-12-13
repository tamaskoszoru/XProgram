
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    public abstract class Expression : IValidatable
    {
        public abstract XType ReturnType { get; }

        public virtual string GetName()
        {
            return this.GetType().Name;
        }

        public virtual void Validate()
        {
            //currently no validation for expressions, only runtime errors..
        }


        //public abstract Types.BaseType Type { get; }
        //only runtime at the moment...
        public abstract XValue Evaluate();


        public XValue EvaluateAs(XType type)  //evaluates and implicit converts to requested type
        {
            XValue ret = Evaluate();

            return ret.Convert(type);
        }
    }
}
