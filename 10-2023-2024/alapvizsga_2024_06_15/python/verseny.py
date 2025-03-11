#0. feladat
hajok = []
with open("adatok.txt", "r", encoding="UTF-8") as f:
    next(f)
    for i in f:
        i = i.strip().split(";")
        hajok.append({
            "hajoNev" : i[0],
            "klubNev" : i[1],
            "pontszam" : int(i[2])
        })

#1. feladat
print(f"1. feladat: A fájlban {len(hajok)} hajó adatai szerepelnek.")

#2. feladat
pontok = []
for i in hajok:
    pontok.append(i["pontszam"])
atlag = sum(pontok) / len(hajok)

print(f"2. feladat: A versenyben átlagosan {atlag:.1f} pontot osztottak szét.")

#3. feladat
gyoztes = min(hajok, key=lambda i : i["pontszam"])
print(f"3. feladat: {gyoztes['hajoNev']} a győztes hajó ({gyoztes['klubNev']} klub, {gyoztes['pontszam']} pont)")

#4. feladat
teljesitok = 0
for i in hajok:
    if i["pontszam"] < 557:
        teljesitok += 1

print(f"4. feladat: A távot {teljesitok} hajó teljesítette a megadott időn belül.")

#5. feladat
print("5. feladat:")
klubnev = input("    Klub neve nagybetűs alakban: ")

with open(f"{klubnev}.txt", "w", encoding="UTF-8") as f:
    for i in hajok:
        if i["klubNev"] == klubnev:
            f.writelines(i["hajoNev"] + "\n")