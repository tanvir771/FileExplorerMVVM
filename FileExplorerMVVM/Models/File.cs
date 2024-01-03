using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;

namespace FileExplorerMVVM.Models
{
    public class File
    {
        private string? fileName;
        private string? filePath;
        public string? imageURI;

        public ICommand? fileButtonClicked;

        public string? FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

        public string? FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string? ImageURI
		{
			get { return imageURI; }
			set { imageURI= value; }
		}

               
        public ICommand FileButtonClicked {
            get {
                return fileButtonClicked;
            }
            set { 
                fileButtonClicked = value;
            }
        }

        public File(string fileName)
        {
            FileName = fileName;   
        }
    }
}
