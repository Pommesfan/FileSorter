namespace FileSorter
{
    public enum FileSortDate { CreationDate, LastChangedDate}
    public partial class MainView : Form
    {
        public static int numberFilesFound = 0;
        public static int numberFilesSorted = 0;
        private String? currentUrlUserConfig = null;
        public MainView()
        {
            InitializeComponent();
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
            FileAction fileAction;
            if (checkBoxCopyOnly.Checked)
                fileAction = new CopyAction(dirInfoDst);
            else
                fileAction = new MoveAction(dirInfoDst);
            sort(dirInfoSrc, fileAction);
        }

        private void sort(DirectoryInfo dirInfoSrc, FileAction fileAction)
        {
            numberFilesFound = 0;
            numberFilesSorted = 0;

            int recursionDepth;
            if (!getRecursionDepth(out recursionDepth))
            {
                return;
            }
            HashSet<String> subDirsDst = getDirectoryNames(fileAction.getDirectories());
            sort_recursive(fileAction, subDirsDst, dirInfoSrc, recursionDepth);
            MessageBox.Show(numberFilesFound + " Dateien gefunden\ndavon " + numberFilesSorted + " sortiert");
        }

        private void sort_recursive(FileAction fileAction, HashSet<String> subDirsDst, DirectoryInfo dirInfoSrc, int recursionDepth)
        {
            FileInfo[] files = dirInfoSrc.GetFiles();
            foreach (FileInfo file in files)
            {
                numberFilesFound++;
                if (!filter(file))
                {
                    fileAction.addFilteredOut(file.Name);
                    continue;
                }
                sortIn(file, fileAction, subDirsDst);
            }

            if (recursionDepth > 0)
            {
                int new_recursion_depth = recursionDepth - 1;
                DirectoryInfo[] dirs = dirInfoSrc.GetDirectories();
                foreach (DirectoryInfo newDirInfoSrc in dirs)
                {
                    sort_recursive(fileAction, subDirsDst, newDirInfoSrc, new_recursion_depth);
                }
            }
            else if (recursionDepth == -1) // allow limitless recursion
            {
                DirectoryInfo[] dirs = dirInfoSrc.GetDirectories();
                foreach (DirectoryInfo newDirInfoSrc in dirs)
                {
                    sort_recursive(fileAction, subDirsDst, newDirInfoSrc, -1);
                }
            }
        }

        private void sortIn(FileInfo file, FileAction fileAction, HashSet<string> subDirsDst)
        {
            String s = "";
            for (int i = 0; i < fileSortStrategyPanel.Count; i++)
            {
                FileSortStrategy strategy = fileSortStrategyPanel[i];
                s += strategy.folderName(file) + "\\";
                if(!subDirsDst.Contains(s))
                {
                    subDirsDst.Add(s);
                    fileAction.createSubDirectory(s);
                }
            }
            fileAction.action(file, s);
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
            FileAction fileAction = new PreviewAction(sortPreview, sortPreview);
            sort(dirInfoSrc, fileAction);

            sortPreview.ShowDialog();
        }

        private void menuItemSaveIn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                save(dialog.FileName);
                currentUrlUserConfig = dialog.FileName;
            }
        }
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (currentUrlUserConfig != null)
                save(currentUrlUserConfig);
        }

        private void save(String fileName)
        {
            FileFilter[] fileFilters = new FileFilter[fileFilterPanel.Count];
            for (int i = 0; i < fileFilterPanel.Count; i++)
            {
                fileFilters[i] = fileFilterPanel[i];
            }

            int sortInSubfolders = 0; // -1 replesents selected search in subfolders but by no limit, -2 replesents no search in subfolders
            if (checkboxSortInSubFolders.Checked)
            {
                String text = textBoxSearchDepth.Text;
                if (text.Length == 0)
                {
                    sortInSubfolders = -1;
                }
                else
                {
                    if (!int.TryParse(text, out sortInSubfolders))
                    {
                        MessageBox.Show("Ungültiger Wert für Suchtiefe");
                        return;
                    }
                }
            }
            else
            {
                sortInSubfolders = -2;
            }
            FileModel fileModel = new FileModel(textBoxSource.Text, textBoxDestination.Text, fileFilters, sortInSubfolders, [], checkBoxCopyOnly.Checked);
            StreamWriter writer = new StreamWriter(fileName);
            String json = fileModel.json();
            writer.Write(json);
            writer.Close();
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                open(dialog.FileName);
                currentUrlUserConfig = dialog.FileName;
            }
        }

        private void open(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            FileModel? model;
            try
            {
                model = FileModel.fromJson(reader.ReadToEnd());
            }
            catch
            {
                MessageBox.Show("Fehler beim Öffnen");
                return;
            }
            Console.WriteLine();
            if (model == null)
            {
                MessageBox.Show("Fehler beim Öffnen");
            }
            else
            {
                textBoxSource.Text = model.sortSrc;
                textBoxDestination.Text = model.sortDst;
                int subfolders = model.sortInSubFolder;
                if (subfolders == -2)
                {
                    checkboxSortInSubFolders.Checked = false;
                }
                else if (subfolders == -1)
                {
                    checkboxSortInSubFolders.Checked = true;
                    textBoxSearchDepth.Text = "";
                }
                else
                {
                    checkboxSortInSubFolders.Checked = true;
                    textBoxSearchDepth.Text = subfolders.ToString();
                }
                //selectSortMode.SelectedIndex = model.sortMode;
                checkBoxCopyOnly.Checked = model.copyOnly;
            }
            reader.Close();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            fileFilterPanel.addFilter();
        }

        private void btnAddSortStrategy_Click(object sender, EventArgs e)
        {
            fileSortStrategyPanel.addSortStrategy(sender, e);
        }
    }
}
