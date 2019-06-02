using System;

namespace functionalIdiomsInOO
{
    class Program
    {
        static void Main(string[] args)
        {
            example1();
            example2();
        }

        static void example1() {
            int i = 10;

            var composing = 
                new Composer<int, int>(x => x + 1)
                    .Then(y => y * y)
                    .Apply(i)
                    .Get();

            var forwarding = 
                new Pipe<int>(i)
                    .Forward(x => x + 1)
                    .Forward(y => y * y)
                    .Get();

            Console.WriteLine("Composing: " + composing + "\nForwarding " + forwarding);
        }

        static void example2() {
            var half = Composer<int, int>
                            .Curried<int,int>((y, x) => x / y)
                            .Apply(2)
                            .Get();

            var result = half(10);
            Console.WriteLine("10 / 2 = " + result);
        }
    }
}
