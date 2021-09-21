using System;

//// Exercise: Console - 1
//while (true)
//{
//    ConsoleKeyInfo input = Console.ReadKey(true);

//    Console.WriteLine($"Key: {input.KeyChar}");
//}


//// Exercise: Console - 2
//int[] myIntArray = new[] { 12, 4321, 223366, 333, 76533 };

//Console.ForegroundColor = ConsoleColor.Yellow;
//foreach (int myInt in myIntArray)
//{
//    if (Console.BackgroundColor == ConsoleColor.Black)
//    {
//        Console.BackgroundColor = ConsoleColor.Blue;
//    }
//    else
//    {
//        Console.BackgroundColor = ConsoleColor.Black;
//    }
//    Console.WriteLine($"{myInt,-20}");
//    //Console.WriteLine("{0,-20}", myInt);
//}
//Console.ResetColor();

//// Example with "old school" for loop
//for (int i = 0; i < myIntArray.Length; i++)
//{
//    int myInt = myIntArray[i];
//    // My Code here
//}

//// Exercise: Console - 3
//string[] loadingChars = new[] { "|", "/", "-", "\\" };
//while (true)
//{
//    foreach (string item in loadingChars)
//    {
//        Console.Clear();
//        Console.WriteLine(item);
//        System.Threading.Thread.Sleep(200);
//    }
//}
