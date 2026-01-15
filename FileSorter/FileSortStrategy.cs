namespace FileSorter
{
    public abstract class FileSortStrategy
    {
        public abstract String folderName(FileInfo file);
    }

    public class DateSortStrategy : FileSortStrategy
    {
        public readonly FileSortDate fileSortDate;
        public DateSortStrategy(FileSortDate fileSortDate)
        {
            this.fileSortDate = fileSortDate;
        }
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

    public class YearSortStrategy : FileSortStrategy
    {
        public readonly FileSortDate fileSortDate;
        public YearSortStrategy(FileSortDate fileSortDate)
        {
            this.fileSortDate = fileSortDate;
        }

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

    public class FileNameSortStrategy : FileSortStrategy
    {
        public readonly string fileNamePattern;
        public readonly string folderNamePattern;

        public FileNameSortStrategy(string fileNamePattern, string folderNamePattern)
        {
            this.fileNamePattern = fileNamePattern;
            this.folderNamePattern = folderNamePattern;
        }

        public override string folderName(FileInfo file)
        {
            String[] variables;
            if (!Utils.parseVariables(Path.GetFileNameWithoutExtension(file.FullName), fileNamePattern, out variables))
                return "";
            else
            {
                String res = folderNamePattern;
                for (int i = 0; i < variables.Length; i++)
                {
                    String variableInRes = "?" + (i + 1);
                    if (!res.Contains(variableInRes))
                        return "";
                    else
                        res = res.Replace(variableInRes, variables[i]);
                }
                if (res.Contains('?')) //if variables in folder couldn't be resolved
                    return "";
                return res;
            }
        }
    }
}
