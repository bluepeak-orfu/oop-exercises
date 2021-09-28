using System;
using OOGrunderExercises;

//Person person1 = new Person("Olle", 12);
//Person person2 = new Person("Olga", 33);

//Account account = new Account();
//account._amount = 1234.56;


//// Exercise: mer konstruktorer - 2
//Product product1 = new();
//Product product2 = new(10);

//// Exercise: methods - 2
//Additor additor = new Additor(2, 3);
//int result = additor.Add();
//Console.WriteLine($"Result: {result}");
//Console.WriteLine($"Result: {new Additor(2, 3).Add()}");

//// Exercise: methods - 3
//Subtractor subtractor = new Subtractor();
//int result = subtractor.Compute(3, 2);
//Console.WriteLine($"Result: {result}");



// Klasser – metoder 2 - 1
Movie m1 = new Movie("Abc");
m1.PersonSeenMovie();
m1.PersonSeenMovie();
m1.PersonSeenMovie();
m1.PersonSeenMovie();
string description = m1.DescribeMovie();
Console.WriteLine(description);

// Klasser – metoder 2 - 2
Person p1 = new Person("Pelle", 12);
Console.WriteLine($"Person age: {p1.GetAge()}");
p1.SetAge(37);
Console.WriteLine($"Person age: {p1.GetAge()}");
p1.SetAge(101);
Console.WriteLine($"Person age: {p1.GetAge()}");
p1.SetAge(-5);
Console.WriteLine($"Person age: {p1.GetAge()}");

// Klasser – metoder 2 - 3
IntPair ip1 = new IntPair(5, 0);
Console.WriteLine($"ip1: {ip1.GetAverage()}");
ip1.SetValue2(5);
Console.WriteLine($"ip1: {ip1.GetAverage()}");

