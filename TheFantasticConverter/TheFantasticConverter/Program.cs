using System;

while (true)
{
    Console.WriteLine("Välj något att konvertera (skriv en siffra):");
    Console.WriteLine("1. Valutor");
    Console.WriteLine("2. Längder");
    Console.WriteLine("3. Måttenheter");
    ConsoleKeyInfo input = Console.ReadKey(true);
    int categoryId = Convert.ToInt32(input.KeyChar.ToString());
    Console.WriteLine();

    switch (categoryId)
    {
        case 1:
            string[] currencies = new[] { "US Dollar", "Svenska kronor" };

            Console.WriteLine("Du har valt valutor");
            Console.WriteLine("Vilken valuta vill du konvertera från?");
            for (int i = 0; i < currencies.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currencies[i]}");
            }
            ConsoleKeyInfo inputFromUnit = Console.ReadKey(true);
            int fromUnitId = Convert.ToInt32(inputFromUnit.KeyChar.ToString());
            fromUnitId -= 1; // Convert from 1-indexing to 0-indexing
            Console.WriteLine();

            Console.WriteLine("Vilken valuta vill du konvertera till?");
            for (int i = 0; i < currencies.Length; i++)
            {
                if (i != fromUnitId)
                {
                    Console.WriteLine($"{i + 1}. {currencies[i]}");
                }
            }
            ConsoleKeyInfo inputToUnit = Console.ReadKey(true);
            int toUnitId = Convert.ToInt32(inputToUnit.KeyChar.ToString());
            toUnitId -= 1; // Convert from 1-indexing to 0-indexing
            Console.WriteLine();

            Console.WriteLine("Vilket belopp vill du konvertera?");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            double result;
            if (fromUnitId == 0 && toUnitId == 1)
            {
                result = amount / 0.12;
            }
            else if (fromUnitId == 1 && toUnitId == 0)
            {
                result = amount * 0.12;
            }
            else
            {
                result = -1;
            }

            if (result == -1)
            {
                Console.WriteLine("Kunde inte konvertera detta");
            } else
            {
                Console.WriteLine($"Det konverterade värdet är {result}");
            }

            break;
        case 2:
            string[] lengthUnits = new[] { "Meter", "Feets" };

            Console.WriteLine("Du har valt Längder");
            Console.WriteLine("Vilken längdenhet vill du konvertera från?");
            for (int i = 0; i < lengthUnits.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {lengthUnits[i]}");
            }
            ConsoleKeyInfo inputFromLength = Console.ReadKey(true);
            int fromLengthId = Convert.ToInt32(inputFromLength.KeyChar.ToString());
            fromLengthId -= 1; // Convert from 1-indexing to 0-indexing
            Console.WriteLine();

            Console.WriteLine("Vilken längdenhet vill du konvertera till?");
            for (int i = 0; i < lengthUnits.Length; i++)
            {
                if (i != fromLengthId)
                {
                    Console.WriteLine($"{i + 1}. {lengthUnits[i]}");
                }
            }
            ConsoleKeyInfo inputToLength = Console.ReadKey(true);
            int toLengthId = Convert.ToInt32(inputToLength.KeyChar.ToString());
            toLengthId -= 1; // Convert from 1-indexing to 0-indexing
            Console.WriteLine();

            Console.WriteLine("Vilket belopp vill du konvertera?");
            int lengthAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            double lengthResult;
            if (fromLengthId == 0 && toLengthId == 1)
            {
                lengthResult = lengthAmount * 3.280839895;
            }
            else if (fromLengthId == 1 && toLengthId == 0)
            {
                lengthResult = lengthAmount * 0.3048;
            }
            else
            {
                lengthResult = -1;
            }

            if (lengthResult == -1)
            {
                Console.WriteLine("Kunde inte konvertera detta");
            }
            else
            {
                Console.WriteLine($"Det konverterade värdet är {lengthResult}");
            }

            break;
        case 3:
            string[] volumeUnits = new[] { "Gallon (US)", "Litre" };

            Console.WriteLine("Du har valt måttenheter");
            Console.WriteLine("Vilken måttenhet vill du konvertera från?");
            for (int i = 0; i < volumeUnits.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {volumeUnits[i]}");
            }
            ConsoleKeyInfo inputFromVolume = Console.ReadKey(true);
            int fromVolumeId = Convert.ToInt32(inputFromVolume.KeyChar.ToString());
            fromVolumeId -= 1; // Convert from 1-indexing to 0-indexing
            Console.WriteLine();

            Console.WriteLine("Vilken måttenhet vill du konvertera till?");
            for (int i = 0; i < volumeUnits.Length; i++)
            {
                if (i != fromVolumeId)
                {
                    Console.WriteLine($"{i + 1}. {volumeUnits[i]}");
                }
            }
            ConsoleKeyInfo inputToVolume = Console.ReadKey(true);
            int toVolumeId = Convert.ToInt32(inputToVolume.KeyChar.ToString());
            toVolumeId -= 1; // Convert from 1-indexing to 0-indexing
            Console.WriteLine();

            Console.WriteLine("Vilket belopp vill du konvertera?");
            int volumeAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            double volumeResult;
            if (fromVolumeId == 0 && toVolumeId == 1)
            {
                volumeResult = volumeAmount * 3.785411784;
            }
            else if (fromVolumeId == 1 && toVolumeId == 0)
            {
                volumeResult = volumeAmount * 0.2641720523581484;
            }
            else
            {
                volumeResult = -1;
            }

            if (volumeResult == -1)
            {
                Console.WriteLine("Kunde inte konvertera detta");
            }
            else
            {
                Console.WriteLine($"Det konverterade värdet är {volumeResult}");
            }

            break;
        default:
            Console.WriteLine($"Unknown category {categoryId}");
            break;

    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Tryck på valfri tangent för att göra en ny konvertering");
    Console.ReadKey();
    Console.Clear();
}

