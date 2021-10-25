# Uppgift 1
I den här övningen kommer vi träna på request routing och mappning av
parametrar. Vi kommer inte bygga någon meningsfull applikation utan
bara fokusera på syntaxen för routing och mappning.

För att minska på texten i uppgifterna kan du anta att alla metoder
ska vara publika om inget annat anges. Alla metoder ska också
returnera string om inget annat anges.

## 1.1
Skapa en controller som heter ComputationController. Kom ihåg att
skapa den där controller-klasser ska skapas. När vi skapar en
controller lägger Visual studio till vissa attribut. Ändra i routen
för klassen så att den mappar mot URL:en /compute.

För att verifiera att det fungerar kan vi lägga till en metoden i
klassen som heter Test. Metoden ska inte ta några parametrar.
Implementera metoden så att den returnerar strängen "test".

Kör programmet och verifiera att det fungerar genom att surfa in på
adressen /compute.

## 1.2
Nu behöver vi inte Test-metoden längre så du kan ta bort den.

Skapa en metod som heter Message. Metoden ska ta en parameter av
typen string. Namnge parametern myMessage.

Lägg till en GET-route så att metoden Message matchar URL:en
/comput/message. Vi vill också att metoden ska ta emot en query-
parameter som heter myMessage. Vi behöver inte göra något för att
åstadkomma detta då Web api kan lista ut det från att vi har en
metod-parameter med det namnet.

Implementera metoden så att den skriver ut:
"Ditt meddelande är: {myMessage}"

Kör programmet och testa din lösning genom att besöka följande URL:er
| URL                               | Förväntat svar             |
| --------------------------------- | -------------------------- |
| /compute/message?myMessage=hej    | Ditt meddelande är: hej    |
| /compute/message?myMessage=hej då | Ditt meddelande är: hej då |
| /compute/message?myMessage=123    | Ditt meddelande är: 123    |

## 1.3
Skapa en metod i ComputationController som heter Upper. Metoden ska
matcha GET-route:en /compute/upper. Denna metod ska inte ta några
query-parametrar. I stället vill vi få in information från route:en.

Uppdatera route:en du precis skrev så att metoden tar emot ett värde
efter "upper"-delen. Ange sedan en metod-parameter av typen string på
metoden. Se till att namnet på metod-parametern matchar det du skrev
i route:en.

Implementera metoden så att den kör ToUpper() på metod-parameter och
returnerar resultatet från ToUpper.

Kör programmet och testa din lösning genom att besöka följande URL:er
| URL                        | Förväntat svar             |
| -------------------------- | -------------------------- |
| /compute/upper/hej         | HEJ                        |
| /compute/upper/hej hej hej | HEJ HEJ HEJ                |
| /compute/upper/qwerty 123  | QWERTY 123                 |

## 1.4
Vi kan också kombinera värden från route:en och query-parametrar.
Skapa en metod som heter Concat. Lägg till en GET-route så att
metoden matchar /compute/concat och tar in en route-parameter efter
concat. Kalla route-parametern message1.

Ändra Concats parametrar så att den tar emot en query-parameter som
heter message2.

Implementera metoden så att den slår samman message1 och message2 och
returnerar resultatet av sammanslagningen.

Kör programmet och testa din lösning genom att besöka följande URL:er
| URL                              | Förväntat svar     |
| -------------------------------- | ------------------ |
| /compute/concat/abc?message2=123 | abc123             |
| /compute/concat/123?message2=abc | 123abc             |

## 1.5
Skapa en metod som heter Add. Lägg till en GET-route så att metoden
matchar /compute/add. Metoden ska ta emot två query-parametrar av
typen int. Uppdatera Add-metoden så att tar emot dessa två query-
parametrar.

Implementera metoden så att den summerar de två parametrarna som
skickas in. Kom ihåg att vi ska returnera en string. Så du måste
konvertera summan av additionen till en string.

Kör programmet och testa din lösning genom att skicka in olika värden
för de två parametrarna och verifiera att summan returneras.

