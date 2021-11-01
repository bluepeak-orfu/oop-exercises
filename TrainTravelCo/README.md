# Uppgift 1
I den här uppgiften ska vi skapa ett bokningssystem för tågresor. Vi
kommer använda oss av en trelager-struktur i applikationen. De första
deluppgifterna kommer fokusera på att bygga upp grunddatan vi behöver
för att kunna söka och göra bokningar.

Det generella upplägget i applikationen kommer vara att vi har en
lista med tillgängliga resor. Vi kan lägga till nya resor och
användaren kan söka efter resor. När användaren hittat en resa hen
vill göra kan hen boka in sig på den resan. Resan håller sen koll på
vilka som bokat in sig på den. Runt resan kommer vi ha några andra
klasser som tillhandahåller information vi behöver för att boka
resor.

Även om den här uppgiften är skriven i steg kommer den inte vara lika
detaljerad som många tidigare uppgifter. Det är alltså del av
uppgiften att tänka ut lösningar för de delar som inte förklaras i
detalj.

## 1.1
Skapa först upp mapparna för de tre lagren och modellerna. Vi har
redan en mapp för controllers. Skapa upp en mapp som heter Managers
och en som heter Data samt en som heter Models.

## 1.2
Vi vill att data ska sparas i applikationen mellan requests. För att
göra detta ska vi använda en singleton i data-lagret. Skapa en klass
i Data-mappen som heter DataStore. Lägg till kod i DataStore så att
den blir en singleton. Se instruktioner i övningen WebApiMappings
för mer information.

## 1.3
Vi börjar med att skapa en klass för tåg. För att göra applikationen
lite enklare kan vi anta att loket och vagnarna är samma entitet.
Skapa en klass som heter Train i Models-mappen. Train ska spara
information om två saker: tågets registreringsnummer och max antal
plats som finns i tåget. Lägg även till så att Train har en property
Id som är unik för varje tåg. Kolla på uppgiften för Person-klassen
i WebApiMappings-uppgiften för inspiration.

## 1.4
I DataStore-klassen vill vi kunna lista alla tåg som finns i
applikationen samt spara nya tåg. Skapa därför två metoder i
DataStore. En för att spara ett tåg och en för att lista alla
befintliga tåg.

För att hålla koll på våra tåg ska vi spara dem i en lista inne i
DataStore-klassen. Metoden som sparar ett tåg ska alltså lägga till
tåget i listan och metoden som listar tåg ska bara returnera listan.

## 1.5
Vi vill nu lägga till möjligeten att lista och skapa tåg via webben.
Så skapa en controller som heter TrainController. Klassen ska hantera
sökvägen /train. Skapa metoder med routings för skapa och lista tåg.
Tänkt själv ut vilka attribut, parametrar och return-värden som ska
användas.

Eftersom vi inte har något koppling mellan controller och data-lager
än kan vi inte implementera metoderna ännu. Se deluppgift 1.6 för
detta.

## 1.6
Nu ska vi skapa en manager för tåg. Vi skulle kunna göra den till en
singleton precis som data-lagret men vi kommer inte spara någon data
i managern så vi kan lika gärna skapa upp en instans av managern i
controllern i stället.

Skapa en klass som heter TrainManager i Managers-mappen. TrainManager
ska ha metoder för att skapa och lista tåg, precis som controller-
klassen. Implementera metoderna så att de anropar DataStore för att
hämta listan med tåg och för att spara tåg.

## 1.7
Koppla nu samman TrainController med TrainManager. Gör detta genom
att skapa ett private fält av typen TrainManager i TrainController.
Skapa sedan en konstruktor i TrainController som skapar en ny instans
av TrainManager. Med detta fält på plats kan vi nu få TrainController
att skicka vidare anropen till create och list i TrainManager som i
sin tur skickar vidare till DataStore.

Prova att köra programmet. Skapa ett tåg och lista sedan alla tåg.
Har du gjort rätt kommer ditt tåg visas i listan.

