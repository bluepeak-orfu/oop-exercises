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
FileView. Skapa ett fält i ConsoleExplorer av typen ViewState. Kalla
fältet _viewState.

Använd _viewState i Run-metoden så att den kör den befintliga koden
om _viewState är List. Om _viewState är FileView ska vi hämta
innehåll från en fil.

Lägg till ett case i ReadKey-lösningen för upp och ner pil. Det nya
case:et ska hantera att användaren trycker på mellanslag (space).
Om användaren trycker på mellanslag ska vi byta _viewState till
FileView. Genom att göra denna ändring och sen låta koden köra vidare
kommer vi automatiskt uppdatera vyn med rätt innehåll. Vad som ska
hända när vi är i _viewState = FileView ska vi fixa härnäst.

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
stannar på vår FileView och inte loopar hela tiden. Lägg därför till
kod som skriver ut texten:

```Tryck på valfri tangent för att gå tillbaka till listan```.

Efter du skrivit ut texten kör vi en ReadKey för att stanna
programmet. Vi behöver inte titta på värdet av ReadKey utan använder
den bara för att stanna exekveringen. Efter användaren tryckt på en
tangent sätter vi tillbaka _viewState till List och låter programmet
köra vidare. Programmet kommer köra ett varv till i loopen, rensa
bort texten och skriva ut fillistan (eftersom _viewState=List).

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

Provkör programmet så att det fungerar på samma sätt som innan.

Nu är vi redo att byta ut instansen av _currentView. Lägg till ett
case i Run-metoden för när användaren trycker på enter-tangenten.
När användaren trycker på enter ska vi kolla på vilken mapp som är
vald i listan och skapa upp en ny instans av FolderView för den
mappen. Så om vi är i mappen /a/b och den valda mappen är "c" ska vi
bygga upp en sökväg för /a/b/c och skapa en FolderView-instans för
för den mappen.

Om vi sparar den nya instansen i _currentView och låter programmet
köra ett varv till i loopen så kommer vi få en lista av filer och
mappar i den mapp vi gick in i. Vilket är vad vi vill åstadkomma.

Jag är lite orolig för att programmet kommer bete sig konstigt om vi
använder relativa sökvägar i FolderView när vi navigerar upp och ner
flera gånger. Det är nog mer safe att använda absoluta sökvägar. Så
se till att när du bygger upp sökvägen för den nya FolderView-
instansen så gör du sökvägen absolut.

Provkör nu programmet. Använd piltangenterna för att navigera till
mappen "demofolder" och navigera sen in i den. Du borde få se en ny
listvy med bara en fil: demoFolderFile.txt.

Vi kan nu gå ner i strukturen men vi kan inte gå upp. Lägg till ett
till case i ReadKey-logiken i Run-metoden för Backspace-tangenten.
Här vill vi skapa en ny FolderView för mappen ovanför den nuvarande.
Om vi utgår från den nuvarande mappen så kan vi bygga en sökväg som
slutar på ".." för att gå upp en nivå. Glöm inte att konvertera den
till en absolut sökväg igen inna du skickar in den till FolderView.
FolderView ger oss inte access till den nuvarande sökvägen. Om du
inte gjort en public property förstås. Vi skulle oavsett vilja lägga
koden för att skapa sökvägen till föräldermappen i en egen property.
Så skapa en property i FolderView som heter ParentFolderPath.
Implementera propertyn så att den returnerar en sökväg till den
nuvarande mappens överliggande mapp. Använd sedan värdet för denna
property för att skap en FolderView som vi kan sätta i _currentView.

Med detta på plats borde du kunna navigera både ner och upp i
filträdet. Starta programmet och prova det.

## 1.6
Om du följt mina instruktioner exakt borde vi vara i ett läge där
Run-metoden är rätt lång. En tummregel är att en metod bara ska vara
som längst 7-10 tar lång. Om den är längre än det är det oftast en
bra idé att dela upp den för att öka kodens läsbarhet.

Så låt oss använda den här deluppgiften för att dela upp Run-metoden
i flera delar. Jag vet inte exakt hur du din kod ser ut vid det här
laget så du får bedömma själv om mina instruktioner fungerar på din
kod.

