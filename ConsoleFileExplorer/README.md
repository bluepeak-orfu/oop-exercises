# Uppgift 1
I den här uppgiften ska vi bygga en applikation som använder sig av
det vi lärt oss kring IO.

Applikationen ska lista innehåll i en mapp. Sen ska användaren kunna
välja att byta mapp. Då ska innehållet i den mappen visas i stället.
När användaren är i en mapp ska hen kunna välja att visa innehåll i
en fil, skapa en fil, samt ta bort filer.

## 1.1
Vi börjar med att lista innehållet i en mapp. Först skapar vi upp
en klass som kan vara centrum i vår applikation. Oftast vill man inte
ha så mycket kod i Main-metoden så vi skapar upp en separat klass för
att hantera huvud-loopen i vårt program.

Kalla klassen ConsoleExplorer. Skapa en metod i klassen som heter Run.
Metoden behöver inte ta någrar parametrar och ska inte returnera
någonting.

Implementera Run-metoden så att den listar alla filer och mappar i en
mapp. Du kan använda ```Directory.GetFileSystemEntries()``` för att
få tag på informationen. Den metoden kommer ge en lista på namnet på
filer och mappar under den mapp man skickar in till metoden.
Vi vill lista filer under den nuvarande mappen så ange en relative
sökväg till den nuvarande mappen.

För att skilja på filer och mappar i listan skriver vi ut ett
"#"-tecken framför mappar och ett "-"-tecken framför filerna.
Vi kan testa om ett element är en fil eller en mapp med
```File.Exists``` och ```Directory.Exists```.

Om du kör programmet nu kommer du se att den listar mappar och filer
men att varje mapp och fil skrivs ut med ett fult ".\" framför namnet.
Detta beror på hur Windows refererar till filer. Vi kan få bort det
med hjälp av ```Path.GetFileName```. Använd den på både mappar och
filer. Du borde få resultatet nedan om du gjort rätt.

```
- ConsoleFileExplorer.deps.json
- ConsoleFileExplorer.dll
- ConsoleFileExplorer.exe
- ConsoleFileExplorer.pdb
- ConsoleFileExplorer.runtimeconfig.dev.json
- ConsoleFileExplorer.runtimeconfig.json
- demofile1.txt
- demofile2.txt
- demofile3.txt
# demofolder
# ref
```

## 1.2
För att kunna implementera funktionerna i vår applikation måste vi
kunna identifiera en viss fil i listan vi skapade i 1.1. Vi vill
därför skapa en funktion som håller koll på vilket index i listan som
är valt just nu och markera det med en annan färg.

Börja med att skapa ett fält som håller koll på vilket index i listan
vi är på. Skapa därefter en evig-loop i Run-metoden (runt koden vi
skrev i 1.1). I loopen, efter att vi skrivit ut listan, ska vi läsa in
en Key från användaren (använd ReadKey). Om Key är ```DownArrow``` ska
vi öka index-variabeln med 1 och om Key är ```UpArrow``` ska vi
minska det med 1.

Vi måste också så till att vi inte går utanför listans giltiga index.
Så skriv koden så att index-fältet inte får vara lägre än 0 och inte
större än listans längd minus 1.

Lägg in en Console.Clear i början på den eviga-loopen.

Vi kan nu använda index-fältet i fil-loopen för att markera rätt
rad. Skriv ut listan som innan men när du kommer till den rad som
matchar index-fältets värde byter du färg och bakgrundsfärg i
consolen. Kom ihåg att byta tillbaka färgerna efter.

Med detta på plats borde du se att en rad i listan är markerad och
använda upp- och nerpilarna för att flytta markeringen upp och ner.

## 1.3
Koden i Run-metoden är inte så farligt lång än men vi kommer lägga
till flera funktioner så den kommer växa desto längre vi kommer i
uppgiften. Det kan därför vara bra att dela upp koden lite.

Förslagsvis flyttar vi ut koden för att lista innehållet i en mapp
till en egen klass. Jag skulle vilja kalla den Directory men det kan
bli rörigt eftersom vi använder en annan klass som heter detsamma.
Låt oss kalla vår nya klass ```FolderView```.