# Uppgift 2
Det är nu dags att skapa den centrala dataklassen i applikationen:
Trip. En trip representerar en resa mellan två platser vid en given
tidpunkt. En trip kopplas till ett tåg så att vi vet vilket tåg resan
ska göras med. Vi kan också säkerställa att inte för många bokar in
sig på resan genom att kolla på tåget max antal platser. Trip ska
också ha en lista med alla bokningar som är gjorta på resan.

Innan vi skapar Trip måste vi skapa upp några andra data-klasser som
trip behöver.

## 2.1
Skapa upp en klass för en kund i Models-mappen. En kund ska ha ett
namn och ett telefonnummer.

Skapa upp en klass för en bokning. En bokning har ingen egen data
utan sparar bara en referens till kunden som gjort bokningen och
resan (trip) som bokningen gäller. Det ska alltså finnas två
properties som har typen för kund respektive trip.

## 2.2
Skapa nu klassen Trip. Klassen ska innehålla information om var tåget
åker i från och vad det ska åka till. Samt information om när det
avgör. Det går bra att spara alla tre grejerna som strängar.

En Trip ska också ha en koppling till det tåg resan ska göras med.
Klassen ska också ha en lista över alla bokningar som gjorts på resan.

Lägg även till så att Trip har en property Id som är unik för varje
trip. Kolla på uppgiften för Person-klassen i WebApiMappings-
uppgiften för inspiration.

## 2.3
Nu är det dags att lägga till stöd i DataStorage för att spara och
lista trips. Precis som med Train kan vi skapa ett fält som innehåller
en lista med Trips. Detta blir vår datakälla för Trips. Lägg till två
metoder, en för att spara trips och en för att lista trips.

## 2.4
Nu är vi redo för att göra en manager för Trip. Skapa en klass som
heter TripManager. TripManager ska vara lik TrainManager. Vi vill
kunna skapa nya trips och lista trips. Senare kommer vi också vilja
kunna filtrera listan med trips men vi spar det till sen.

Skapa två metoder i TripManager. En för att spara en trip och en för
att lista trips.

Att skapa en Trip är lite mer komplicerat än att skapa ett Train. En
Trip ska vara kopplat till ett Train. Så när vi skapar vår Trip måste
vi få tag på en befintlig instans av ett Train. För att hjälpa er på
vägen beskriver jag hur CreateTrip-metoden ska skrivas nedan.

Skapa metoden CreateTrip i TripManager. Metoden ska ta fyra
parametrar:
* start – en string vi använder för att sätta resans startpunkt
* destination – en string vi använder för att sätta resans slutpunkt
* departureTime – en string vi använder för att sätta resans starttid
* trainId – en int som anger ID på ett befintligt Train

Vi får in ett trainId men vi vill ha en instans av klassen Train. Så
vi måste läsa upp alla tåg från DataStorage och sen loopa över dem
för att hitta ett tåg med rätt Id. Hittar vi inget tåg som matchar
ID:t kan vi kasta ett exception. Om vi hittar ett tåg så har vi all
information vi behöver för att skapa en instans av Trip.

Så skapa nu en instans av Trip med data från parametrarna start,
destination och departureTime samt det Train vi hittade i steget
innan. Glöm inte att spara Trip-instansen i DataStorage.

## 2.5
Skapa nu en controller för Trip. Precis som med TrainController ska
den ha två metoder som kan ta emot webb requests. En för att skapa
trips och en för att lista trips. Sätt upp TripController på samma
sätt som TrainController.

TripController ska anropas TripManager för at skapa och lista Trips.
Från parametrarna i CreateTrip kan du lista ut vilken data som
måste skickas in till CreateTrip. Det kan vara läge för en DTO.

# Uppgift 3
Nu har vi allt på plats för att bygga de viktigaste funktionerna i
applikationen. En grej som är lite jobbig dock är att varje gång vi
startar om applikationen försvinner alla våra Trains och Trips.

