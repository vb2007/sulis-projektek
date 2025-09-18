import random;

veletlenszam = random.randint(1,1000);
szamjegy = len(str(veletlenszam));

print(f"{szamjegy} jegyű számot dobott. A Szám: {veletlenszam}");