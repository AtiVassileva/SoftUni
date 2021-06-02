using System.IO;
using Logger.Models.Contracts;

namespace Logger.Models.IOManagment
{
    public class IOManager : IIOManager
    {
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
             : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath =>
            this.currentPath + this.folderName;

        public string CurrentFilePath =>
            this.CurrentDirectoryPath + this.fileName;


        public string GetCurrentDirectory()
        {
            var directory = Directory.GetCurrentDirectory();
            return directory;
        }

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }
            // create directory

            File.WriteAllText(this.CurrentFilePath, string.Empty);
            // create new file by writing empty string in it
        }
    }
}
