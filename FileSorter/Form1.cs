using System.Collections.Generic;

namespace FileSorter
{
    public enum FileSortMode { CreationDate, LastChangedDate}
    public partial class FileSorter : Form
    {
        public static String[] sortModeText = ["Erstelldatum", "Zuletzt geändert"];
        public static String[] filterModeText = ["Dateityp", "Erstellt", "Geändert", "Name beinhaltet"];
        public static int numberFilesFound = 0;
        public static int numberFilesSorted = 0;
        public FileSorter()
        {
            InitializeComponent();
            initSortModes();
            initFilterModes();
        }

        private void initSortModes()
        {
            foreach (String mode in sortModeText)
            {
                selectSortMode.Items.Add(mode);
            }
            selectSortMode.SelectedIndex = 0;
        }

        private void initFilterModes()
        {
            foreach (String mode in filterModeText)
            {
                comboBoxFilter.Items.Add(mode);
            }
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
            if (String.IsNullOrEmpty(textBoxSource.Text) || String.IsNullOrEmpty(textBoxDestination.Text))
                MessageBox.Show("Bitte Quelle und Ziel auswählen");

            numberFilesFound = 0;
            numberFilesSorted = 0;

            if(selectSortMode.SelectedIndex == 0)
            {
                sortByDate(FileSortMode.CreationDate);
            }
            if(selectSortMode.SelectedIndex == 1)
            {
                sortByDate(FileSortMode.LastChangedDate);
            }
            MessageBox.Show(numberFilesFound + " Dateien gefunden\ndavon " + numberFilesSorted + " sortiert");
        }

        private void sortByDate(FileSortMode fileSortMode)
        {
            DirectoryInfo dirInfoSrc = new DirectoryInfo(textBoxSource.Text);
            DirectoryInfo dirInfoDst = new DirectoryInfo(textBoxDestination.Text);

            FileInfo[] files = dirInfoSrc.GetFiles();
            HashSet<String> subDirsDst = getDirectoryNames(dirInfoDst.GetDirectories()); 
            foreach (FileInfo file in files)
            {
                numberFilesFound++;
                if(comboBoxFilter.SelectedIndex == 0 && !file.Extension.Equals(textBoxFileType.Text))
                {
                    continue;
                }
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
                numberFilesSorted++;
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
