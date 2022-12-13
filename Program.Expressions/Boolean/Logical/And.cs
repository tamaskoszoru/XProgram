namespace XProgram.Expressions.Boolean.Logical
{
    public class And : LogicalBase
    {
        public And(BooleanBase left, BooleanBase right) : base(left, right)
        {
        }

        protected override bool Perform(bool v1, bool v2)
        {
            return v1 && v2;
        }
    }
}
