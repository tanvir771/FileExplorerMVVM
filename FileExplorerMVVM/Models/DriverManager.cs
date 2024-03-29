﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerMVVM.Models
{
    public class DriverManager : INotifyCollectionChanged
    {
        public ObservableCollection<Drive>? _drives = new ObservableCollection<Drive>();
        public event NotifyCollectionChangedEventHandler? CollectionChanged;


        public ObservableCollection<Drive> getDrives() {
            DriveInfo[] listDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in listDrives) {
                Drive tempDrive = new Drive();
                tempDrive.Name = "Drive " + drive.Name;
                tempDrive.FilePath = drive.Name;
                _drives.Add(tempDrive);
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            return _drives;
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

    }
}
