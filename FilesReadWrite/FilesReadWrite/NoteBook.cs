using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReadWrite
{
    class NoteBook
    {
        private readonly string _fileName = "notes.txt";

        public void TakeNote(string note)
        {
            string outputFormat = "{0,-24}{1}";

            if (!File.Exists(_fileName))
            {
                string[] headerInfo = new string[]
                {
                    $"{"Datum",-24}{"Note"}", // <-- string interpolation
                    //string.Format(outputFormat, "Datum", "Note"), // <-- string composition
                    new string('-', 60)
                };
                File.WriteAllLines(_fileName, headerInfo);
            }

            // String interpolation
            string output = $"{DateTime.Now.ToString(),-24}{note}";
            // String composition
            //string output = string.Format(outputFormat, DateTime.Now.ToString(), note);
            File.AppendAllText(_fileName, output + Environment.NewLine);
        }

        public string[] GetAllNotes()
        {
            string[] input = File.ReadAllLines(_fileName);
            return input[2..];
        }
    }
}
