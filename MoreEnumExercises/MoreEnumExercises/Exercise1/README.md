# Uppgift 1
I klassen StovePlate finns en property som heter Hotness och som är av typen
string. Property:n används på flera ställen i klassen. Eftersom värdet på
strängen Hotness bara kan vara "none", "low" eller "high" vore det bättre att
använda en enum här i stället för string.

Din uppgift är att byta ut typen på Hotness-property:n i StovePlate. För att
hjälpa dig på vägen har vi redan skapat en enum med rätt värden. Den heter
HeatLevel.

För att ändra värdet måste du:
 * Byta värdet i deklarationen av Hotness. Efter du ändrat deklarationen kommer
   Visual studio varna om många fel i filen. Detta är väntat och kommer lösa sig
   när du löser de två andra punkterna.
 * Ändra tilldelningen i konstruktorn
 * Ändra i implementationen i IncreaseHeat och DecreaseHeat
