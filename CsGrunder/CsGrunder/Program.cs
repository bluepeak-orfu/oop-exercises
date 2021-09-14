using System;
using System.Globalization;

// Exercise: Installera Visual Studio
//Console.WriteLine("What is your name?");



// Exercise: Input - part 1
//Console.WriteLine("What is your name?");
//var userName = Console.ReadLine();

//Console.WriteLine("Hej " + userName);



// Exercise: Input - part 2
//var var1 = Console.ReadLine();
//var var2 = Console.ReadLine();
//var var3 = Console.ReadLine();
//var output = var3 + " " + var2 + " " + var1;
//Console.WriteLine(output);


//// Exercise: Datatyper och matte - 1
//int x = 3;
//int y = 4;
//Console.WriteLine(3 + 4);

//// Exercise: Datatyper och matte - 2
//bool myBool = true;
//Console.WriteLine(myBool);

//// Exercise: Datatyper och matte - 3
//string myString = Console.ReadLine();
//Console.WriteLine(myString.Length + 10);

//// Exercise: Datatyper och matte - 4
//int a = 10;
//int s = 20;
//Console.WriteLine("Summan är: " + a + s);

//// Exercise: Datatyper och matte - 5
//double z = 0.1;
//double c = 0.2;
//Console.WriteLine(z + c);


//// Exercise: matte och typecasting - 1
//double x = 12345.6789;
//Console.WriteLine(x);
//Console.WriteLine((float)x);

//// Exercise: matte och typecasting - 2
//int y = 2_147_483_646;
//Console.WriteLine(y);
//Console.WriteLine(y++);
//y += 1;
//Console.WriteLine(y);


//// Exercise: matte och typecasting - 3
//ushort z = 65_535;
//Console.WriteLine(z);
//Console.WriteLine((short)z);


//// Exercise: konvertering och formatering - 1
//double tal1 = Convert.ToDouble(Console.ReadLine());
//double tal2 = Convert.ToDouble(Console.ReadLine());

//double result = (tal1 + tal2) / 2;

//Console.WriteLine(result.ToString("N3"));


//// Exercise: konvertering och formatering - 2
//double cel = Convert.ToDouble(Console.ReadLine());

//double far = cel * 1.8 + 32;

//Console.WriteLine($"Far {far:N1}");


//// Exercise: konvertering och formatering - 3
//string format = "{0,-20} {1,5}";
//Console.WriteLine(format, "Namn", "Ålder");
//Console.WriteLine("--------------------------");
//Console.WriteLine(format, "Pelle", 100);
//Console.WriteLine(format, "Olle", 12);
//Console.WriteLine(format, "Molly", 26);



//// Exercise: konvertering och formatering - 4
//double x = Convert.ToDouble(Console.ReadLine(), CultureInfo.GetCultureInfo("sv-SE"));
//Console.WriteLine(x.ToString("C", CultureInfo.GetCultureInfo("en-GB")));
