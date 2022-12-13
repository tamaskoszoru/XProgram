
using XProgram.Core;

namespace XProgram.Engine.Types
{
    public abstract class XType
    {
        public virtual void EnsureValue(object rawValue)
        {
            if (Guard.IsNull(rawValue))
                ProgramEngineException.Throw("Value cannot be null");
        }

        public abstract XValue Convert(XValue source, XType target); //implicit conversions
    }

    public sealed class BoolType : XType
    {
        internal BoolType()
        {
        }

        public override void EnsureValue(object rawValue)
        {
            base.EnsureValue(rawValue);

            if (!(rawValue is System.Boolean))
                ProgramEngineException.Throw("Invalid value. Not of required type. Cant build XValue.");
        }

        public override XValue Convert(XValue source, XType target)
        {
            if (source.Type != this)
                ProgramEngineException.Throw("invalid source xvalue");

            if (target == this)
                return source;
            //if (target == XTypes.String)
            //    return new XValue(XTypes.String, source.RawValue.ToString());

            throw new ImplicitConversionException("Cant implicitely convert Boolean to ...");
        }

    }

    public sealed class NumberType : XType
    {
        internal NumberType()
        {
        }

        public override void EnsureValue(object rawValue)
        {
            base.EnsureValue(rawValue);

            if (!(rawValue is System.Double))
                ProgramEngineException.Throw("Invalid value. Not of required type.");
        }

        public override XValue Convert(XValue source, XType target)
        {
            if (source.Type != this)
                ProgramEngineException.Throw("invalid source xvalue");

            if (target == this)
                return source;
            //if (target == XTypes.String)
            //    return new XValue(XTypes.String, source.RawValue.ToString());

            throw new ImplicitConversionException("Cant implicitely convert Number to ...");
        }
    }

    public sealed class StringType : XType
    {
        internal StringType()
        {
        }

        public override void EnsureValue(object rawValue)
        {
            base.EnsureValue(rawValue);

            if (!(rawValue is System.String))
                ProgramEngineException.Throw("Invalid value. Not of required type.");
        }

        public override XValue Convert(XValue source, XType target)
        {
            if (source.Type != this)
                ProgramEngineException.Throw("invalid source xvalue");

            if (target == this)
                return source;

            throw new ImplicitConversionException("Cant implicitely convert String to ...");
        }
    }

    //static Singleton Factory of available types
    public static class XTypes
    {
        private static NumberType _number;
        private static BoolType _bool;
        private static StringType _string;

        static XTypes()
        {
            _number = new NumberType();
            _bool = new BoolType();
            _string = new StringType();
        }

        public static NumberType Number
        {
            get { return _number; }
        }

        public static BoolType Bool
        {
            get { return _bool; }
        }

        public static StringType String
        {
            get { return _string; }
        }
    }
}
