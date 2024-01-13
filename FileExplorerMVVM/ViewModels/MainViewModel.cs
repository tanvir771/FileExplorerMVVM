﻿using FileExplorerMVVM.Models;
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
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace FileExplorerMVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<File>? files { get; set; }
        public ObservableCollection<Drive>? Drives { get; set; }
        public string? ImageURI;
        private FileManager? myFileManager { get; set; }
        private DriverManager? myDriveManager { get; set; }
        private Navigation? navigation { get; set; }
        public ICommand? fileButtonClicked { get; }
        public ICommand? DriveButtonClicked { get; }
        public ICommand? backButtonClicked { get; }


        public MainViewModel()
        {
            myFileManager = new FileManager();
            myDriveManager = new DriverManager();
            navigation = new Navigation();
            files = myFileManager.getFiles(@"E:\");
            navigation = myFileManager.getNavigationInfo();
            Drives = myDriveManager.getDrives();
            fileButtonClicked = new RelayCommand(FileClickedMethod, FileClickedCanExcecute);
            DriveButtonClicked = new RelayCommand(DriveClickedMethod, DriveClickedCanExcecute);
            backButtonClicked = new RelayCommand(BackClickedMethod, BackClickedCanExecute);
        }

        private bool BackClickedCanExecute(object obj)
        {
            return true;
        }

        private void BackClickedMethod(object obj)
        {
            string? previousFilePath;
            try
            {
                previousFilePath = navigation.lastAddress(); 
                if (System.IO.Directory.Exists(previousFilePath))
                {
                    ObservableCollection<File> updatedFiles = myFileManager.getFiles(previousFilePath);
                    files = updatedFiles;
                }
            } catch (InvalidOperationException)
            {
                // Do nothing
            }

        }

        private void DriveClickedMethod(object sender)
        {
            Drive tempDrive = (Drive)sender;
            if (System.IO.Directory.Exists(tempDrive.FilePath))
            {
                ObservableCollection<File> updatedFiles = myFileManager.getFiles(tempDrive.FilePath);
                files = updatedFiles;

            }
            else
            {
                // Why do this both here and in FileClickedMethod
                try
                {
                    Process.Start(new ProcessStartInfo(tempDrive.FilePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private bool DriveClickedCanExcecute(object sender)
        {
            return true;
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
