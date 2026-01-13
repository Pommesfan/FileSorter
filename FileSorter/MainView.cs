namespace FileSorter
{
    public enum FileSortMode { CreationDate, LastChangedDate}
    public partial class FileSorter : Form
    {
        public static String[] sortModeText = ["Keine Sortierung", "Erstelldatum", "Zuletzt geändert"];
        public static int numberFilesFound = 0;
        public static int numberFilesSorted = 0;
        private FileAction fileAction;
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

            DirectoryInfo dirInfoSrc = new DirectoryInfo(textBoxSource.Text);
            DirectoryInfo dirInfoDst = new DirectoryInfo(textBoxDestination.Text);
            if (checkBoxCopyOnly.Checked)
                fileAction = new CopyAction(dirInfoDst.FullName);
            else
                fileAction = new MoveAction(dirInfoDst.FullName);
            sort(dirInfoSrc);
        }

        private void sort(DirectoryInfo dirInfoDst)
        {
            numberFilesFound = 0;
            numberFilesSorted = 0;

            int recursionDepth;
            if (!getRecursionDepth(out recursionDepth))
            {
                return;
            }
            HashSet<String> subDirsDst = getDirectoryNames(fileAction.getDirectories());
            sort_recursive(selectSortMode.SelectedIndex, subDirsDst, dirInfoDst, recursionDepth);
            MessageBox.Show(numberFilesFound + " Dateien gefunden\ndavon " + numberFilesSorted + " sortiert");
        }

        private void sort_recursive(int selection, HashSet<String> subDirsDst, DirectoryInfo dirInfoSrc, int recursionDepth)
        {
            FileInfo[] files = dirInfoSrc.GetFiles();
            foreach (FileInfo file in files)
            {
                numberFilesFound++;
                if (!filter(file))
                    continue;

                switch (selection)
                {
                    case 0:
                        noSort(file);
                        break;
                    case 1:
                        sortByDate(file, subDirsDst, FileSortMode.CreationDate);
                        break;
                    case 2:
                        sortByDate(file, subDirsDst, FileSortMode.LastChangedDate);
                        break;
                }
            }

            if (recursionDepth > 0)
            {
                int new_recursion_depth = recursionDepth - 1;
                DirectoryInfo[] dirs = dirInfoSrc.GetDirectories();
                foreach (DirectoryInfo newDirInfoSrc in dirs)
                {
                    sort_recursive(selection, subDirsDst, newDirInfoSrc, new_recursion_depth);
                }
            }
            else if (recursionDepth == -1) // allow limitless recursion
            {
                DirectoryInfo[] dirs = dirInfoSrc.GetDirectories();
                foreach (DirectoryInfo newDirInfoSrc in dirs)
                {
                    sort_recursive(selection, subDirsDst, newDirInfoSrc, -1);
                }
            }
        }

        private void noSort(FileInfo file)
        {
            fileAction.action(file, "");
            numberFilesSorted++;
        }

        private void sortByDate(FileInfo file, HashSet<String> subDirsDst, FileSortMode fileSortMode)
        {
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
                fileAction.createSubDirectory(dateString);
                subDirsDst.Add(dateString);
            }
            fileAction.action(file, dateString);
            numberFilesSorted++;
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
        private HashSet<String> getDirectoryNames(DirectoryInfo[] dirs)
        {
            HashSet<String> res = new HashSet<String>();
            foreach (DirectoryInfo dir in dirs)
            {
                res.Add(dir.Name);
            }
            return res;
        }
        private void sortInSubFolders_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkboxSortInSubFolders.Checked;
            layoutSearchDepth.Enabled = isChecked;
            if (!isChecked)
                textBoxSearchDepth.Clear();
        }
        private bool getRecursionDepth(out int recursionDepth)
        {
            recursionDepth = 0;
            if (checkboxSortInSubFolders.Checked)
            {
                if (textBoxSearchDepth.Text.Length == 0)
                {
                    recursionDepth = -1;
                    return true;
                }
                if (!int.TryParse(textBoxSearchDepth.Text, out recursionDepth))
                {
                    MessageBox.Show("Ungültiger Wert für Suchtiefe");
                    return false;
                }
            }
            return true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxSource.Text))
            {
                MessageBox.Show("Bitte Quelle auswählen");
                return;
            }

            DirectoryInfo dirInfoSrc = new DirectoryInfo(textBoxSource.Text);
            SortPreview sortPreview = new SortPreview();
            fileAction = new PreviewAction(sortPreview, sortPreview);
            sort(dirInfoSrc);

            sortPreview.ShowDialog();
        }
    }
}
