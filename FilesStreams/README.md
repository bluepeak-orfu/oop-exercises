# Uppgift 1
I denna uppgift ska vi göra samma sak som i uppgift 1 i
FilesReadWrite fast vi ska använda streams i stället.

## 1.1
I projektet finns det redan en fil som heter testfile1.txt. Skapa en
metod i MyFileHandler som läser ut allt innehåll från testfile1.txt
och skriver ut innehållet till consolen. Kalla metoden ReadAllContent.
Identifiera själva vilka parametrar och returtyp som är rimligt för
denna metod.

Du kan lösa problemet med ```ReadAllText``` men för att öva på
streams ska du använda ```File.OpenRead()``` och sen använda
klasserna och metoderna den kräver.

Med streams är det mer naturligt att skriva ut data allt efter
vi läser in den. Så implementera metoden så att den skriver ut
en rad i taget från filen.

Testa att din kod fungerar genom att anropa metoden från Main-metoden.

## 1.2
Skapa en metod i MyFileHandler som heter WriteContentToFile.
Implementera metoden så att den tar emot en sträng och skriver ut
värdet i strängen till en fil som heter testfile2.txt. Identifiera
själv vilka parametrar och returtyp som är rimligt för denna metod.

Du kan lösa problemet med ```WriteAllText``` men för att öva på
streams ska du använda ```File.OpenWrite()``` och sen använda
klasserna och metoderna den kräver.

Testa att din kod fungerar genom att anropa metoden i Main-metoden
med ett strängvärde du själv hittar på. Navigera sedan till mappen
där filen skapats och kolla att den innehåller din sträng.

## 1.3
Skapa en metod i MyFileHandler som heter UpperCaseContent. Metoden
ska ta in två filnamn som parametrar (dvs, strängar). Implementera
metoden så att den läser in allt innehåll från den ena filen,
konverterar texten till upper case (ToUpper()) och sen skriver ner
texten med stora bokstäver till den andra filen.

Kom ihåg att använda streams. För att använda streams styrka är det
viktigt att vi skriver varje rad vi läser in direkt till den andra
filen i stället för att läsa in hela innehållet och sen skriva hela
innehållet.

Testa att din kod fungerar genom att anropa metoden från Main-metoden.
Använd testfile1.txt som det första filnamnet och testfile3.txt som
det andra. Navigera sedan till mappen där filen skapats och kolla att
den innehåller din sträng.

## 1.4
Skapa en metod i MyFileHandler som heter ReadLatinEncodedContent.

Den här deluppgiften skiljer sig lite från deluppgiften i
FilesReadWrite. Här vill vi läsa ut alla bytes och skriva ut deras
int-värden.

Så implementera metoden så att den öppnar en läs-stream för filen
latin1.txt. Läs sedan innehållet byte för byte och skriv ut varje
värde i consolen. Använd sedan tabellen på https://kb.iu.edu/d/aepu
för att se vilken varje bokstav motsvarar.

Testa att din kod fungerar genom att anropa metoden från Main-metoden.
