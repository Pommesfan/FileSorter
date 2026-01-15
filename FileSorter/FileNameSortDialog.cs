using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class FileNameSortDialog : Form
    {
        public struct FileNameSortDialogRes
        {
            public readonly String fileName;
            public readonly String folderName;
            public FileNameSortDialogRes(String fileName, String folderName)
            {
                this.fileName = fileName;
                this.folderName = folderName;
            }
        }
        public FileNameSortDialog()
        {
            InitializeComponent();
        }
        public FileNameSortDialogRes Content
        {
            get
            {
                return new FileNameSortDialogRes(textBoxFileName.Text, textBoxFolderName.Text);
            }

            set
            {
                textBoxFileName.Text = value.fileName;
                textBoxFolderName.Text = value.folderName;
            }
        }
    }
}