## 1.6
Skapa en metod som heter Add2. Lägg till en GET-route så att metoden
matchar /compute/add2. Metoden ska göra samma sak som metoden Add
från deluppgift 1.5 men den ska använda route-parametrar i stället
för query-parametrar.

## 1.7
Skapa en metod som heter MultiGreeter. Lägg till en GET-route så att
metoden matchar /compute/multi. Metoden ska ta två query-parametrar.
Den första ska vara en int och heter count. Den andra ska vara en
string som heter message.

Implementera metoden så att den "skriver ut" message lika många
gånger som värdet på count. Kom ihåg att vi kan bara "skriva" till
användaren en (1) gång.

## 1.8
Skapa en metod som heter MultiGreeter2. Lägg till en GET-route så att
metoden matchar /compute/multi2. Metoden ska göra samma sak som
metoden MultiGreeter från deluppgift 1.7 men använda route-parametrar
i stället för query-parametrar.

# Uppgift 2
I den här uppgiften kommer vi bygga vidare på koden från uppgift 1.
Vi kommer lägga till klasser för att skicka och ta emot data från
användaren.

## 2.1
Skapa en klass som heter ComputeUnit. Klassen ska ha två publika
properties som har typen int. Namnge dem Value1 och Value2. Det ska
vara möjligt att både läsa och sätta värdena.

Skapa en metod i ComputationController som heter Compute. Lägg till
en POST-route så att metoden svarar på /compute/execute. Metoden ska
ta emot en parameter av typen ComputeUnit och returnera en int.

Implementera metoden så att den summerar värdena på Value1 och Value2
från den ComputeUnit-instans som vi får in i metoden. Returnera
resultatet av beräkningen.

Kör programmet och testa din nya kod. Glöm inte att anropa den med
POST och att skicka med JSON-data. Du kan till exempel prova att
skicka med:

```
{
  "Value1": 3,
  "Value2": 2
}
```

Då borde svaret bli 5.

## 2.2
Lägg till en string-property i ComputeUnit som heter Mode. Ändra i
implementationen av Compute-metoden i ComputationController så att
den kollar om värdet på Mode är "addition" eller "multiplication".
Om värdet är "addition" ska vi returnera summan av att addera Value1
och Value2. Om värdet är "multiplication" ska vi i stället
multiplicera Value1 och Value2 och returnera produkten.

Om Mode har ett annat värde kan vi returnera -1.

Kör programmet och verifiera att det fungerar med både addition och
multiplikation. Utgå från samma JSON som i förra uppgiften men lägg
till "Mode".

## 2.3
Det är nog en bra idé att flytta in beräkningen från deluppgift 2.2
in i ComputeUnit-klassen så att den kan hantera sina egna beräkningar.

Skapa en metod i ComputeUnit som heter Compute. Metoden tar inga
parametrar och returnerar en int. Flytta in koden från Compute-
metoden i ComputeController in i Compute-metoden i ComputeUnit.
Du kommer förmodligen behöva ändra hur du kommer åt värdena på
Value1 och Value2.

Efter att du fixat koden i ComputeUnit kan du i ComputeController
anropa ComputeUnit:s Compute-metod och returnera värdet.

Kör programmet och verifiera att du får samma svar som i deluppguft 2.2.

## 2.4
Vi kan kombinera data från request body med query-parametrar. Skapa
en ny metod i ComputationController som heter MultiCompute. Lägg till
en POST-route så att metoden svarar på /compute/multiexecute. Metoden
ska ta in en query-parameter av typen int som heter count. Metoden
ska också ta emot en request body av typen ComputeUnit.

Implementera koden så att den för samma beräkning som Compute-metoden
gör men multiplicera och resultatet av den beräkningen med query-
parametern count.

Kör programmet och verifiera att du får väntat resultat. T.ex.
så borde:
```
POST /compute/multiexecute?count=4
{
  "Mode": "addition",
  "Value1": 3,
  "Value2": 6
}
```
resultera i: 36

## 2.5
Skapa en metod i ComputationController som heter
CreateAdditionComputation. Lägg till en GET-route så att metoden
svarar på URL:en /compute/create-addition. Metoden ska ta in två
query-parametrar: value1 och value2. Metoden ska returnera en
ComputeUnit-instans.

