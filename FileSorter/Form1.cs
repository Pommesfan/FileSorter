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
            if(sender == selectDestination)
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
                if (!filter(file))
                    continue;
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

        private bool filter(FileInfo file)
        {
            int mode = comboBoxFilter.SelectedIndex;
            switch(mode)
            {
                case 0: break;
                case 1:
                    if(!file.Extension.Equals("." + textBoxFileType.Text))
                        return false;
                    break;
                case 2: break;
                case 3:
                    if(!Path.GetFileNameWithoutExtension(file.Name).Contains(textBoxFileType.Text))
                        return false;
                    break;
                case 4:
                    if (!Path.GetFileNameWithoutExtension(file.Name).StartsWith(textBoxFileType.Text))
                        return false;
                    break;
                default: break;
            }
            return true;
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