För att undvika det här problemet skulle vi kunna skapa några Trains
och Trips i konstruktorn i DataStorage. Så när singleton:en skapas
lägger vi in lite information direkt i DataStorage. Detta skulle
göra testandet i nästa uppgift mycket smidigare.

Så skapa två Train och tre Trip och spara dem i listorna i
DataStorage-klassen.

# Uppgift 4
I den här uppgiften ska vi bygga sökfunktionen för möjliga resor.

## 4.1
Låt oss börja på manager-nivå. Vi skulle kunna skriva koden i
TripManager men för att göra applikationen flöde lite mer intressant
väljer vi att lägga sök- och bokningsfunktionerna i en egen manager.
Skapa därför en ny manager som heter BookingManager. I den nya
klassen ska vi ha en metod som heter Search. Till att börja med nöjer
vi oss med att bara kunna söka på avgångsplats (property:n start).
Lägg till en parameter i Search-metoden så att vi kan ta in ett värde
att söka på.

Implementera metoden så att den hämtar ut alla tillgängliga trips
och sen loopar igenom dem och letar efter trips som har en Start-
property med samma värde som parametern. Returnera sen en lista med
alla matchande Trips.

## 4.2
Skapa nu en controller som heter BookingController. Klassen ska ha en
metod som heter Search. Search-metoden ska svara på GET requests och
ta emot en parameter av typen strign som heter start. Lägg till ett
fält för BookingManager på samma sätt som du gjorde för Trip och
Train. Anropa Search-metoden i BookingManager och returnera
resultatet.

# Uppgift 5
I den här uppgiften ska vi bygga bokningfunktionen. I resultatet från
sökfunktionen i uppgift 4 får vi ett Id för varje trip. Vi kan
använda det ID:t för att boka en plats på resan. Vi måste också
skicka med information om personen som ska åka på resan.

Att göra en bokning innebär i koden att vi skapa en instans av
klassen Booking. Så vi vill skicka in information om en person och
ett Trip-ID till en controller som sen skickar vidare till en
manager som skapar och sparar bokningen.

## 5.1
Lägg till en metod i BookingManager som heter BookTrip. Metoden ska
ta ett Id för en trip och information om en användare. På samma sätt
som med Trip och kopplingen till Train måste vi här läsa ut den Trip
som motsvarar Id som skickades in.

När vi har en Trip-instans kan vi skapa upp bokningen med den
information vi har om kunden och resan. Kom ihåg att Trip-klassen har
en lista med alla bokningar så den nyskapade bokningen måste också
läggas till i listan i Trip-instansen.

Vi har ingen funktion för att spara bokningen i sig men eftersom den
är kopplad till Trip-instansen som i sin tur är sparad kommer
bokningen också vara sparad.

## 5.2
Lägg till en metod som heter BookTrip i BookingController. Metoden
ska svara på POST-requests och ta emot datan som beskrivits i
inledningen av den här uppgiften. Det kan vara läge att köra en DTO.

Anropa BookTrip i BookingManager med datan från POST-requesten.

## 5.3
Ett problem vi har nu är om vi försöker lista alla Trips. Vi har en
cirkelreferens mellan resan och bokningen. Resan innehåller en lista
med bokningar och varje bokning har en property som pekar tillbaka
till resan. Detta kommer få web api att fastna i en oändlig loop.

Vi måste därför ändra så listningen av Trips i TripController svarar
med en DTO-version av sin data istället för de klasser som har
cirkelreferensen.

När vi listar Trips vill vi ha information om bokningar men vi
behöver inte ha referensen tillbaka till resan. Så skapa en DTO för
bokninar som inte har med referensen till resa.

## 5.4
Vi vill förhindra att en resa överbokas. På Train kan vi se hur många
platser det finns på en resa. Uppdatera koden i BookTrip i
BookingManager så att den jämför längden på listan av bokningar med
tåget max kapacitet. Om tåget redan är fullbokat kastar vi ett
exception.

