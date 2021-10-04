using System;
using MinneshanteringExercises;

int x = 2;
double y = 0.34;

string q = "abc";
int[] w = new int[3];


int i1 = 8;
int i2 = 8;

if (i1 == i2)
{
    Console.WriteLine("Value type är lika");
}

MemoryDemo m1 = new MemoryDemo() { MyValue = 8 };
MemoryDemo m2 = new MemoryDemo() { MyValue = 8 };

if (m1 == m2)
{
    Console.WriteLine("Reference type är lika");
}

if (m1.MyValue == m2.MyValue)
{
    Console.WriteLine("Value type i Reference type är lika");
}
