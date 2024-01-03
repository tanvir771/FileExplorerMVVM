using FileExplorerMVVM.Models;
using Record_Book_MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace FileExplorerMVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<File> files { get; set; }
        public string? ImageURI;
        private FileManager myFileManager { get; set; }

        public ICommand? fileButtonClicked { get; }

        public MainViewModel()
        {
            myFileManager = new FileManager();
            files = myFileManager.getFiles(@"E:\");
            fileButtonClicked = new RelayCommand(FileClickedMethod, FileClickedCanExcecute);
            
        }

        private void FileClickedMethod(object sender) {
            File? tempFile = (File)sender;
            if (System.IO.Directory.Exists(tempFile.FilePath))
            {
                ObservableCollection<File> updatedFiles = myFileManager.getFiles(tempFile.FilePath);
                files = updatedFiles;
            }
            else {
                try
                {
                    Process.Start(new ProcessStartInfo(tempFile.FilePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private bool FileClickedCanExcecute(object sender) {
            return true;
        }
    }
}