Ändra också i metoden Search i BookingManager så att den inte listar
resor som är fullbokade.

# Uppgift 6
Nu är applikationen klar att användas.

Om du vill kan du lägga till fler funktioner. T.ex.
* Möjlighet att hämta ut information om en (1) resa (i stället för en
  lista av alla)
* Möjlighet att hämta ut en specifik bokning (inkl. information
  om resan)
* Möjlighet att söka resor på flera värden. Söka på destinationen
  eller en kombination av start och destination.

# Uppgift 7 (ny uppgift för filhantering)
Nu när vi lärt oss om att jobba med filer kan vi bygga ett riktigt
datalager.

Vi vill spara information om tåg och resor (trip) i filer. Vi behöver
också spara information om bokningar och användare men det kan vi
göra tillsammans med resorna. Vi har ett val att göra om vi ska spara
all information om en typ av entitet i en fil eller om varje objekt
ska få en egen fil. Jag tänker att vi i denna uppgift spara varje
entitet i en egen fil så kan vi göra en till uppgift där vi sparar
dem i samma fil.

Vi kommer uppdatera den befintliga DataStore-klassen och eventuellt
göra korrigeringar i andra delar av koden.

## 7.1
För att hålla lite ordning så bör vi skapa våra filer i en mapp som
bara används för att spara våra filer. Vi kan därför börja med att
implementera så att när DataStore initieras (kom ihåg att det är en
singleton) så skapas en mapp som heter "data" om den mappen inte
redan finns. I denna mapp ska vi sen spara alla våra filer. Om mappen
redan finns innebär det att det redan finns data att hämta.

Du kan också ta bort testdatan från uppgift 3 så att inga tåg eller
resor skapas upp när DataStore instansieras.

## 7.2
Låt oss börja med funktionen för att spara tåg. Varje tåg ska ha en
egen fil. Vi måste bestämma vad filerna ska heta. Om de följer en
namnkonvention kan vi använda namnet för att identifera specifika tåg.

Vi namnger därför filerna som sparar tåg med namnet:

```
train_{trainId}.txt
```

I filen vill vi spara tågets tre properties: RegNumber, MaxSeats, och
Id. Vi har redan Id:t i filnamnet men det blir enklare att läsa in
tåget från filen om vi har all info i filen. Vi kan spara varje
property på en egen rad. Skriv värdena i ordningen: Id, RegNumber,
MaxSeats. Ex:

```
2
ABC123
64
```

När DataStore.SaveTrain anropas vill vi först skapa filnamnet. Gör
det genom att läsa ut Id-propertyn från tåget och bygg upp ett
filnamn enligt tidigare nämnd namnkonvention. Sen ska vi skriva
innehållet till filen. Gör detta så som du föredrar.
WriteAllText, WriteAllLines eller kanske en stream.

Kör programmet och försöker skapa ett tåg. Dyker det upp en fil i
data mappen? Har den rätt innehåll?

## 7.3
Nu ska vi bygga funktionen för att lista tåg. Vi vill läsa in alla
filer i data-mappen som börjar på strängen "train_". Det finns en
metod på strängar som heter StartsWith. Den passar bra för det vi
vill göra.

Så börja med att läsa in namnet på alla filer i data-mappen. Filtrera
sen listan så att vi bara har filnamn som börjar på "train_". Läs
sedan in texten från varje tåg fil. Välj själv hur du läser in dem.
Det viktiga är att vi till slut har de tre värdena för att skapa en
tåg-instans.

Att skapa tåg-instansen är lite speciellt då tåget i konstruktorn
sätter ett Id från den statiska räknaren. Vi skulle vilja undvika
detta när vi skapa tåg från en fil. Skapa därför en ny konstruktor
som tar in ett värde för Id-propertyn. Med två konstruktorer kommer
Web api fortfarande kunna skapa upp nya tåg-instanser med löpnummret
men vi kan samtidigt skapa upp tåg från kända Id:n.

