using System;

namespace FilesStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFileHandler fileHandler = new MyFileHandler();
            //fileHandler.ReadAllContent();
            //fileHandler.WriteContentToFile("abc");
            //fileHandler.UpperCaseContent("testfile1.txt", "testfile3.txt");
            fileHandler.ReadLatinEncodedContent();
        }
    }
}
