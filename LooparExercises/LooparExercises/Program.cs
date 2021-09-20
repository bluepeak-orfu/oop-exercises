using System;

//// Exercise: Loopar - 1
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine("|");
//}

//// Exercise: Loopar - 2
//for (int i = 0; i < 10; i++)
//{
//    if (i % 2 == 0)
//    {
//        Console.WriteLine("/");
//    }
//    else
//    {
//        Console.WriteLine("\\");
//    }
//}

//// Exercise: Loopar - 2 (alternativ lösning)
//string format = "/";
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(format);
//    format = format == "/" ? "\\" : "/";
//}

//// Exercise: Loopar - 3
//for (int i = 0; i < 4; i++)
//{
//    if (i % 2 == 0)
//    {
//        // Raksöm
//        for (int j = 0; j < 10; j++)
//        {
//            Console.WriteLine("|");
//        }
//    }
//    else
//    {
//        // Sick-sack
//        for (int j = 0; j < 10; j++)
//        {
//            if (j % 2 == 0)
//            {
//                Console.WriteLine("/");
//            }
//            else
//            {
//                Console.WriteLine("\\");
//            }
//        }
//    }
//}
