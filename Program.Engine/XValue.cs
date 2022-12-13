using System;

using XProgram.Core;
using XProgram.Engine.Types;

namespace XProgram.Engine
{
    public class XValue
    {
        private readonly XType _type;
        private readonly object _rawValue;

        public XValue(XType type, object rawValue)
        {
            type.EnsureValue(rawValue);
            _type = type;
            _rawValue = rawValue;
        }

        public XType Type
        {
            get { return _type; }
        }

        public object RawValue
        {
            get { return _rawValue; }
        }

        public XValue Convert(XType type)   //implicit conversions
        {
            return _type.Convert(this, type);
        }

        public new XValue ToString()
        {
            return new XValue(XTypes.String, _rawValue.ToString());
        }


        //
        public static XValue CreateFromRaw(object value)
        {
            if (value == null)
                ProgramEngineException.Throw("null");

            if (value.IsNumber())
                return new XValue(XTypes.Number, System.Convert.ToDouble(value));

            if (value is Boolean)
                return new XValue(XTypes.Bool, /*(bool)*/value);

            if (value is String)
                return new XValue(XTypes.String, /*(string)*/value);

            throw new ProgramEngineException("unknown raw type.");
        }
    }
}
