using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileExplorer
{
    class FolderView
    {
        private string _path;

        public FolderView(string path)
        {
            _path = path;
        }

        public List<string> GetFolderContent()
        {
            List<string> result = new List<string>();
            string[] dirs = Directory.GetFileSystemEntries(".");
            foreach (string dirName in dirs)
            {
                if (File.Exists(dirName))
                {
                    result.Add($"- {Path.GetFileName(dirName)}");
                }
                else
                {
                    result.Add($"# {Path.GetFileName(dirName)}");
                }
            }
            return result;
        }
    }
}
