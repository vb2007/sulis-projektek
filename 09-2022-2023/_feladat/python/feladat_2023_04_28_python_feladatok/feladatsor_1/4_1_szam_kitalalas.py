import random;

random_szam = random.randint(1, 10);
#print(random_szam);
talalat = 0;

while talalat != random_szam:
    talalat = int(input("Találd ki a számot: "));
print("Kitaláltad!");