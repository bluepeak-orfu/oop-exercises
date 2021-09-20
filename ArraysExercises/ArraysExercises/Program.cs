using System;

// Exercise: array – Syntax - 1
double[] myDoubleArray = new double[8];

// Exercise: array – Syntax - 2
bool[] myBoolArray = new[] { false, true, false, true };

// Exercise: array – Syntax - 3
int[,] myTwoDimArray = new[,] { { 0, 1 }, { 1, 2 } };

// Exercise: array – Syntax - 4
int[] myIntArray = new int[] { 10, 20, 30, 40, 50 };
foreach (int myInt in myIntArray)
{
    Console.WriteLine($"myInt: {myInt}");
}
