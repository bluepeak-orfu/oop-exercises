using System;
using MoreEnumExercises.Exercise1;
using MoreEnumExercises.Exercise2;
using MoreEnumExercises.Exercise3;

/*
    Läs README.me-filerna i mapparna Exercise1, Exercise2 och Exercise3
    för instruktioner vad som ska göra i denna övning.

    Du kan avkommentera koden här i Program.cs om du vill verifiera dina
    ändringar i uppgifterna.
*/

//// Exercise 1
//StovePlate stovePlate = new StovePlate();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'none'");
//stovePlate.IncreaseHeat();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'low'");
//stovePlate.IncreaseHeat();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'high'");
//stovePlate.IncreaseHeat();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'high'");

//stovePlate.DecreaseHeat();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'low'");
//stovePlate.DecreaseHeat();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'none'");
//stovePlate.DecreaseHeat();
//Console.WriteLine($"Heat is now: {stovePlate.Hotness}. Should be 'none'");



//// Exercise 2
//Avatar avatar = new Avatar();
//while (true)
//{
//    Console.WriteLine("Where should I go?");
//    string direction = Console.ReadLine();
//    avatar.Move(direction);
//    Console.WriteLine($"I'm currently at position {avatar.CurrentPosition}");
//}



//// Exercise 3
//TrafficLight trafficLight = new TrafficLight();
//Driver driver = new Driver(trafficLight);

//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: False");
//trafficLight.NextStatus();
//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: False");
//trafficLight.NextStatus();
//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: True");
//trafficLight.NextStatus();
//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: False");
//trafficLight.NextStatus();
//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: False");
//trafficLight.NextStatus();
//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: False");
//trafficLight.NextStatus();
//Console.WriteLine($"Can drive: {driver.CanGo()}. Should be: True");
