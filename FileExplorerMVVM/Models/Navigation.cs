using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Models
{
    public class Navigation : INotifyCollectionChanged
    {
        private ObservableStack<String> _backwardsNavigation = new ObservableStack<String>();
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public void addBackwardsNav(String backwardsAddress)
        { 
            _backwardsNavigation.Push(backwardsAddress);
            Debug.WriteLine("Push from stack " + backwardsAddress);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, backwardsAddress));
        }

        public String lastAddress() 
        {
            String address = _backwardsNavigation.Pop();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, address));
            return address;
        }
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }
}
