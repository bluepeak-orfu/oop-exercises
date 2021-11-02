using System;
using System.IO;
using System.Text;

namespace FilesStreams
{
    class MyFileHandler
    {
        public void ReadAllContent()
        {
            FileStream fs = File.OpenRead("testfile1.txt");
            using (StreamReader reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine($"Line: {reader.ReadLine()}");
                }
            }
        }

        public void WriteContentToFile(string input)
        {
            FileStream fs = File.OpenWrite("testfile2.txt");
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(input);
            }
        }

        public void UpperCaseContent(string fromFile, string toFile)
        {
            FileStream readStream = File.OpenRead(fromFile);
            FileStream writeStream = File.OpenWrite(toFile);

            using (StreamReader reader = new StreamReader(readStream))
            {
                using (StreamWriter writer = new StreamWriter(writeStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string readFileLine = reader.ReadLine();
                        readFileLine = readFileLine.ToUpper();
                        writer.WriteLine(readFileLine);
                    }
                }
            }
        }

        public void ReadLatinEncodedContent()
        {
            using (FileStream fs = File.OpenRead("latin1.txt"))
            {
                int b;
                while ((b = fs.ReadByte()) != -1)
                {
                    Console.WriteLine(b);
                }
            }
        }
    }
}