Använd informationen du läst ut från filen och den nya konstruktorn
för att skapa en tåg-instans. ListTrains ska returnera en lista med
tåg så skapa en lista i metoden och lägg in alla tåg-instanser du
skapar i listan. Returnera sen listan.

Provkör programmet. Eftersom vi skapade tåg i 7.2 så borde endpointen
som listar tåg direkt kunna lista minst ett tåg (beroende på hur
många du skapade).

Nu när vi kan både spara och lista tåg behöver vi inte längre listan
med tåg i DataStore-klassen. Så ta bort den.

## 7.4
Nu ska vi bygga funktionen för att spara trips. Det är samma princip
som med tågen men Trip-klassen är lite mer komplex så vi får tänka
till hur vi ska formatera innehållet. Namnge filerna enligt
namnkonventionen:

```
trip_{tripid}.txt
```

För att spara en Trip måste vi först spara informationen om resans
startpunkt, destination, tidpunkt och ID. Dessa fyra värden är
vanliga strängar så vi kan spara dem precis som vi gjorde med Train.
Dvs, spara ett värde per rad. Bestämt själv ordningen på raderna.

Sen blir det lite mer oklart. Hur ska vi spara tåget och hur ska vi
spara listan med bokningar? För att göra uppgiften lite enklare kan
vi anta att tåget redan är sparad i en egen fil. Det gör att vi bara
behöver spara en referens till tågets ID i trip-filen. Så skriv ut
tågets ID på en egen rad i filen efter de 4 andra värdena.

En bokning innehåller information om vilken trip den tillhör samt
information om en kund. Vi håller redan på att spara trip:en så vi
behöver inte spara ner den informationen för varje bokningsobjekt.
Däremot behöver vi spara ner informationen om kunden. Vi skulle
kunna köra på en lösning där vi kan skilja på varje bokning men i det
här enkla datastrukturen räker det med att vi skriver ut dem efter
varandra i filen. Först skriver vi ut den första bokningens kundnamn
sen skriver vi ut den första bokningens kundtelefonnummer. Sen
skriver vi ut den andra bokningens kundnamn, osv. Om vi läser filen
kan det vara svårt att se vilket namn som hör till vilket
telefonnummer men det är inte så viktigt. Bara vi hanterar det
korrekt i ListTrips.

Loopa över alla bokningar och skriv ut dem enligt beskrivningen ovan.

Ex på en färdig fil:

```
1
Örebro
Kumla
2021-11-05
2
Erik
12345678
Erika
87654321
```

Starta programmet och prova att skapa några trips. Se att filerna för
trips skapas upp.

## 7.5
Nu ska vi bygga funktione för att lista tåg. Lösningen liknar den för
att lista tåg men eftersom datastrukturen i trip-filen är lite mer
komplex för vi tänka till lite extra vid uppläsningen.

Börja med samma upplägg som som tågen. Läs in alla filer, loopa och
filtrera listan. Läs ut de fyra första värdena från filen. Så långt
är det samma som Train-klassen. Kom ihåg att skapa en ny konstruktor
i Trip också. För att skapa en Trip-instans behöver vi också en
instans av Train. Vi har ID:t i filen så hur får vi tag på tåget?

Vi skulle kunna använda ListTrains och sen filtrera listan med tåg
men vi kör på en lite mer effektiv lösning i stället. Vi skapar en
metod som kan hämta ut ett specifikt tåg. Kalla metoden GetTrain och
låt den ta en int-parameter som är tågets ID. Med ID:t kan vi lista
ut vilken fil tåget borde finnas i. Så läs ut innehållet i den filen
och skapa en tåg-instans från den.

