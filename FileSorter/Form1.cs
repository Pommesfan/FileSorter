using System.Collections;
using System.Collections.Generic;

namespace FileSorter
{
    public enum FileSortMode { CreationDate, LastChangedDate}
    public partial class FileSorter : Form
    {
        public static String[] sortModeText = ["Erstelldatum", "Zuletzt geändert"];
        public static String[] filterModeText = ["Dateityp", "Erstellt", "Geändert", "Name beinhaltet", "Name beginnt mit"];
        public static int numberFilesFound = 0;
        public static int numberFilesSorted = 0;
        private List<FileFilter> fileFilters = new();
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

        private void initFilterModes(ComboBox comboBox)
        {
            foreach (String mode in filterModeText)
            {
                comboBox.Items.Add(mode);
            }
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

            if (selectSortMode.SelectedIndex == 0)
            {
                sortByDate(FileSortMode.CreationDate);
            }
            if (selectSortMode.SelectedIndex == 1)
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
                file.CopyTo(dirInfoDst.FullName + "\\" + dateString + "\\" + file.Name);
                numberFilesSorted++;
            }
        }

        private bool filter(FileInfo file)
        {
            foreach (FileFilter filter in fileFilters)
            {
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int currentIndex = layoutFilters.Controls.Count + 1;
            //create panel
            FlowLayoutPanel newFlowLayoutPanel = new FlowLayoutPanel();
            newFlowLayoutPanel.Name = "layoutFilter" + currentIndex;
            newFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            //create combobox
            ComboBox comboBoxNewFilter = new ComboBox();
            comboBoxNewFilter.Size = new Size(146, 23);
            comboBoxNewFilter.Name = "comboboxFilter" + currentIndex;
            comboBoxNewFilter.Tag = currentIndex;
            initFilterModes(comboBoxNewFilter);

            //create textbox
            TextBox filterArgs = new TextBox();
            filterArgs.Name = "textBoxFilterArgs" + currentIndex;
            filterArgs.Size = new Size(135, 23);
            filterArgs.Tag = currentIndex;

            //add all to panels
            newFlowLayoutPanel.Size = new Size(303, 30);
            newFlowLayoutPanel.Controls.Add(comboBoxNewFilter);
            newFlowLayoutPanel.Controls.Add(filterArgs);
            layoutFilters.Controls.Add(newFlowLayoutPanel);

            //reaction to select filter mode
            comboBoxNewFilter.SelectedIndexChanged += new EventHandler(onFilterChanged);
            filterArgs.TextChanged += new EventHandler(onFilterChanged);

            fileFilters.Add(null);
        }

        private void onFilterChanged(object? sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c == null)
                throw new ArgumentException("argument sender is no object of Control");
            int idx = ((int)c.Tag) - 1;
            FlowLayoutPanel layout = (FlowLayoutPanel)layoutFilters.Controls[idx];
            ComboBox comboBoxFilter = (ComboBox)layout.Controls[0];
            TextBox filterArgs = (TextBox)layout.Controls[1];
            String argument = filterArgs.Text;
            FileFilter fileFilter;
            switch(comboBoxFilter.SelectedIndex)
            {
                case 1:
                    fileFilter = new ExtensionFilter(argument);
                    break;
                case 3:
                    fileFilter = new NameContentsFilter(argument);
                    break;
                case 4:
                    fileFilter = new NameStartFilter(argument);
                    break;
                default:
                    fileFilter = null;
                    break;
            }
            fileFilters[idx] = fileFilter;
        }
    }
}
