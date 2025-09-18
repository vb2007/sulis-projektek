import random;

random_szam = random.randint(1, 10);
#print(random_szam);
talalat = 0;
talalatszam = 0;

while talalat != random_szam and talalatszam < 3:
    talalat = int(input("Találd ki a számot: "));
    talalatszam += 1;
if talalat == random_szam:
    print("Kitaláltad!");
else:
    print("Nem találtad ki!")