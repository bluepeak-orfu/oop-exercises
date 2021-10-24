# Uppgift 1
I denna uppgift ska vi skapa en endpoint (controller) som skickar
enkla meddelanden till användaren.

## 1.1
Skapa en controller som heter GreetingController. Visual studio
ger oss lite hjälp på vägen här. Om vi i "add"-menyn väljer att
lägga till en controller i stället för en vanlig klass kommer
Visual studio lägga in de attribut och arv som krävs för att
klassen ska bli en fungerande controller. Se till att välja en
API-controller och inte en MVC-controller.

Tänk på att lägga controller-klassen i rätt mapp och att följa
namnkonventionen.

## 1.2
Skapa en metod i GreetingController som heter Ping. Metoden ska
vara public och returnera en sträng. Metoden tar inga parametrar.

Implementera metoden så att den returnerar strängen "pong".

Starta nu applikationen och ladda endpoint:en "ping". Du borde kunna
nå den på sökvägen /api/greeting.

Detta fungerar för att GreetingController har attribut som markerar
den som en api controller. WebApi kommer automatiskt hitta klassen
och dess metoder när vi anropar /api/greeting. Eftersom det bara
finns en (1) metod i klassen används den när vi anger sökvägen
till controller-klassen. Härnäst kommer vi se vad som händer om vi har
flera metoder i klassen.

## 1.3
Skapa en metod i GreetingController som heter Hello. Metoden ska
vara public och returnera en sträng. Metoden tar inga parametrar.

Implementera metoden så att den returnerar strängen "Hello!".

Starta nu applikationen och försök komma åt samma sökväg som i
föregående uppgift. Du borde få ett fel.

## 1.4
För att åtgärda felet i 1.3 måste vi säga åt WebApi vilken sökväg
de två metoderna ska matcha mot. Detta gör vi genom att sätta ett
HttpGet-attribut på metoden.

Lägg till ett HttpGet-attribut på metoden Ping. Attributet kräver en
sträng-parameter. Skicka in värdet "ping".

Lägg till ett HttpGet-attribut på metoden Hello. Attributet kräver en
sträng-parameter. Skicka in värdet "hello".

Starta nu applikationen. Du borde nu kunna anropa de två metoderna
på sökvägarna /api/greeting/ping och /api/greeting/hello.

# 1.5
Uppdatera metoden Hello så att den tar en string-parameter med namn
name. Använd parameter:n i metoden så att den returnerar "Hello {name}!".

Starta nu applikationen. Du borde nu kunna anropa de hello-metoden med
följande sökväg: /api/greeting/hello?name=[ange ditt namn här]

# Uppgift 2
I denna uppgift kommer vi göra ungefär samma grejer som i uppgift 1
men vi kommer inte vägleda dig lika mycket.

## 2.1
Skapa en ny controller i samma projekt som i uppgift 1. Namnge
controller:n ExerciseController.

## 2.2
Skapa en metod i ExerciseController som heter Ping och kan anropas på
sökvägen /api/exercise/ping. Metoden ska returnera strängen "pong".

## 2.3
Skapa en metod i ExerciseController som heter Concat och kan anropas
på sökvägen /api/exercise/concat. Metoden ska ta två sträng-parametrar
som heter part1 och part2. Implementera metoden så att den slår ihop
de två parametrarna och returnerar resultatet av sammanslagningen.

Starta programmet och verifiera att det fungerar genom att anropas det
med sökvägen: /api/exercise/concat?part1=hello&part2=there