Implementera metoden så att den skapa en instas av ComputeUnit
och sätter värdet på dess två properties till värdet på de query-
parametrar som skickas in till metoden. Sätt Mode till "addition".
Returnera sedan den skapade instansen av ComputeUnit.

Kör programmet och verifiera att du får en korrekt JSON tillbaka.
T.ex. om du skickar in
```
GET /compute/create-addition?value1=6&value2=7
```
borde du får tillbaka
```
{
  "Mode": "addition",
  "Value1": 6,
  "Value2": 7
}
```

## 2.6
Skapa en metod i ComputationController som heter ChangeMode. Lägg
till en POST-route so att metoden svarar på URL:en
/compute/change-mode. Metoden ska också ta in en route-parameter
som heter newMode och är av typen string. Metoden ska också ta emot
en ComputeUnit som request body. Metoden ska returnera en ComputeUnit.

Implementera metoden så att den sätter om Mode på den ComputeUnit-
instans som skickas in till det mode vi får i newMode-parametern.
Returnera sedan instansen av ComputeUnit.

Kör programmet och verifiera att du får en korrekt JSON tillbaka.
T.ex. om du skickar in
```
POST /compute/change-mode/multiplication
{
  "Mode": "addition",
  "Value1": 10,
  "Value2": 21
}
```
borde du får tillbaka
```
{
  "Mode": "multiplication",
  "Value1": 10,
  "Value2": 21
}
```

# Uppgift 3
I denna uppgift ska vi lära oss använda IActionResult.

## 3.1
Skapa en ny controller-klass som heter DogController. Skapa också en
klass som heter Dog. Klassen Dog ska ha två properties: Name och
HappinessLevel. Båda property:sarna ska vara av typen string.

Ange att DogController ska mappa mot "dog".

Skapa en metod i DogController som heter Pet. Lägg till en POST-
route som svara på URL:en /dog/pet. Metoden ska ta emot en Dog
som request body. Metoden ska returnera en IActionResult.

Implementera metoden så att HappinessLevel på Dog-instansen som
skickas in ska ändras till "very happy" om det nuvarande värdet är
"happy". Annars ska värdet sättas till "happy". Returnera sedan
Dog-instansen. Kom ihåg att vi inte kan returnera Dog som vanligt
eftersom det måste vara en instans av IActionResult.

Kör programmet och verifiera att du får en korrekt JSON tillbaka.
T.ex. om du skickar in
```
POST /dog/pet
{
  "Name": "Fido",
  "HappinessLevel": "happy",
}
```
borde du får tillbaka
```
Status code: 200
{
  "Name": "Fido",
  "HappinessLevel": "very happy",
}
```

## 3.2
Skapa en metod i DogController som heter Kick. Lägg till en POST-route
som svarar på URL:en /dog/kick. Metoden ska ta emot en Dog
som request body och returnera en IActionResult. Metoden ska inte
göra något med hunden utan returnera en "bad request" statuskod.

Kör programmet och verifiera att du får en korrekt JSON tillbaka.
T.ex. om du skickar in
```
POST /dog/kick
{
  "Name": "Fido",
  "HappinessLevel": "happy",
}
```
borde du får tillbaka
```
Status code: 400
```

## 3.3
Skapa en metod i DogController som heter FindSock. Lägg till en POST-
route som svara på URL:en /dog/find-sock. Metoden ska ta emot en Dog
som request body och returnera en IActionResult.

Implementera metoden så att om Dog-instansen som skickades in har ett
HappinessLevel på "very happy" ska metoden returnera statuskod 404.
OM HappinessLevel är något annat ska metoden returnera strängen
"Sock found". Kom ihåg att vi inte kan returnera en string direkt när
vi använder IActionResult.

Kör programmet och verifiera att du får en korrekt JSON tillbaka.
T.ex. om du skickar in
```
POST /dog/find-sock
{
  "Name": "Fido",
  "HappinessLevel": "very happy",
}
```
borde du får tillbaka
```
Status code: 404
```
