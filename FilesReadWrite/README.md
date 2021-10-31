# Uppgift 1
För att göra deluppgifterna i denna uppgift behöver du först skapa
en klass som heter MyFileHandler.

Skapa också en instans av MyFileHandler i Main-metoden. Vi kommer
använda den i kommande uppgifter

## 1.1
I projektet finns det redan en fil som heter testfile1.txt. Skapa en
metod i MyFileHandler som läser ut allt innehåll från testfile1.txt
och skriver ut innehållet till consolen. Kalla metoden ReadAllContent.
Identifiera själva vilka parametrar och returtyp som är rimligt för
denna metod.

Testa att din kod fungerar genom att anropa metoden från Main-metoden.

## 1.2
Skapa en metod i MyFileHandler som heter WriteContentToFile.
Implementera metoden så att den tar emot en sträng och skriver ut
värdet i strängen till en fil som heter testfile2.txt. Identifiera
själv vilka parametrar och returtyp som är rimligt för denna metod.

Testa att din kod fungerar genom att anropa metoden i Main-metoden
med ett strängvärde du själv hittar på. Navigera sedan till mappen
där filen skapats och kolla att den innehåller din sträng.

## 1.3
Skapa en metod i MyFileHandler som heter UpperCaseContent. Metoden
ska ta in två filnamn som parametrar (dvs, strängar). Implementera
metoden så att den läser in allt innehåll från den ena filen,
konverterar texten till upper case (ToUpper()) och sen skriver ner
texten med stora bokstäver till den andra filen.

Testa att din kod fungerar genom att anropa metoden från Main-metoden.
Använd testfile1.txt som det första filnamnet och testfile3.txt som
det andra. Navigera sedan till mappen där filen skapats och kolla att
den innehåller din sträng.

## 1.4
Skapa en metod i MyFileHandler som heter ReadLatinEncodedContent.
Implementera metoden så att den läser in allt innehåll från
latin1.txt och skriver ut innehållet till consolen.

Testa att din kod fungerar genom att anropa metoden från Main-metoden.

Notera att "åäö" saknas i utskriften. Åtgärda detta genom att ändra i
utläsningen från latin1.txt så att din kod anger att det är just
Latin1-encoding som ska användas.

# Uppgift 2
Skapa en klass som heter NoteBook.

## 2.1
Skapa en metod i NoteBook som heter TakeNote. Metoden ska ta emot
en sträng och skriva den till en fil som heter notes.txt. Identifiera
själv vilka parametrar och returtyp som passar för den här metoden.

Det är viktigt att vi inte skriver över äldre notes som redan finns i
filen. Så se till att använda en implementation som inte tar bort
befintligt innehåll.

Testa din kod genom att skapa en instans i Main-metoden som anropar
TakeNote ett par gånger. Kolla sedan i filen notes.txt att alla dina
texter finns i filen.

## 2.2
Vi ska nu bygga ut TakeNote-metoden så att den för varje notering
också skriver ut datum och tid när noteringen skrevs. Du kan få tag
på det nuvarande datumet och tiden med ```DateTime.Now.ToString()```.

Använd funktionen för att formtera strängar som vi lärt oss om
tidigare i kursen för att skriva ut datumet vänsterställt med en
bredd på 24 tecken. Skriv därefter ut noteringstexten.

Ex:
```
2020-03-14 15:03:57    My first note
2021-06-14 22:13:27    Another note
2021-09-14 10:43:07    Final note
```

## 2.3
Vi skulle också vilja ha en header i början av filen. Formatet vi
vill ha är:

```
Datum                  Note
-----------------------------------------------------------
2020-03-14 15:03:57    My first note
2021-06-14 22:13:27    Another note
2021-09-14 10:43:07    Final note
```

För att få till detta format måste vi hantera fallet när filen skrivs
till första gången. Använd det du lärt dig för att kolla om filen
finns. Om den inte finns skriver du först ut header-informationen och
sen noteringen som användaren skickat in. Om filen redan finns
skriver du ut noteringen som innan.

För att testa denna ändring måste du först ta bort filen på disk.

## 2.4
Vi skulle nu vilja skriva ut alla noteringar som finns i filen när
programmet startar. Börja med att skapa en metod i NoteBook som heter
GetAllNotes. Identifiera själv vilka parametrar och returtyp metoden
ska ha. Metoden ska läsa ut allt innehåll från notes.txt och returnera
en lista med alla noteringsrader som finns i filen. Vi vill alltså ta
bort header-informationen och sen returnera en lista/array av
noteringar.

Lägg till i Main-metoden så att GetAllNotes anropas innan din andra
kod körs.

## 2.5
I deluppgift 2.1 la vi till några hårdkodade anrop till TakeNote.
Nu ska vi ändra så att noteringarna läses in från användaren.

Börja med att ta bort de hårdkodade anropen. Lägg sedan till en evig
loop som frågar användaren efter en notering. Läs in ett värde från
användaren och spara den som en notering med TakeNote.

Gör så att loopen avbryts om användaren skickar in en tom sträng
(dvs, trycker enter utan att skrivit en text).

Kör programmet och ange några noteringar i terminalen. Öppna filen
mellan varje du skriver in ett värde och se så att det ser korrekt ut
i filen.

# Uppgift 3 (bonus)
Om du har lite extra tid. Skapa en Web Api-projekt och kopiera över
NoteBook-klassen. Skriv en endpoint för att lägga till notes och
en för att lista befintliga notes. Använd metoderna i NoteBook för
att få samma beteende som i uppgift 2.
