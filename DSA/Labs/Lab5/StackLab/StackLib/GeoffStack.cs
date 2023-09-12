using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StackLib
{
    public class GeoffStack<T>
    {
        private LinkedList<T> _myStack = new LinkedList<T>();

        public T Pop()
        {
            var temp = _myStack.First.Value;
            _myStack.Remove(temp);
            return temp;
        }
        public void Push(T item) => _myStack.AddFirst(item);
        public void Clear() { _myStack.Clear(); }
        public int Count => _myStack.Count();
        public T Peek() { return _myStack.First(); }
    }
}






//lab 3
//create custom class, [name]stack, encapsulate a LinkedList, expose Push, Pop, Clear, & Count


//Test:
//Copy test cases from lab 1 & use [Your] stack instead