import math;

hanytol = int(input("Hánytól: "));
hanyig = int(input("Hányig: "));
hatvany = int(input("Hatvány: "));
hanyasaval = int(input("Hányasával: "));

for szam in range(hanytol, hanyig + 1, hanyasaval):
    hatvany1 = math.pow(szam, hatvany);
    print(f"Szám: {szam} Hatványa: {hatvany}");