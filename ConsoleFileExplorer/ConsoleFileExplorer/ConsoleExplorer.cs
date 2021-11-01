using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileExplorer
{
    class ConsoleExplorer
    {
        private FolderView _currentView;

        public void Run()
        {
            _currentView = new FolderView(".");
            while (true)
            {
                string[] dirs = Directory.GetFileSystemEntries(".");
                foreach (string dirName in dirs)
                {
                    if (File.Exists(dirName))
                    {
                        Console.WriteLine($"- {Path.GetFileName(dirName)}");
                    }
                    else
                    {
                        Console.WriteLine($"# {Path.GetFileName(dirName)}");
                    }
                }
                //string[] fileNames = Directory.GetFiles(".");
                //foreach (string fileName in fileNames)
                //{
                //    Console.WriteLine($"- {Path.GetFileName(fileName)}");
                //}
                //List<string> currentContent = _currentView.GetFolderContent();
                //foreach (string item in currentContent)
                //{
                //    Console.WriteLine(item);
                //}

                Console.ReadKey();
            }
        }
    }
}
