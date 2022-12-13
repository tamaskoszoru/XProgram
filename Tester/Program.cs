
using XProgram.Engine;
using XProgram.Engine.Types;
using XProgram.Expressions;
using XProgram.Tasks;

namespace Tester
{
    class Tester
    {

        static void Main(string[] args)
        {
            //1. add Program
            Program program1 =
                new Program("First program")
                    .AddFunction(
                        new Function("Main")
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("first program")))
                    );


            Program program2 =
                new Program("Second program")
                    .AddVariable("AX", XTypes.Number, 5)
                    .AddVariable("SX", XTypes.String, "globalis")
                    .AddFunction(
                        new Function("Main")
                                    .AddTask(Tasks.DeclareVariable("SX", XTypes.String, Expressions.Constant("lokalis")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("second program")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Variable("SX")))        //local var hides global
                                    .AddTask(Tasks.InvokeFunction("Test")                               //call function with param
                                                .AddArgument(Expressions.Constant(45))                  //function param1
                                     )
                    )
                    .AddFunction(
                        new Function("Test")
                                    .AddArgument("inputvar", XTypes.Number)   //function param1 definition
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("Test function..")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Variable("inputvar")))
                                    //.AddTask(Tasks.DumpProcess())
                                    .AddTask(Tasks.CreateThread("WorkerFunction"))
                                    .AddTask(Tasks.Sleep(Expressions.Constant(1000)))
                                    .AddTask(Tasks.Return(Expressions.Variable("AX")))
                    )
                    .AddFunction(
                        new Function("WorkerFunction")
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("Im on a worker thread")))
                                    .AddTask(Tasks.DumpProcess())
                    );


            //1. add Program
            Program program3 =
                new Program("Third program")
                    .AddFunction(
                        new Function("Main")
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Eq(
                                                                             Expressions.Constant(123),
                                                                             Expressions.Constant(124))
                                                                    )
                                    )
                                    .AddTask(Tasks.DeclareVariable("ret", XTypes.Bool))
                                    .AddTask(Tasks.SetVariable("ret", Expressions.Gt(
                                                                             Expressions.Constant(125),
                                                                             Expressions.Constant(124))
                                                                    )
                                    )
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Variable("ret")))
                    );


            // bool ret = !(12 > 13) || (12 == 13)
            Program program4 =
                new Program("4. program")
                    .AddFunction(
                        new Function("Main")
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                    .AddTask(Tasks.DeclareVariable("ret", XTypes.Bool))
                                    .AddTask(Tasks.SetVariable("ret", Expressions.Or(
                                                                        Expressions.Neg(
                                                                            Expressions.Gt(
                                                                                Expressions.Constant(12),
                                                                                Expressions.Constant(13)
                                                                            )
                                                                        ),
                                                                        Expressions.Eq(
                                                                            Expressions.Constant(12),
                                                                            Expressions.Constant(13)
                                                                        )
                                                                      )
                                                    )
                                    )
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Variable("ret")))
                    );

            //simple while loop
            /*
                number i=0;
                while(i<12)
                {
                    i++;
                }
            */
            Program program5 =
               new Program("5. program")
                   .AddFunction(
                       new Function("Main")
                                   .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                   .AddTask(Tasks.DeclareVariable("i", XTypes.Number, Expressions.Constant(0)))
                                   .AddTask(
                                            Tasks.While(
                                                            Expressions.Lt(
                                                                Expressions.Variable("i"),
                                                                Expressions.Constant(12)
                                                             )
                                            )
                                                .Add(Tasks.ConsoleWriteLine(Expressions.Variable("i")))
                                                .Add(Tasks.Increment("i"))
                                        )
                                );

            //nested while loops
            Program program6 =
               new Program("6. program")
                   .AddFunction(
                       new Function("Main")
                                   .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                   .AddTask(Tasks.DeclareVariable("i", XTypes.Number, Expressions.Constant(0)))
                                   .AddTask(
                                            Tasks.While(
                                                            Expressions.Lt(
                                                                Expressions.Variable("i"),
                                                                Expressions.Constant(5)
                                                             )
                                            )
                                                .Add(Tasks.DeclareVariable("j", XTypes.Number, Expressions.Constant(0)))
                                                .Add(
                                                Tasks.While(
                                                                Expressions.Lt(
                                                                    Expressions.Variable("j"),
                                                                    Expressions.Constant(5)
                                                                 )
                                                )
                                                    .Add(Tasks.ConsoleWriteLine(Expressions.StringFormat(Expressions.Constant("{0} + {1} = {2}"), Expressions.Variable("i"), Expressions.Variable("j"), Expressions.Add(Expressions.Variable("i"), Expressions.Variable("j")))))
                                                    .Add(Tasks.ConsoleWriteLine(Expressions.StringFormat(Expressions.Constant("{0} * {1} = {2}"), Expressions.Variable("i"), Expressions.Variable("j"), Expressions.Mul(Expressions.Variable("i"), Expressions.Variable("j")))))
                                                    .Add(Tasks.Increment("j"))
                                                )
                                                .Add(Tasks.Increment("i"))
                                        )
                                );


            //validation error
            Program program7 =
                new Program("Erronous program")
                    .AddFunction(
                        new Function("Main")
                                    .AddTask(Tasks.DeclareVariable("i", XTypes.String, Expressions.Constant(0)))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("HELLO WORLD")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("first program")))
                                    .AddTask(Tasks.InvokeFunction("Test")
                                        .AddArgument(Expressions.Constant(23))
                                    )
                                     .AddTask(Tasks.Sleep(Expressions.Constant(true)))
                    )
                    .AddFunction(
                        new Function("Test")
                                    .AddArgument("inputvar", XTypes.Number)   //function param1 definition
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Constant("Test function..")))
                                    .AddTask(Tasks.ConsoleWriteLine(Expressions.Variable("inputvar")))
                                    .AddTask(Tasks.CreateThread("WorkerFunction"))
                    );


            //start programs
            new Process(program6).Start();

            //Console.ReadLine();
        }
    }
}
