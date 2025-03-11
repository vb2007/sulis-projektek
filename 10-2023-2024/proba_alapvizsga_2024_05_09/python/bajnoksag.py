eredmenyek = []
with open("eredmenyek.txt", "r", encoding="UTF-8") as f:
    next(f)
    for i in f:
        i = i.strip().split(";")
        eredmenyek.append({
            "nev" : str(i[0]),
            "szekhely" : str(i[1]),
            "pont" : int(i[2])
        })

#1.
print(f"1. feladat: A fájlban {len(eredmenyek)} csapat adatai szerepelnek.")

# #2.
pontok = [eredmeny["pont"] for eredmeny in eredmenyek]
atlag = sum(pontok) / len(pontok)
print(f"2. feladat: A bajnokságon átlagosan {atlag:.2f} pontot értek el a csapatok.")

#3.
kieso = min(eredmenyek, key=lambda i : i["pont"])
kieso = kieso["nev"]
print(f"3. feladat: {kieso} a kieső csapat.")

#4.
print("4. feladat")
helyes = False
while(not helyes):
    pontszam = int(input("        Kérem, adjon meg egy pontszámot 0 és 100 között: "))
    if pontszam >= 0 and pontszam <= 100:
        helyes = True

with open("pontszam.txt", "w", encoding="UTF-8") as f:
    f.write(str(pontszam) + "\n")
    for i in eredmenyek:
        if i["pont"] >= 50:
            f.write(i["nev"] + "\n")