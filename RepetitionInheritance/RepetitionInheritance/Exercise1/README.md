# A
Deklarera en abstrakt klass som heter ArrayModifier. Klassen ska ha ett private
fält av typen int-array. Klassen ska ha en konstruktor som tar in en int-array
som parameter. Värdet som skickas in ska sättas som värde på fältet.

# B
Deklarera en abstrakt metod i klassen som är tillgänglig för ärvande klasser
men inte publikt. Metoden ska heta ModifyValue. Metoden ska ta en int-parameter
och returnera ett int-värde.

# C
Deklarera en metod i ArrayModifier som heter Modify. Metoden ska vara publikt
tillgänglig. Inte ta några parametrar och inte returnera något värde. Metoden
ska loopa över array:en som du deklarerade i del A och för varje värde i array:en
ska du skicka in värdet till ModifyValue-metoden och sen sätta om värdet i array:en
till det värde som ModifyValue-metoden returnerar.

# D
Skapa en klass som heter IncrementModifier. Klassen ska ärva från ArrayModifier.
Eftersom vi ärver från en klass som inte har en parameterlös konstruktor måste 
vi även skapa en konstruktor som kan anropa ArrayModifier:s konstruktor.

Skapa därför en konstuktor som tar in en int-array och skickar den vidare till
basklassen.

# E
Implementera metoden ModifyValule i IncrementModifier-klassen. Metoden ska returnera
det inskickade värdet plus 1. Så skickar vi in 5 som parameter till metoden ska den 
returnera 6.

# F
Skriv kod i Program.cs som skapar en int-array (sätt nägra värden i array:en).
Deklarera en variabel av typen ArrayModifier och tilldela den en instan av
IncrementModifier.

För att kunna verifiera att det fungerat som tänkt kan du även skriva en loop
som loopar över array:en och skriver ut alla värden i den.

Ex: Om vi skapar en array med följande värden: { 2, 3, 5 }. Så borde resultatet
av att köra programmet bli:
```
3
4
6
```
