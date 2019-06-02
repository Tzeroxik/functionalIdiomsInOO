using System;
using System.Collections.Generic;
using System.Text;

namespace functionalIdiomsInOO
{
    public class Pipe<T>
    {
        private T value;

        public T Get() { return value; }

        public Pipe(T value) {
            this.value = value;
        }

        public Pipe<O> Forward<O>(Func<T, O> f) {
            return new Pipe<O>(f(value));
        }
    }
}
