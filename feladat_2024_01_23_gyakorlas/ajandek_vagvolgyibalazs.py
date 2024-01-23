baratokSzama = int(input("Add meg a barátaid számát: "))

# barátok neveinek bekérése
baratokNevei = []
for i in range(baratokSzama):
    baratNeve = str(input(f"{i + 1}. barát neve: "))
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

# hányszor van benne a keresztnév a listában
keresztnevKereses = str(input("Adja meg a keresztnevet: "))
keresztnevSzam = sum(1 for nev in baratokNevei if keresztnevKereses in nev)
if keresztnevSzam > 0:
    print(f"A keresett keresztnév {keresztnevSzam} alkalommal található a listában.")
else:
    print("Nincs ilyen keresztnevű barát.")

def keresztnev_kereses(keresett_nev, baratok_nevei):
    keresett_keresztnev = keresett_nev.split()[-1]
    keresztnev_talalasok = 0

    for nev in baratok_nevei:
        if keresett_keresztnev in nev:
            keresztnev_talalasok += 1

    if keresztnev_talalasok > 0:
        print(f"A keresett keresztnév {keresztnev_talalasok} alkalommal található a listában.")
    else:
        print("Nincs ilyen keresztnevű barát.")

keresztnevKereses = input("Adja meg a keresett nevet (pl. 'veszélnév keresztnév' vagy 'keresztnév'): ")
baratokNevei = ["Kovács Éva", "Tóth Peti", "Nagy Zsófi", "Varga Márton", "Horváth Anna"]

keresztnev_kereses(keresztnevKereses, baratokNevei)

atlagAjandekAr = round(baratokAjandekai, 2)
print(f"Az ajándékok átlagára 2 tizedesjegyre kerekítve: {atlagAjandekAr}")
