using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FileExplorerMVVM.Models
{
    public class FileManager : INotifyCollectionChanged
    {
        private ObservableCollection<File> files = new ObservableCollection<File>();

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public ObservableCollection<File> getFiles(string path) {
            files.Clear();
            string[] filesString = Directory.GetFileSystemEntries(path);

            foreach (string file in filesString)
            {
                File temp = new File(System.IO.Path.GetFileName(file));
                temp.FilePath = file;
                files.Add(temp);

                // Refractor this - want it to be relative
                if (System.IO.File.Exists(file))
                {
                    temp.imageURI = "E:/Visual Studio Projects/WPFDemo/WPFDemo/Resources/file.png";
                }
                else
                {
                    temp.imageURI = "E:/Visual Studio Projects/WPFDemo/WPFDemo/Resources/folder.png";
                }
                
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            return files;
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
            CollectionChanged?.Invoke(this, e);
        }

        public FileManager()
        {

        }
    }
}
