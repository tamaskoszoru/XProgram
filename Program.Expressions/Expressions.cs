
using XProgram.Engine;
using XProgram.Expressions.Boolean;
using XProgram.Expressions.Boolean.Conditional;
using XProgram.Expressions.Boolean.Logical;
using XProgram.Expressions.Math;
using XProgram.Expressions.String;

namespace XProgram.Expressions
{

    //static expression factory:

    public static class Expressions
    {

        //base expressions 

        public static Constant Constant(object value)
        {
            return new Constant(value);
        }

        public static Variable Variable(string name)
        {
            return new Variable(name);
        }

        //conditional

        public static Eq Eq(Expression left, Expression right)
        {
            return new Eq(left, right);
        }
        public static NEq NEq(Expression left, Expression right)
        {
            return new NEq(left, right);
        }
        public static Gt Gt(Expression left, Expression right)
        {
            return new Gt(left, right);
        }
        public static Lt Lt(Expression left, Expression right)
        {
            return new Lt(left, right);
        }

        //...

        //logical
        public static Or Or(BooleanBase left, BooleanBase right)
        {
            return new Or(left, right);
        }
        public static And And(BooleanBase left, BooleanBase right)
        {
            return new And(left, right);
        }
        public static Neg Neg(BooleanBase exp)
        {
            return new Neg(exp);
        }


        //math
        public static Sqrt Sqrt(Expression exp)
        {
            return new Sqrt(exp);
        }
        public static Sqr Sqr(Expression exp)
        {
            return new Sqr(exp);
        }
        public static Add Add(Expression left, Expression right)
        {
            return new Add(left, right);
        }
        public static Sub Sub(Expression left, Expression right)
        {
            return new Sub(left, right);
        }
        public static Mul Mul(Expression left, Expression right)
        {
            return new Mul(left, right);
        }
        public static Div Div(Expression left, Expression right)
        {
            return new Div(left, right);
        }



        //string
        public static StringFormat StringFormat(Expression format, params Expression[] args)
        {
            return new StringFormat(format, args);
        }


        //todo..
    }
}
