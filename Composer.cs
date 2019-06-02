using System;
using System.Collections.Generic;
using System.Text;

namespace functionalIdiomsInOO
{
    public class Composer<X, O>
    {
        private Func<X, O> function;

        public Composer(Func<X, O> function) {
            this.function = function;
        }

        public static Composer<X, Func<Y,O>> Curried<Y, Z>(Func<X, Y, O> f) {
            return new Composer<X, Func<Y, O>>(x => y => f(x, y));
        }

        public Composer<X, Y> Then<Y>(Func<O, Y> g) {
            return new Composer<X, Y>(x => g(function(x)));
        }

        public Pipe<O> Apply(X value) { return new Pipe<O>(function(value)); }

        public Func<X, O> Get()
        {
            return this.function;
        }
    }
}
