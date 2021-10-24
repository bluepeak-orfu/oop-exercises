# Uppgift 1
I den här uppgiften kommer vi använda en klass (Person) för att
skicka och ta emot information

## 1.1
Skapa en klass som heter Person. Klassen ska ha två propert:s Name
och Age. Name ska vara en string och Age ska vara en int.

## 1.2
Skapa en controller som heter PersonController. PersonController ska
ha en (1) metod som heter GetPerson. Metoden GetPerson ska returnera
en instans av klassen Person. Implementera GetPerson så att den skapar
en instans av klassen Person och returnerar den. Sätt värden på Name
och Age.

Kör programmet och anropa /api/person. Du borde nu se din användare
i JSON-format

## 1.3
Skapa en till metod i PersonController som heter ListPersons. Metoden
ska returnera en lista av Person. Implementera metoden så att den
skapar en lista med tre personer. Hitta på namn och ålder för de tre
personerna.

Nu när vi har två metoder i PersonController måste vi hjälpa WebApi
förstå vilken sökväg som ska gå till vilken metod. Lägg till attribut
på båda metoderna så att GetPerson matchar /api/person/get och
ListPersons matchar /api/person/list.

Kör programmet och anropa båda sökvägarna för att verifiera att det
fungerar.

## 1.4
Skapa en till metod i PersonController som heter CreatePerson. Metoden
ska ta en parameter av typen Person och returnera en bool.

Metoden ska matcha sökvägen /api/person/create. Detta är en metod som
ska skapa något så vi vill att det ska vara en POST och inte en GET.
Vi vill också att kroppen i requesten (request body) ska mappas till
Person-parametern. Kom ihåg att vi måste sätta ett attribut på
parametern för att WebApi ska förstå att vi vill mappa request body
till den parametern.

I den här övningen ska vi inte spara personen som skickas in utan vi
vill bara se att personen kommer in som väntat. Så implementera
metoden så att den bara returnerar true. Lägg sedan till en break
point i metoden så att vi kan titta på parametern när den anropas.

Kör programmet och anropa metoden med en POST. Använd förslagsvis
Postman för att göra detta. Skicka med ett namn och en ålder i
request body. När programmet stannar på break point:en, verifiera att
värdet på Person-parametern stämmer överens med det du skickar in.

# Uppgift 2
I uppgift 1 skapade vi upp en controller som kan utföra de vanligaste
REST-operationerna (skapa, lista, hämta). Vi använder dock inte de
vanliga konventionerna. I denna uppgift ska vi uppdatera
PersoncController så att den följer det vanliga mönstret för REST och
gör så att vi använder samma information i alla metoder.

## 2.1
Ändra värdena i attributen på metoderna så att de matchar enligt
följande lista:
* ListPersons -- Ska matcha på GET-requests med tom-sträng.
                 Dvs, GET /api/person
* CreatePerson -- Ska också matcha på tom-sträng men på POST-requests
                  Dvs, POST /api/person
* GetPerson -- Vi skapar denna metod till en senare uppgift. Lämna
               den som den är för nu.

Kör programmet och verifiera att ListPersons och CreatePerson fungerar
som tänkt.

## 2.2
Hittills sparas inte personer vi skapar med CreatePerson och vi kan
inte påverka listan med personer i ListPersons. I denna deluppgift
ska vi åtgärda det.

WebApi fungerar så att varje gång en request kommer in skapas en ny
instans av controller-klassen. Detta gör det lite svårare för oss
att spara information mellan requests. Det vi kan göra är att använda
"static". Med static kan vi spara data som ska finns tillgänglig i
alla instanser av en klass.

Skapa ett fält som heter persons i PersonController. Fältet ska vara
private och static. Fältet ska ha typen lista av Person. Instansiera
en tom lista direkt på raden där du deklarerar fältet.

Vi kan nu ändra implementationen i ListPersons att använda det nua
fältet. ListPersons ska returnera en lista av personer. Vårat statiska
fält är en list av personer. Så allt vi behöver göra är att returnera
fältet.

Ändra implementationen i CreatePerson så att den lägger till personen
du får som parameter i persons-listan.

Kör nu programmet. Testa för att anropa GET /api/person. Du borde få en
tom lista tillbaka. Anropa sedan POST CreatePerson (hitta på namn och
ålder för personen). Anropa sedan GET /api/person igen. Du borde nu
se personen du skapade med CreatePerson nyss.

## 2.3
Nu är det dags att fixa till GetPerson. GetPerson ska hämta ut en
specifik person ur vår persons-lista. För att kunna hämta ut en
specifik person måste vi ha någon information som unikt identifierar
personen. Namn kan ibland vara unikt men det är inte garanterat att
vara det. Vi ska därför lägga till en property på Person som är unik
för varje person.

Skapa en ny property på Person som heter Id och är av typen int. Id
är en lite speciell property. Den ska inte sättas utanför klassen och
den ska tilldelas ett värde som är unikt för varje ny person. Ange
därför att property:n har get och private set så att vi bara kan
ändra värdet inne i klassen. På så sätt förhindrar vi att någon
extern utvecklare försöker ändra på värdet.

Vi måste också se till att sätta värdet på Id för varje person. Skapa
därför först en konstruktor utan parametrar i Person. I konstruktorn
ska vi sätta värdet på Id-property:n. Men vad ska vi sätta värdet
till? En lösning som används i bland är att ha en static-variabel i
en klass som räknas upp med 1 för varje instans som skapas. På sä
sätt kan vi använda det nuvarande värdet som ett unikt Id för varje
person som skapas.

Vänta med att skriva klart konstruktorn och skapa först en private
static int som heter _idCounter. Sätt värdet på _idCounter till 0.
Skriv sedan klart konstruktorn genom att sätta värdet på Id till
det nuvarande värdet på _idCounter. Öka sedan värdet på _idCounter.

