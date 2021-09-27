using System;

// Läs in användaren namn till playerName
Console.WriteLine("Enter your name");
string playerName = Console.ReadLine();

int playerHP = 20;
int computerHP = 20;
bool isPlayersTurn = true;
int computerLastActionId = -1;

string[] actions = new string[] { "Attack", "Big Attack" };

// loopa medan båda spelarna är vid liv
while (true)
{
    // Skriv ut spelplanen
    Console.Clear();
    string playerStatus = $"{playerName} (HP: {playerHP})";
    string computerStatus = $"Computer 1 (HP: {computerHP})";
    Console.WriteLine($"{playerStatus, -30} {computerStatus, 30}");

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

    string playerTurnInfo = $"It's {(isPlayersTurn ? playerName : "Computer 1")}'s turn";
    string computerLastTurnAction = $"Computer 1's last action: {computerLastActionId}";
    Console.WriteLine($"{playerTurnInfo,-30} {computerLastTurnAction,30}");

    Console.WriteLine("------------------------------");
    for (int i = 0; i < actions.Length; i++)
    {
        string actionDisplayName = $"{i + 1}. {actions[i]}";
        Console.WriteLine($"| {actionDisplayName,-26} |");
    }
    Console.WriteLine("------------------------------");

    Console.WriteLine("Enter a number to perform an action");


    int action;
    // Om det är spelarens tur
    if (isPlayersTurn)
    {
        // Läs in användarens val till action
        ConsoleKeyInfo key = Console.ReadKey(true);
        action = Convert.ToInt32(key.KeyChar.ToString()) - 1;
    }
    else // Annars
    {
        // Vänta 500 ms innan nästa steg
        System.Threading.Thread.Sleep(500);
        // Slumpa fram motståndarens action
        action = new Random().Next(0, actions.Length);
        computerLastActionId = action;
    }


    // Beräkna skada på motstådaren
    int damage;
    switch (action)
    {
        case 0: // Normal attack
            // Om action är 1 beräkna skada till 2
            damage = 2;
            break;
        case 1:
            // Annars om action är 2 beräkna skada till 2 * (0 till 3)
            int randomModifier = new Random().Next(0, 4);
            damage = 2 * randomModifier;
            break;
        default:
            damage = 0;
            break;
    }

    // Applicera skada på den spelare vars turs det INTE är
    if (isPlayersTurn)
    {
        computerHP -= damage;
    }
    else
    {
        playerHP -= damage;
    }



    // Gå ur loopen om någon av spelarna har slut på liv
    if (playerHP <= 0 || computerHP <= 0)
    {
        break;
    }

    // Växla nuvarande spelare
    isPlayersTurn = !isPlayersTurn;
}

Console.WriteLine();
Console.WriteLine();

// Skriv ut vinnarens namn
if (computerHP <= 0)
{
    Console.WriteLine($"Player {playerName} won!");
}
else
{
    Console.WriteLine($"Computer 1 won!");
}
