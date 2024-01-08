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
        // Properties
        public string? Name { get; set; }
        public string? FilePath { get; set; }

        public ICommand? driveButtonClicked;

        public ICommand? DriveButtonClicked { get; set; }

    }
}