Börja med att skapa en metod i FolderView som heter PrintList och
lägg in koden som listar undermapparna och filerna i metoden. Ändra
i Run-metoden så vi först (innan eviga-loopen) skapar upp en instans
av FolderView och sen inne i loopen anropar PrintList. Om du kör
programmet nu borde den visa listan korrekt men inte hantera pil-
tangenterna.

Skapa två metoder i FolderView: Up och Down. Skapa ett fält för
indexet i FolderView-klassen. Implementera Up och Down så att de ökar
respektive minskar index fältets värde med 1. Ändra kodien i
PrintList så att den använder detta index-fält.

Ändra nu i Run-metoden så att när användaren trycker DownArrow så
anropas Down-metoden i FolderView och UpArrow anropar Up-metoden.

Nu borde vi ha samma funktioner som i 1.2 men delat på två filer med
en minimal implementation i Run-metoden.

## 1.4
Vi ska nu bygga en funktion för att visa innehållet i en fil.

För att göra detta behöver vi en sökväg till en fil. Sen kan vi helt
enkelt läsa ut innehållet i filen och sen skriva texten till consolen.
Vi vill också kunna backa tillbaka från filinnehållet till listan med
filer.

Vi börjar med att ändra Run-metoden så att den kan hantera detta. Den
generella idéen är att vi sätter ConsoleExplorer i ett specifikt
visningstillstånd och sen rendrerar om vyn. Att rendrera om vyn gör
vi redan tack varje den eviga loopen och Console.Clear().

Så vi vill skapa ett fält i ConsoleExplorer som håller koll på vilken
vy den ska visa. Här skulle vi kunna använda en enum. Skapa en enum
som heter ViewState. Enum:en ska ha två möjliga värden: List och
FileView. Skapa ett fält i ConsoleExplorer av typen ViewState. Kalla fältet
_viewState.

Använd _viewState i Run-metoden så att den kör den befintliga koden
om _viewState är List. Om _viewState är FileView ska vi hämta
innehåll från en fil.

För att hämta information från en fil måste vi veta vilken fil vi ska
hämta information i från. Vi vill att det ska vara den fil som är
vald i FolderView-instansen. Vi kommer dock inte åt det indexet.
Skapa därför en get-only property i FolderView som returnerar
filnamnet på den nuvarande valda raden. Namnge den CurrentFileName.
Du kommer förmodligen behöva ändra lite i din implementation i
FolderView för att ha tillgång till informationen du behöver. Det är
del av uppgiften att lista ut detta.

Med detta på plats borde du in Run-metoden kunna skriva kod som läser
ut filnamnet från din FolderView-instans och sen kan du använda File-
klassen för att hämta ut all text från filen.

Vi får inte glömma att skriva en ReadKey i vår kod så att programmet
stannar på vår FileView och inte loopar hela tiden. Skriv därför en
Console.ReadKey och efter den kan vi återställa _viewState till List.
Om vi gör det kommer loopen se till att vi kommer tillbaka till
listan.

TODO user input SPACE

## 1.5
Nu ska vi bygga funktionen för att navigera upp och ner i filträdet.
Här skulle vi kunna använda oss av FolderView-klassen. Den klassen
representerar just nu bara den nuvarande mappen men vi skulle kunna
ändra så att den kan representera vilken mapp som helst. Om vi gör
det så skulle vi kunna ändra _currentView till olika mappar och på
så sätt få våran Run-metod att visa innehållet i olika mappar.

Ta som exempel att vi är i mappen /a/b och under den mappen finns
/a/b/c. Om vår _currentView visar innehållet i /a/b så kan vi ändra
_currentView till /a/b/c och köra om loopen. Då blir det som att vi
navigerat ner en nivå i filträdet.

Börja med att skapa ett fält i FolderView för att spara vilken sökväg
instansen av FolderView ska lista. Skapa sedan en konstruktor som tar
in ett värde för fältet. Ändra sedan i PrintList så att den använder
fältet i stället för att alltid lista den nuvarande mappen.

TODO user input ENTER

## 1.6
Skapa en fil med ReadLine-input

## 1.7
Ta bort filer
