jegy_1 = 3500;
jegy_2 = 2500;
jegy_3 = 2000;
letszam = int(input("Létszám: "));
jegy_kategoria = int(input("Jegykategória (1-3): "));

if jegy_kategoria == 1:
    jegyar = jegy_1 * letszam;
    print(f"{jegyar} Ft a jegyek ára.");
elif jegy_kategoria == 2:
    jegyar = jegy_2 * letszam;
    print(f"{jegyar} Ft a jegyek ára.");
elif jegy_kategoria == 3:
    jegyar = jegy_3 * letszam;
    print(f"{jegyar} Ft a jegyek ára.");
else:
    print("Válassz egy érvényes kategóriát.");