Med GetTrain kan vi nu sätta värden på alla properties i Trip förutom
bokningslistan. Om vi bara fortsätter att läsa rader från filen
skulle vi kunna skapa en loop som skapar upp en Booking-instans för
varje 2 rader som finns i filen. Sen kan vi lägga instanserna i en
lista av typen Booking och då har vi all information vi behöver för
att skapa en Trip. Lista själv ut hur man kan göra denna typ av loop.

Skapa en trip för varje trip-fil och lägg dem i en lista. Returnera
sen listan.

Starta programmet och testa att lista trips. Ser du de trips du
skapade i 7.4?

Nu behöver vi inte längre listan med trips i DataStore. Så du kan ta
bort den.

## 7.6
Nu är vi nästan klara men det finns ett problem som vi inte hade
när datan sparas i listor i minnet. Det är att när vi skapar en
bokning så uppdaterar vi trip-instansen. Vi lägger till bokningen i
Trip-instansen. Om vi inte säger åt datalagret att skriva ner denna
ändring till disk kommer bokningen inte sparas.

Prova detta innan vi fixar felet. Starta programmet och gör en
bokning på en av de trips du skapat innan. Lista sedan trips och
kolla om bokningen dyker upp. Den borde inte göra det.

Problemet är att vi inte explicit säger åt datalagret att spara vår
Trip-instans efter att den ändrats. Så gär en ändring i BookTrip i
BookingManager. Efter att du lagt in bokningen i Trip:s bokningslista
så måste du anropa SaveTrip i DataStore. Gör det och prova att göra
en bokning igen. Funkar det nu?

# Uppgift 8 (ny uppgift för filhantering)
Vi vill nu prova att spara tåg och resor i bara en fil per datatyp
men vi vill inte slänga koden vi skrivit i uppgift 7. Vi kan lösa
detta med arv. Vi vill konvertera DataStore att vara en abstrakt
klass och sen vill vi lägga våra olika implementationer i olika
implementerande klasser. I uppgift 9 kommer vi göra nästa
implementation för att spara filer. I denna uppgift kommer vi bara
förbereda lösningen för att kunna ha olika implementationer.

## 8.1
Börja med att göra DataStore till en abtract klass. Vi får nu problem
i singleton-koden. Vi kan inte längre skapa en instans av DataStore,
vilket är väntat.

Skapa därför en ny klass i namespace:et TrainTravelCo.Data som heter
MultiFileDataStore. Den nya klassen ska ärva från DataStore. Vi måste
också ändra konstruktorn i DataStore så att den tillåter att ärvande
klasser anropar den.

Flytta nu ner implementationerna för följande metoder till klassen
MultiFileDataStore:

```
ListTrains()
GetTrain(int trainId)
SaveTrain(Train train)
ListTrips()
SaveTrip(Trip trip)
```

Vi vill fortfarande kunna anropa dem på instanser av DataStore. Så
deklarera alla fem som abstrakta metoder i DataStore och override:a
dem i MultiFileDataStore.

Felet i singleton koden finns fortfarande kvar. Åtgärda det genom att
byta instansen vi skapar till en MultiFileDataStore.

Starta programmet och testa att det fortfarande fungerar. Om du gjort
rätt ska det fungera som innan.

## 8.2
Nu har vi byggt möjligheten att ha andra implementationer men vi
använder den inte. Vi skulle vilja ändra i property:n Instance i
DataStore så att den kan skapa olika implementationer av DataStore
beroende på en inställning.

För att bestämma vilken instans vi vill ha kan vi använda en enum.
Skapa en enum som heter DataStoreType. I nuläget ska den bara ha ett
möjligt värde: MultiFile. Skapa en ny property i DataStore av typen
DataStoreType. Propertyn ska både gå att läsa och sätta. Använd
propertyn i Instance-property-koden så att den bara skapar en instans
av MultiFileDataStore om värdet på den nya propertyn är MultiFile.

Lägg sedan till kod i Main-metoden (i Program.cs) som sätter värdet
på den nya propertyn till MultiFile.

