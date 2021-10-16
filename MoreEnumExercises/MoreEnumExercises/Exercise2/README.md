# Uppgift 2
I uppgift 2 finns det redan ett fungerande program. Avkommentera koden i
Program.cs för att provköra programmet. Det är dock lite jobbigt att behöva
skriv riktningen vi vill gå i. Vi skulle vilja ändra så att vi kan använda
piltangenterna i stället.

Din uppgift är att ändra så att avataren kan styra med piltangenterna. För att
åstadkomma det behöver vi använda något vi kollat på tidigare i kursen: ReadKey().
Console.ReadKey() läser in ett knapptryck från användaren. ReadLine läser bara in
bokstäver, siffror och andra synliga tecken. Vill vi läsa in andra knapptryck,
som till exempel piltangenterna, måste vi använda ReadKey.

Vi kollade på ReadKey tidigare i kursen men jag tror att vi saknade kunskap om
några koncept då för att fullt ut kunna förstå den då. När vi anropar metoden
ReadLine så får vi tillbaka en string men vad får vi tillbaka av att anropa
ReadKey? Vi har redan konstaterat att ReadKey kan läsa input som inte syns. Så
det skulle inte fungera att returnera en string. I stället så har .NET skapat
en klass för att representera ett knapptryck. Klassen heter ConsoleKeyInfo och
innehåller information om det knapptryck användaren precis gjort.

På klassen ConsoleKeyInfo finns en property som heter Key. Den är av speciellt
intresse för oss i den här övningen. Property:n Key har en enum-typ. Enum:en
heter ConsoleKey och de möjliga värdena på ConsoleKey motsvarar de olika
tangenterna på ett vanligt skrivbord.

De värden av ConsoleKey som är intressanta för oss är:
 * UpArrow
 * RightArrow
 * DownArrow
 * LeftArrow

Med informationen ovan om ReadKey och enum:en ConsoleKey. Försök ändra i koden
så att loopen i Program.cs läser in tryck på piltangenterna och skickar ett
värde av typen ConsoleKey till Avatar. Ändra även i Avatar så att Move-metodens
parameter är av typen ConsoleKey. Ändra sedan koden i Move så att den använder
värdena för piltangeter i stället för strängar.
