namespace FileSorter
{
    public abstract class FileSortStrategy
    {
        public abstract String folderName(FileInfo file);
    }

    public class DateSortStrategy(FileSortDate fileSortDate) : FileSortStrategy
    {
        public override string folderName(FileInfo file)
        {
            if(fileSortDate == FileSortDate.CreationDate)
            {
                return file.CreationTime.ToShortDateString();
            } else if(fileSortDate == FileSortDate.LastChangedDate)
            {
                return file.LastWriteTime.ToShortDateString();
            } else
            {
                throw new ArgumentException("value from enum FileSortDate not supported here");
            }
        }
    }

    public class YearSortStrategy(FileSortDate fileSortDate) : FileSortStrategy
    {
        public override string folderName(FileInfo file)
        {
            if (fileSortDate == FileSortDate.CreationDate)
            {
                return file.CreationTime.Year.ToString();
            }
            else if (fileSortDate == FileSortDate.LastChangedDate)
            {
                return file.LastWriteTime.Year.ToString();
            }
            else
            {
                throw new ArgumentException("value from enum FileSortDate not supported here");
            }
        }
    }
}