Med detta på plats kan vi ändra implementation vi vill använda från
Main-metoden (även om vi bara har en (1) implementation).

# Uppgift 9 (ny uppgift för filhantering)
Nu ska vi testa ett alternativt sätt att spara data i filer. Vi ska
spara all information om tåg i en fil och all information om resor i
en fil.

## 9.1
Vi vill använda funktionen vi skapade i uppgift 8. Så skapa först en
ny klass som heter SingleFileDataStore som ärver från DataStore. Lägg
sedan till ett nytt värde i enumen DataStoreType: SingleFile.

Lägg till kod i Instance-propertn i DataStore så att den skapar en
instans av vår nya klass om enum-värdet är SingleFile.

Ändra sedan i Main-metoden så att DataStore försöker skapa upp en
instans av SingleFileDataStore.

Eftersom vi inte implementerat koden i SingleFileDataStore kommer
applikationen inte fungera i nuläget men det ska vi snart fixa.

## 9.2
Vi vill ha en mapp för att spara vår data här också. För att inte
krocka med vår andra data-mapp kan vi kalla den här mappen för data2.

Vi kan anta att alla filsparningar och läsningar nedan görs i denna
mapp.

## 9.3
Nu ska vi implementera stöd för att spara tåg. Flera tåg i en fil.
Formatet vi vill ha är att varje tåg sparas på en rad där värdena
skiljs av med komma-tecken. Ex med tre tåg:

```
0,ABC123,64
1,QWE321,32
2,ASD456,100
```

Eftersom vi inte har någon funktion för att uppdatera tåg kan vi anta
att samma såg aldrig kommer sparas mer än en gång. Så när vi ska
spara ett tåg behöver vi bara lägga till det i slutet på listan.

Implementera metoden så att den först sparar datan i en sträng med
komma-tecken mellan varje värde. Skriv sedan strängen till filen. Kom
ihåg att inte skriva över innehållet utan bara lägga till i slutet.
Spara innehållet till en fil som heter trains.txt.

Kör programmet och skapa några tåg. Kolla att de läggs till i filen.

## 9.4
Nu ska vi implementera stöd för att lista tåg.

Läs in alla rader från filen trains.txt och loopa över dem. Dela på
värdet på varje rad med Split()-metoden som finns på strängar. Efter
att du delat upp värdena borde du kunna skapa Train-instanser från
datan. Lägg dem i en lista och returnera listan.

Provkör programmet och verifiera att du ser tågen du skapade i 9.3.

## 9.5
Nu ska vi spara Trip-instanser. Precis som innan är det samma tänk
som med tåg men lite mer komplicerat.

Vi vill bygga upp en sträng av värden som vi sen kan dela upp igen
när vi läser tillbaka datan i list-metoden. De fyra värdena för ID,
startpunkt, destination och tidpunkt kan vi spara i en komma-
separerad sträng utan problem. Vi vill inte spara hela tåget men
vi kan göra som i uppgift 7 och bara spara tågets ID.

Hur gör vi med bokningarna? Det skulle rent tekniskt fungera att bara
skriva ut alla värden på raden med komma mellan varje namn och
telefonnummer. Det är dock inte så man brukar göra i denna typ av
lösning. I stället vill vi skapa en egen lista för bokningarna som
använder ett eget skiljetecken. Sen kan vi spara hela denna lista i
trips.txt men vi vill skilja på informationstyperna så att komma
används för att skilja på värden i Trip och ett annat tecken används
för bokningar. Vi kan använda "|" för att skilja på varje bokning i
listan och "&" för att skillja på namn och telefonnummer. Ex:

```
0,Örebro,Kumla,2021-11-05,2,erik&12345|erika&54321
```

Skriv kod som loopar över bokningarna och skapar upp den delen av
strängen. Lägg sedan till den i listan med de andra värdena och skriv
hela strängen till slutet på filen.

