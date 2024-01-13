using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Models
{
    public class ObservableQueue<T> : ObservableCollection<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
        }

        public T Dequeue()
        {
            if (_queue.Count == 0)
                throw new InvalidOperationException("The queue is empty.");

            T item = _queue.Dequeue();
            return item;
        }
    }
}
