baratokSzama = int(input("Add meg a barátaid számát: "))

# barátok neveinek bekérése
baratokNevei = []
for i in range(baratokSzama):
    baratNeve = str(input(f"{i + 1}. barát neve (pl. 'Vezetéknév Keresztnév' vagy 'Keresztnév'): "))
    baratokNevei.append(baratNeve)

# ajándék összegek bekérése
baratokAjandekai = []
for i in range(baratokSzama):
    baratAjandeka = int(input(f"{i + 1}. barát ajándék összege: "))
    baratokAjandekai.append(baratAjandeka)

# mennyibe kerülnek összesen az ajándékok
ajandekArakOsszeg = sum(baratokAjandekai)
print(f"Összesen {ajandekArakOsszeg} Ft-ot költött ajándékokra.")

# ki kapja a legdrágább ajándékot
legdragabbAjandek = max(baratokAjandekai)
legdragabbAjandexIndex = baratokAjandekai.index(legdragabbAjandek)
legragabbAjandekotKapoNeve = baratokNevei[legdragabbAjandexIndex]
print(f"A legdrágább ajándékot {legragabbAjandekotKapoNeve} kapja, {legdragabbAjandek} Ft értékben.")

# kinek a legrövidebb a neve
baratNevekHossza = [len(nev) for nev in baratokNevei]
legrovidebbNevHossza = min(baratNevekHossza)
legrovidebbNevHosszaIndex = baratNevekHossza.index(legrovidebbNevHossza)
legrovidebbNev = baratokNevei[legrovidebbNevHosszaIndex]
print(f"A legrövidebb név {legrovidebbNev}, amely {legrovidebbNevHossza} hosszú.")

# hánszor van benne egy keresztnév a listában
keresztnevKereses = input("Adja meg a keresett nevet (pl. 'Vezetéknév Keresztnév' vagy 'Keresztnév'): ")
keresettKeresztnev = keresztnevKereses.split()[-1]

keresztnevTalalasok = 0
for nev in baratokNevei:
    if keresettKeresztnev in nev:
        keresztnevTalalasok += 1
if keresztnevTalalasok > 0:
    print(f"A keresett keresztnév {keresztnevTalalasok} alkalommal található a listában.")
else:
    print("Nincs ilyen keresztnevű barát.")

# hány nem teljes név van a listában
csakKeresztnevek = []
for i in baratokNevei:
    if len(i.split()) == 1:
        csakKeresztnevek.append(i)
csakKeresztnevMennyiseg = len(csakKeresztnevek)
print(f"Ennyi embernek szerepel csak a keresztneve a listában: {csakKeresztnevMennyiseg}")

# átlagosan hány forintot szánnak egy barát ajándékára
atlagAjandekAr = sum(baratokAjandekai)/len(baratokAjandekai)
print(f"Az ajándékok átlag ára 2 tizedesjegyre kerekítve: {round(atlagAjandekAr, 2)} Ft.")

# értékek kétszeresére növelése, listában tárolása, majd kiírása
duplaErtek = [i * 2 for i in baratokAjandekai]
i = 0
while i < len(baratokNevei):
    print(f"{baratokNevei[i]} {duplaErtek[i]} Ft értékben kap ajándékot.")
    i += 1