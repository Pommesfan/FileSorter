using System.Text.Json;

namespace FileSorter
{
    public class FileModel
    {
        public String sortSrc { get; }
        public String sortDst { get; }
        public FileFilter[] fileFilters { get; }
        public int sortInSubFolder { get; }
        public int sortMode { get; }
        public bool copyOnly { get; }

        public FileModel(String sortSrc, String sortDst, FileFilter[] fileFilters,  int sortInSubFolder, int sortMode, bool copyOnly)
        {
            this.sortSrc = sortSrc;
            this.sortDst = sortDst;
            this.fileFilters = fileFilters;
            this.sortInSubFolder = sortInSubFolder;
            this.sortMode = sortMode;
            this.copyOnly = copyOnly;
        }

        public String json()
        {
            return JsonSerializer.Serialize(this);
        }

        public static FileModel? fromJson(String json)
        {
            return JsonSerializer.Deserialize<FileModel>(json);
        }
    }
}
