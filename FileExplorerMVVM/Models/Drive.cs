using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorerMVVM.Models
{
    public class Drive
    {
        // Attributes
        private string? _name;
        private string? _filePath;


        // Properties
        public string? Name { get; set; }
        public string? FilePath { get; set; }

        public ICommand? driveButtonClicked;

        public ICommand? DriveButtonClicked { get; set; }

    }
}
