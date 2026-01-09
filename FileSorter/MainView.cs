namespace FileSorter
{
    public enum FileSortMode { CreationDate, LastChangedDate}
    public partial class FileSorter : Form
    {
        public static String[] sortModeText = ["Keine Sortierung", "Erstelldatum", "Zuletzt geändert"];
        public static int numberFilesFound = 0;
        public static int numberFilesSorted = 0;
        public FileSorter()
        {
            InitializeComponent();
            initSortModes(selectSortMode);
        }

        private void initSortModes(ComboBox comboBox)
        {
            foreach (String mode in sortModeText)
            {
                comboBox.Items.Add(mode);
            }
            comboBox.SelectedIndex = 0;
        }

        private void selectLocation(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (sender == selectDestination)
                dialog.ShowNewFolderButton = true;
            else
                dialog.ShowNewFolderButton = false;


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
            {
                MessageBox.Show("Bitte Quelle und Ziel auswählen");
                return;
            }

            numberFilesFound = 0;
            numberFilesSorted = 0;
            int selection = selectSortMode.SelectedIndex;

            if(selection == 0)
            {
                noSort();
            }
            else if (selection == 1)
            {
                sortByDate(FileSortMode.CreationDate);
            }
            else if (selection == 2)
            {
                sortByDate(FileSortMode.LastChangedDate);
            }
            MessageBox.Show(numberFilesFound + " Dateien gefunden\ndavon " + numberFilesSorted + " sortiert");
        }

        private void noSort()
        {
            DirectoryInfo dirInfoSrc = new DirectoryInfo(textBoxSource.Text);
            DirectoryInfo dirInfoDst = new DirectoryInfo(textBoxDestination.Text);
            FileInfo[] files = dirInfoSrc.GetFiles();
            foreach (FileInfo file in files)
            {
                numberFilesFound++;
                if (!filter(file))
                    continue;
                copyOrMove(file, dirInfoDst.FullName + "\\" + file.Name);
                numberFilesSorted++;
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
                numberFilesFound++;
                if (!filter(file))
                    continue;
                //determine which date to sort
                String dateString;
                if (fileSortMode == FileSortMode.CreationDate)
                {
                    dateString = file.CreationTime.ToShortDateString();
                }
                else if (fileSortMode == FileSortMode.LastChangedDate)
                {
                    dateString = file.LastAccessTime.ToShortDateString();
                }
                else
                {
                    throw new ArgumentException("FileSortMode not handled");
                }

                if (!subDirsDst.Contains(dateString))
                {
                    dirInfoDst.CreateSubdirectory(dateString);
                    subDirsDst.Add(dateString);
                }
                copyOrMove(file, dirInfoDst.FullName + "\\" + dateString + "\\" + file.Name);
                numberFilesSorted++;
            }
        }

        private bool filter(FileInfo file)
        {
            for (int i = 0; i < fileFilterPanel.Count; i++)
            {
                FileFilter filter = fileFilterPanel[i];
                if (filter == null)
                    continue;
                if (!filter.validate(file))
                    return false;
            }
            return true;
        }

        private void copyOrMove(FileInfo file, String dst)
        {
            if(checkBoxCopyOnly.Checked)
            {
                file.CopyTo(dst);
            } else
            {
                file.MoveTo(dst);
            }
        }

        private HashSet<String> getDirectoryNames(DirectoryInfo[] dirs)
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