Vi kan börja med att lägga ut koden för varje visningsläge i en egen
metod. Så vi kan ha en privat metod som heter ShowList och en som
heter ShowFileContent. Flytta koden från if/switchen som bestämmer
vad som ska ritas ut i Run-metoden till dessa metoder och anropa
metoderna i stället.

Vi skulle också kunna flytta koden för att skapa nya FolderViews till
FolderView-klassen. Om en FolderView kan ge oss en ny FolderView-
instans för en anna mapp behöver vi bara tilldela värdet till
_currentView i Run-metoden. Det borde minska mängden kod i Run-
metoden en del.

Byt därför namn på propertyn ParentFolderPath till ParentFolder och
ändra dess implementation så att den skapar upp en instans av en
FolderView för den överliggande sökvägen. Returnera sen denna instans
och använd den i Run-metoden.

För att gå neråt har vi ingen property. Så först får vi skapa en i
FolderView. Kalla den CurrentSubFolder. Precis som ParentFolder ska
den skapa en instans av FolderView och returnera den men den här
instansen ska peka på den nuvarande valda undermappen. Använd sedan
denna property i Run-metoden.

Nu borde Run-metoden vara mer under kontroll. Kör programmet och
verifiera att det fortfarande fungerar.

## 1.7
En brist som finns i programmet nu är att vi kan navigera in i filer
och skriva ut textinnehållet i en mapp. Ingen av dessa operationer
kan fungera och kommer förmodligen resultera i ett exception om vi
försöker köra Enter eller Space på fel filtyp. Låt oss åtgärda detta.

Vi gör en enkel hantering av problemet. Innan vi försöker hämta
innehållet i en fil gör vi en kontroll att den valda raden är en
vanlig fil. Ett trick för att kolla detta är att använda
```File.Exists``` som bara returnerar true om filen finns och är en
vanlig fil (dvs, inte en mapp). Vi skulle vilja förhindra bytet av
_viewState om den nuvarande raden inte är en fil. Vi kanske inte har
tillräckligt med information för att veta detta så som koden är
skriven nu. Försök tänka ut hur vi kan lägga till kod så att det blir
tillgängligt.

Gör samma typ av kontroll för byte av mapp. Här kan vi använda
```Directory.Exists``` för att testa om en sökväg är en mapp.

## 1.7
Nu vill vi bygga en funktion för att skapa textfiler. När vi är i
listvyn ska det vara möjligt att skriva "c" och då hamna i ett
skapa fil-läge.

För att åstadkomma detta behöver vi ett nytt vytillstånd. Så lägg
till ett värde i ViewState-enumen som heter CreateFile. Lägg sedan
till ett villkor i Run-metoden som hanterar det nya värdet. Om
_viewState har värdet CreateFile vill vi anropa en ny metod som heter
CreateFile. Metoden ska först be användaren om ett namn för den nya
filen. Sen ska användaren få mata in hur många rader hen vill. Dessa
rader ska bli innehållet i filen. Inläsningen av rader ska stanna när
användaren skriver en tom rad.

Med namnet på filen och innehållet i filen tillgängligt är vi redo
att skapa filen. Filen ska skapas i den nuvarande mappen och ska heta
det namn som användaren angav.

När filen skapats ska metoden sätta tillbaka _viewState till List.

## 1.8
Den sista funktionen vi ska bygga är funktionen att ta bort en fil.
Att ta bort filer i programmering är lite läskigt då innehåll vi tar
bort är borta på riktigt. De hamnar inte i papperkorgen utan de är
borta för evigt. Det kan därför vara en bra idé att begränsa ta bort-
funktioner till att bara ta bort filer och inte mappar. Då minskar vi
skadan av ett avsiktligt borttag. Detta skydd är också inbyggt i C#:s
delete-funktion.

Vi vill bygga funktionen så att om vi i listvyn står på en fil och
trycker på "d" så ska filen tas bort. Innan vi tar bort filen ska vi
be användaren bekräfta att filen ska tas bort. Det ska inte heller
vara möjligt att ta bort mappar så funktionen ska bara fungera om vi
står på en fil i listvyn.

Upplägget är likt det vi gjorde i 1.7. Försökt själv tänka ut hur vi
ska implementera denna funktion.
