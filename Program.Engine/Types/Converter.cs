namespace XProgram.Engine.Types
{

    /*
    public static class Converter
    {
        public static XValue Convert(XValue value, XType type)
        {
            if (value.Type == type)
                return value;

            if (type == Types.String)   //target type
            {
                if (value.Type == Types.Bool)
                    return new XValue(Types.String, value.RawValue.ToString());
                if (value.Type == Types.Number)
                    return new XValue(Types.String, value.RawValue.ToString());
            }
            if (type == Types.Bool)   //target type
            {
                if (value.Type == Types.String)
                    ProgramEngineException.Throw("Cant convert");
                if (value.Type == Types.Number)
                    ProgramEngineException.Throw("Cant convert");
            }
            if (type == Types.Number)   //target type
            {
                if (value.Type == Types.String)
                    ProgramEngineException.Throw("Cant convert");
                if (value.Type == Types.Bool)
                    ProgramEngineException.Throw("Cant convert");
            }
            throw new ProgramEngineException("Unknown type..");
        }
    }
    */
}
