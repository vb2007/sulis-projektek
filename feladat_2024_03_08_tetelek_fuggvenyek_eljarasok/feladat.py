# 1. összegezd egy lista pozitív elemeit
lista1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10,-2,-8,-12]

def osszeg(szamok):
    osszeg = 0
    for szam in szamok:
        if szam > 0:
            osszeg += szam
    return osszeg

print(f"A pozitív számok összege: {osszeg(lista1)}")

# 2. számold ki a páratlan számok összegét a listában 
lista2 = [1, 3, 8, 12, 22, 31, -5, -10, 0]

def paratlanSzamok(szamok):
    paratlanSzamok = 0
    for szam in szamok:
        if szam % 2 != 0:
            paratlanSzamok += szam
    return paratlanSzamok

print(f"A páratlan számok összege: {paratlanSzamok(lista2)}")

# 3. szövegek hosszának összege
lista3 = ["szilva", "körte", "alma", "mogyoró"]

def szovegHossz(szovegek):
    szovegHossz = 0
    for szoveg in szovegek:
        szovegHossz += len(szoveg)
    return szovegHossz

print(f"A szövegek hosszának összege: {szovegHossz(lista3)}")

# 4. a listában szereplő pozitív számok átlaga
lista4 = [3, -7, 1, 5, -9, 2]

pozitivSzamokAtlaga = osszeg(lista4) / len(lista4)

print(f"A pozitív számok átlaga: {pozitivSzamokAtlaga}")

# 5. a listában szereplő páros számok átlaga
# mivel a fenti függvény a páratlan számok összegét adja vissza, azt itt nem lehet használni
lista5 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 1]

osszeg = 0
for szam in lista5:
    if szam % 2 == 0:
        osszeg += szam

parosSzamokAtlaga = osszeg / len(lista5)

print(f"A páros számok átlaga: {parosSzamokAtlaga}")

# 6. a listában szereplő szövegek átlag hossza
lista6 = ["alma", "körte", "banán", "szilva"]

szovegekAtlaga = szovegHossz(lista6) / len(lista6)

print(f"A listában szereplő szövegek átlag hossza: {szovegekAtlaga}")

# 7. eljárás, amely kiírja egy fájlba, hogy hány levél érkezett aznap
lista7 = ["érkezett", "nem érkezett", "érkezett", "nem érkezett", "érkezett"]

osszeg = 0
for szoveg in lista7:
    if szoveg == "érkezett":
        osszeg += 1

with open("levelek.txt", "a") as f:
    f.write(f"Összesen ennyi levél érkezett: {osszeg}\n")

# 8. kiírja, hány csomagot adtak fel aznap 
lista8 = ["feladott", "nem feladott", "feladott", "feladott", "nem feladott", "feladott", "feladott", "feladott", "nem feladott"]

for szoveg in lista8:
    if szoveg == "feladott":
        osszeg += 1

print(f"Összesen ennyi csomagot adtak fel: {osszeg}")

# 9. kiíja, hogy hány reklámlevél érkezett
lista9 = ["Reklámlevél", "Értesítő", "Reklámlevél", "Számla", "Reklámlevél"]

osszeg = 0
for szoveg in lista9:
    if szoveg == "Reklámlevél":
        osszeg += 1

print(f"Összesen ennyi reklámlevél érkezett: {osszeg}")