## 9.6
För att kunna lista trips måste vi först implementera GetTrain
eftersom den används av ListTrips.

GetTrain är lite lurigare när alla trains ligger i samma fil. Vi
kan inte lika enkelt identifera rätt tåg. För att träna lite på IO-
metoderna kan vi göra en lösning som loopar igenom trains.txt men
bara skapar ett Train om ID:t på raden matchar det som skickas in i
GetTrain.

Det är dock lite klurigt eftersom IDt vi får in i GetTrain är en int
och vi har en lista med strängar. Vi skulle kunna splita varje sträng
och konvertera den första delen till en int. Det hade nog varit en
bra lösning men låt oss prova en annan variant bara för att.
Konvertera i stället ID:t vi fick in i metoden till en sträng. Vi kan
sen använda StartsWith-metoden på varje rad från filen för att se om
den startar på ID:t vi fått in i metoden.

När vi hittar en rad som matchar ID:t kan vi köra Split på den raden
för att skapa en Train-instans. Returnera sen instansen.

## 9.7
Nu ska vi bygga funktionen för att lista Trip-instanser.

Läs upp alla rader från trips.txt och loopa över dem. För varje rad
splitar vi värdena på komma-tecken. Vi kan nu sätta ID:t och de tre
strängvärdena. Samt att vi kan hämta tåg-instansen från GetTrain.

Bokningarna är fortfarande ihop packade som en sträng. Vi måste först
splitta på "|" för att få ut varje bokning för sig. Sen måste vi
splitta varje sånt värde på "&" för att få namn och telefon.

Splitta först på "|" och loopa sen över värdena vi får från split-
resultatet. I loopen splittar vi på "6" och kan från det läsa ut
namn och telefonnummer. Skapa instanser av Customer och Bookings
i denna loop och lägg Bookings i en lista. Använd sedan listan för
att skapa upp Trip-instanserna.

Lägg Trip-instanserna i en lista och returnera listan.

Kör ni programmet och testa om du kan lista de trips du skapat i
steget innan.

## 9.8
Även denna gång får vi problem med bokningarna. Nu anropar vi
SaveTrip på rätt ställe men eftersom varje sparning lägger till en
ny rad sist i filen kommer vi skapa flera rader för samma Trip.
Vilket inte är vad vi vill.

Vi skulle därför behöva ändra SaveTrip så att den kollar om Trip-
instansen redan finns i filen innan vi sparar den. Vi kan lösa detta
på olika sätt men jag kommer föreslå en lösning här.

Vi kan läsa in hela filen först. Göra ändringarna vi vill göra och
sen skriva över hela filen i stället för att bara lägga till i slutet.
Så vi börjar med att läsa in hela listan rad för rad. Sen vill vi
kolla om listan innehåller vår trip. Om den gör det vill vi uppdatera
den Trip:en. Om listan inte innehåller vår trip kan vi lägga till den
i slutet av filen.

Vad innebär det att uppdatera en Trip i filen? Vi skulle kunna gå in
på raden och sätta om alla värden vi får i parametern i SaveTrip, men
det är onödigt komplicerat. En enklare lösning är att anta att den
instans av Trip vi får in i metoden har all information vi vill ha
och bara ersätta hela raden med vår nya instans.

Loopa över raderna i filen. Använd samma ID-matchningshack vi
använder i GetTrain för att kolla om en Trip med ID:t finns i filen.
Om vi hittar en rad i filen som matchar ID:t ersätter vi sträng-
värdet på den raden med datan vi fått in i SaveTrip. Om vi tar oss
igenom hela loopen utan att få en match så kan vi anta att vår Trip
är en ny Trip och spara den i slutet på filen.

Skriv sen ner hela listan av trips till trips.txt. Kom ihåg att ändra
från Append till Write.

Kör programmet och prova att göra en bokning. Du borde se den i filen
och kunna lista trips och se bokningen.