Med konstruktorn på plats kommer alla personer som skapas upp få ett
unikt Id. Detta gäller även för personer som skapas upp med
CreatePerson-metoden. Prova att köra programmet och skapa en person.
Lista sedan personerna och notera att personen fått ett Id.

I PersonController, ändra så att GetPerson tar in en parameter av
typen int. Namnge parametern personId. För att WebApi ska förstå att
personId ska innehållet ett värde från sökvägen ,åste vi ändra
värdet i attributet. Nu står det "get" i attributet. Ändra det till
"{personId}". Genom att skriva så i attributet och samtidigt namnge
parametern med samma namn kan WebApi matcha ihop dem.

Med den nya parametern personId kan vi nu skriva en loop i GetPerson
som hittar den person som har motsvarande Id. Ändra koden i GetPerson
så att den returnerar personen med det Id som skickats in. Om personen
inte finns ska metoden returnera null.

Kör programmet. Skapa en person. Lista personerna för att se vilket
Id personen fick. Använd sedan sökvägen /api/person/[ID] för att
hämta just den personen.

# Uppgift 3
I uppgift 2 skapade vi en static list i vår controller-klass. Det
anses vara dåligt koddesign att spara data direkt i en controller.
Controller-klassens ansvar är att hantera kommunikationen till och
från användaren. Annan kod bör delegeras till andra klasser i
programmet. I denna uppgift ska vi åtgärda detta.

Vi kommer använda oss av något som kallas en Singleton. Singletons
används inte så mycket nu för tiden men det blir en bra övning att
implementera en. Vill du läsa mer om Singleton kan du kolla här
https://refactoring.guru/design-patterns/singleton men
instruktionerna i övningen bör vara tillräckligt för att utföra
uppgiften.

# 3.1
Skapa en mapp i projektet som heter Managers. I mappen skapa en klass
som heter PersonManager. Det är denna klass som ska bli vår singleton.

# 3.2
Nu ska vi skriva den koden som gör PersonManager till en singleton.
Det vi vill åstadkomma är att det ska bara kunna finnas en (1) instans
av klassen PersonManager i applikationen. Och den instansen ska vara
nåbar från alla delar av vår applikation.

Börja med att skapa en konstruktor i klassen som är private och inte
tar några parametrar. Genom att göra konstruktorn private kan ingen
skapa instaser av klassen utanför klassen. Det kan verka lite konstigt
men vi kommer snart se hur vi kan skapa upp en instans av klassen.

Skapa sedan en private static variabel av typen PersonManager och
namnge variabeln _instance. Vi har nog aldrig skapat en variabel av
samma typ som klassen vi skapar den är, men det är inga konstigheter
att göra det. Sätt värdet på _instance till null.

Skapa sedan en public static get-only property som heter Instance.
Implementera get-delen så att den först kollar om _instance är null.
Om _instance är null ska vi skapa upp en instans av PersonManager och
spara den i _instance. Returnera sedan värdet på _instance. Om koden
är korrekt skriven borde den alltid returnera en instans av PersonManager
och eftersom vi bara skapar instansen när _instance är null så kommer
det som mest finnas en (1) instans av PersonManager.

Nu har vi en Singleton. Nästa steg blir att lägga till kod i den. Så
att den faktiskt gör något.

# 3.3
Vi ska nu flytta en del kod från PersonController till PersonManager.
Vi kan börja med ListPersons. Vi vill ändra så att PersonManager har
en lista med personer och ListPersons i PersonController frågar
PersonManager efter en lista med personer i stället för att
PersonControler har en egen lista med personer.

Skapa därför en lista med Person i PersonManager. Eftersom vi har en
instans av PersonManager som kommer finnas kvar så länge applikationen
kör behöver vi inte göra listan static. Så skapa ett private fält i
PersonManager som heter _persons och är av typen lista av personer.

Skapa sedan en metod i PersonManager som heter List. Metoden ska vara
publik och returnera en lista av person och tar inga parametrar.
Implementera metoden så att den returnerar fältet _persons.

Ändra nu i PersonController så att ListPersons anropar PersonManager
för att få tag på en lista med personer. Gör detta genom att först
anropas Instance-propertyn på PersonManager. Detta ger dig en instans
av PersonManager och på denna instans kan du anropa List.

# 3.4
Nu ska vi göra samma sak för CreatePerson. Skapa en metod i
PersonManager som heter Create. Metoden ska vara public, ta en
parameter av typen Person och inte returnera någonting. Implementera
metoden så att den lägger till personen som kommer in som parameter
i _persons-listan.

Ändra sedan i CreatePerson i PersonController så att den anropar
Create i PersonManager. Skicka med person-instansen som skickas in
till CreatePerson till Create i PersonManager.

# 3.5
Till sist ska vi göra samma typ av flytt för GetPerson. Skapa en
metod i PersonManager som heter Get. Metoden ska ta in en
int-parameter och returnera en Person.

Kopiera implementationen från GetPerson och lägg den i Get-metoden
i PersonManager. Ändra i den kopierade koden så att alla variabler
heter rätt sak för PersonManager.

Ändra i GetPerson i PersonController så att den anropar Get i
PersonManager.

# 3.6
Nu borde koden i PersonController bara bestå av anrop till
PersonManager. Vi kan nu städa bort den statiska listan i
PersonController.

Och med det har vi flyttat all logik till ett eget "lager".
Det är vanligt att man lägger kod med olika ansvarsområden i olika
lager. Koden nu kan verka mer komplex men generellt brukar denna typ
av uppdelning leda till kod som är lättare att underhålla och förstå.
