using System;
using System.IO;
using System.Text;

namespace FilesReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            NoteBook noteBook = new NoteBook();
            string[] notes = noteBook.GetAllNotes();
            Console.WriteLine("Present notes:");
            foreach (string note in notes)
            {
                Console.WriteLine(note);
            }

            while (true)
            {
                Console.WriteLine("Write note:");
                string input = Console.ReadLine();

                if (input == "")
                {
                    break;
                }

                noteBook.TakeNote(input);
            }
        }
    }
}
