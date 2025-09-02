import random;

veletlenszam = random.randint(1,6);
#A feladat kérte hogy írjam ki, ez nem hiba
print(veletlenszam);

if veletlenszam == 1:
    print("Egy körből kimaradsz.");
elif veletlenszam == 6:
    print("Még egyszer dobhatsz.");