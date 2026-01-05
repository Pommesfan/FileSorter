using System.Collections.Generic;

namespace FileSorter
{
    public enum FileSortMode { CreationDate, LastChangedDate}
    public partial class FileSorter : Form
    {
        public FileSorter()
        {
            InitializeComponent();
        }

        private void selectLocation(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                String url = dialog.SelectedPath;
                if (sender == selectSource)
                {
                    textBoxSource.Text = url;
                }
                else if (sender == selectDestination)
                {
                    textBoxDestination.Text = url;
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if(selectSortMode.SelectedIndex == 0)
            {
                sortByDate(FileSortMode.CreationDate);
            }
            if(selectSortMode.SelectedIndex == 1)
            {
                sortByDate(FileSortMode.LastChangedDate);
            }
        }

        private void sortByDate(FileSortMode fileSortMode)
        {
            DirectoryInfo dirInfoSrc = new DirectoryInfo(textBoxSource.Text);
            DirectoryInfo dirInfoDst = new DirectoryInfo(textBoxDestination.Text);

            FileInfo[] files = dirInfoSrc.GetFiles();
            HashSet<String> subDirsDst = getDirectoryNames(dirInfoDst.GetDirectories()); 
            foreach (FileInfo file in files)
            {
                //determine which date to sort
                String dateString;
                if(fileSortMode == FileSortMode.CreationDate)
                {
                    dateString = file.CreationTime.ToShortDateString();
                }
                else if(fileSortMode == FileSortMode.LastChangedDate)
                {
                    dateString = file.LastAccessTime.ToShortDateString();
                }
                else
                {
                    throw new ArgumentException("FileSortMode not handled");
                }

                if(!subDirsDst.Contains(dateString))
                {
                    dirInfoDst.CreateSubdirectory(dateString);
                    subDirsDst.Add(dateString);
                }
                file.CopyTo(dirInfoDst.FullName + "\\" + dateString + "\\" + file.Name);
            }
        }

        private HashSet<String> getDirectoryNames(DirectoryInfo[]dirs)
        {
            HashSet<String> res = new HashSet<String>();
            foreach (DirectoryInfo dir in dirs)
            {
                res.Add(dir.Name);
            }
            return res;
        }
    }
}
