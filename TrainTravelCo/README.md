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
