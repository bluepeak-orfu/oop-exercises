# A
Skapa ett interface som heter IComputation. Deklarera två metoder i interface:et.
Den första metoden ska heta CanCompute och tar en sträng-parameter och returnerar
en bool. Den andra metoden heter Compute tar en string-array och returnerar en int.

# B
Skriv kod i Program.cs som deklarerar en lista av IComputation (det ska alltså
stå "IComputation" mellan < och >) som heter computations. Instansiera listan
som en tom lista.

Skriv en loop som kör för evigt. I loopen läser vi först in en rad från användaren.
Spara värdet i en string-variabel som heter input. Använd sedan Split-metoden från
string-klassen för att dela upp input i flera delar. Splitta input på " ".

Ex: om användaren skickar in "aaa bbb ccc" så ska vi splitta värdet så att vi
får en array med tre värden: { "aaa", "bbb", "ccc" }.

Spara den splittade strängen i en variabel som heter parts.

Vi vill nu loopa igenom listan computations och leta efter ett objekt som kan
"hantera" värdet användaren skickade in. Vi gör detta genom att:

Skriva en loop som loopar över computations-listan. För varje värde anropar vi
CanCompute och skickar in det första värdet i array:en parts. Om vi hittatet ett
objekt som returnerar true från CanCompute så ska vi göra följande:

Anropa metoden Compute på det objekt som svarade true på CanCompute och skicka 
med alla delar av parts förutom den första (kom ihåg syntaxen för att läsa ut delar
av en array). Resultatet från Compute ska skrivas ut till console:en.

Det blev rätt många steg i del b. Här är en sammanfattning:
Du ska skapa en loop som kör för evigt. I loopen ska du först hämta ett värde
från användaren. Dela redan värdet i flera delar baserat på var i strängen det
finns " "-tecken. Loopa sedan över computations-listan. Kolla (med en if) om
IComputation-instansen kan hantera beräkningen användaren skickade in (CanCompute).
Om den kan det (gå in i if:en) ska du anropa Compute på samma IComputation-instans.

# C
Skapa en klass som heter AdditionComputation. Klassen ska implementera IComputation.
För att implementera IComputation måste AdditionComputation implementera CanCompute
och Compute. 

Skriv kod i CanCompute så att den returnerar true om parametern har värdet "+"
eller "plus".

Skriv kod i Compute så att den summerar värdet av delar av array:en som skickades in.

SKriv kod i Program.cs så att listan computations innehåller en instans av klassen
AdditionComputation.

Ex: Om användaren skriver "+ 1 2 3" så ska programmet svara: 6

# D
Skapa en klass som heter SubtractionComputation. Klassen ska implementera IComputation.
Implementera denna klass precis som AdditionComputation men ändra så att den
hanterar subtraktion istället för addition.

# E
Notera att både AdditionComputation och SubtractionComputation konverterar från
string till int innan de gör sina beräkningar. Det vore nog bättre att sköta
detta i Program.cs så att vi inte duplicerar kod i onödan.

Ändra i interface:et IComputation så att Compute tar en int-array istället för
en string-array. Uppdatera de båda implementerande klasserna att göra det samma.

Ändra i Program.cs så att den konvertera parametern till int innan den anropar
Compute.
