﻿
using XProgram.Engine;

namespace XProgram.Expressions.Math
{
    public class Div : MathBase2
    {
        public Div(Expression left, Expression right) : base(left, right)
        {
        }

        protected override double Perform2(double v1, double v2)
        {
            return v1 / v2;
        }
    }
}
