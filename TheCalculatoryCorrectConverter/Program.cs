using System;
Console.Title = ("The Calculatorily Correct Converter. Copyrighted. \u00a9");

string[][] menu = new string[4][];

menu[0] = new string[] { "Back", "Currencies", "Lengths", "Volumes" };
menu[1] = new string[] { "Back", "Dollar", "Argentinian Pesos", "Kronor", "UK Pound", "Canadian Dollar", "Indian Rupe" };
menu[2] = new string[] { "Back", "Meter", "Foot", "cm" };
menu[3] = new string[] { "Back", "cl", "dl", "l" };

double[][] conversion = new double[3][];

conversion[0] = new double[] { 8.68, 0.088, 1, 11.83, 6.83, 0.12};
conversion[1] = new double[] { 100, 30.48, 1};
conversion[2] = new double[] { 1, 10, 100 };


while (true)
{
    Console.Clear();
    Console.WriteLine("Pick the number corresponding to your chosen converter");
    for (int i = 1; i < menu[0].Length; i++)
    {
        Console.WriteLine($"{i}. {menu[0][i]}");
    }
    int firstMenuChoice = int.Parse(Console.ReadLine());
    Console.Clear();
    Console.WriteLine($"You have choosen {menu[0][firstMenuChoice]}");
    Console.WriteLine($"Which {menu[0][firstMenuChoice]} do you want to convert?");
    for (int i = 1; i < menu[firstMenuChoice].Length; i++)
    {
        Console.WriteLine($"{i}. {menu[firstMenuChoice][i]}");
    }
    Console.WriteLine($"Choose 0 for {menu[0][0]}");
    int secondMenuChoice = int.Parse(Console.ReadLine());
    Console.WriteLine($"You have choosen {menu[firstMenuChoice][secondMenuChoice]}");
    Console.WriteLine($"Which other {menu[0][firstMenuChoice]} do you want to convert with?");
    for (int i = 1; i < menu[firstMenuChoice].Length; i++)
    {
        if (i != secondMenuChoice)
        {
            Console.WriteLine($"{i}. {menu[firstMenuChoice][i]}");
        }
    }
    int thirdMenuChoice = int.Parse(Console.ReadLine());


    Console.WriteLine("Please enter the amount you want to convert");

    double amount = double.Parse(Console.ReadLine());
    double calculation = amount * (conversion[firstMenuChoice - 1][secondMenuChoice - 1] / conversion[firstMenuChoice - 1][thirdMenuChoice - 1]);
    Console.WriteLine($"{amount} {menu[firstMenuChoice][secondMenuChoice]} is equal to {calculation} {menu[firstMenuChoice][thirdMenuChoice]}");
    Console.ReadKey(true);
}