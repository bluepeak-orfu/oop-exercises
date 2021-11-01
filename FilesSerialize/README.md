# Uppgift 1
I projektet finns det en klass Person som innehåller information om
en person. Klassen Data har en property People som innehåller en
lista med personer. Vi ska använda denna lista av personer i den
första uppgiften.

## 1.1
Vi vill serializera personerna i listan Data.People. Vi vill göra det
först i en fil per person och sen en gemensam fil. Att vi gör det på
två sätt är bara för att öva.

Börja med att skapa en klass som heter PersonSerializer. Vi kommer
lägga till metoder i klassen i de kommande deluppgifterna. Vi vill
dock att alla filer PersonSerializer skapar ska hamna i en viss mapp.
Så vi kan skapa ett fält i klassen som pekar ut en sökväg på datorn
där vi vill skapa filer. Skapa också en konstruktor där vi kan sätta
värdet.

## 1.2
Nu ska vi skapa en serializering som skriver alla personer i listan
till en (1) fil. Vi kan kalla filen persons.txt. Kom ihåg att skapa
persons.txt i mappen som anges i fältet i 1.1.

Skapa en metod i PersonSerializer som heter SerializeInOneFile.
Metoden ska ta in en list av typen Person.

Implementera metoden så att den konverterar värdena i Person-
instanserna till ett värde som kan sparas i filen. Ett förslag på
format är att varje property i Person läggs till i en sträng med ett
komma-tecken mellan varje värde.

Vi får in en lista med personer så vi måste också hantera att det är
flera personer som ska serializeras. Loopa därför över listan av
Person-instanser och konvertera varje klass till en sträng. Lägg
sedan strängen i en ny lista. När vi loopat igenom hela listan borde
vi ha en lista av typen string med en längd på 3. Skriv ner denna
lista till persons.txt filen.

För att testa koden, skapa en instans av PersonSerializer i Main-
metoden och anropas SerializeInOneFile. Skicka med person-listan från
Data.People.

Kolla vilken information som finns i filen. Har du gjort rätt borde
det vara:

```
100,Adam,12
200,Berit,44
300,Calle,20
```

## 1.3
Nu ska vi serializera samma data men göra det i en fil per instans.
Skapa en metod i PersonSerializer som heter SerializeInManyFiles.
Metoden ska ta in en list av typen Person.

Implementera metoden så att den skapar en fil för varje Person-instans
i listan som skickas in. Namnge filerna enligt:

```
person_{id}.txt
```

Formatet i filen ska vara ett värde per rad. Så ett exempel är:

```
100
Adam
12
```

För att testa din lösning lägg till ett anrop till
SerializeInManyFiles i Main-metoden och skicka med Data.People.
Verifiera att det skapats 3 filer på disk:

```
person_100.txt
person_200.txt
person_300.txt
```

Och verifiera att innehållet är förväntat.

# Uppgift 2
Nu när vi har filer med person-data i kan vi testa att skriva metoder
för att läsa in informationen också.

## 2.1
Skapa en klass som heter PersonDeserializer. Precis som med klassen i
uppgift 1 ska den ha ett fält som anger mappen vi ska leta efter
filer i.

## 2.2
Nu vill vi läsa in personer från persons.txt filen. Skapa en metod
i PersonDeserializer som heter ReadFromSingleFile. Metoden ska ta en
string-parameter som anger vilen fil vi vill läsa ifrån. Metoden ska
också returnera listan av personer vi kommer läsa in.

Välj själv hur du vill läsa in filen men vi vill loopa över raderna.
För varje rad vi får in vill vi använda Split-metoden på string för
att dela upp strängen i tre delar (de tre properties som finns på
person).

Använd den string-array vi får från Split för att skapa en instans av
Person. Spara alla instanser av Persons i en lista och returnera
listan från metoden.

Skapa en instans av PersonDeserializer i Main-metoden och anropa
ReadFromSingleFile med värdet "persons.txt". Metoden kommer returnera
en lista med personer bestäm själv hur du verifierar att listan är
korrekt (t.ex. med en break point eller en loop som skriver ut
personerna).

## 2.3
Nu ska vi läsa in värdena från de tre fristående person-filerna.
Skapa en metod i PersonDeserializer som heter ReadFromMultipleFiles.
För att få tag på innehåll från flera filer måste vi först lista alla
filer i mappen och sen lista ut vilka filer vi vill läsa innehåll
ifrån.

Vi vet att filnamnen ska börja på "person_" (se uppgift 1.3) så vi
kan filtrera listan på med filer på det. Det finns en metod på string
som heter StartsWith. Den kollar om strängen börjar på en sträng. Vi
kan använda detta för att hitta filnamn som börjar på "person_".

När vi hittat filerna kan vi läsa ut innehållet från dem. Vi vet att
varje rad i filen motsvarar en property på Person. Så vi kan mappa
upp raderna i filen till properties för en instans av Perosn.

Lägg sedan Person-instanserna i en lista och returnera listan.

Testa koden genom att anropa ReadFromMultipleFiles i Main-metoden.
Metoden kommer returnera en lista med personer bestäm själv hur du
verifierar att listan är korrekt (t.ex. med en break point eller en
loop som skriver ut personerna).
