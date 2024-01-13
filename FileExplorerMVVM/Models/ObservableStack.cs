using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace FileExplorerMVVM.Models
{
    public class ObservableStack<T> : ObservableCollection<T>
    {
        private readonly Stack<T> _stack = new Stack<T>();
        public void Push(T item) 
        {
            _stack.Push(item);
        }

        public T Pop() 
        {
            T item = _stack.Pop();
            return item;
        }
    }
}
