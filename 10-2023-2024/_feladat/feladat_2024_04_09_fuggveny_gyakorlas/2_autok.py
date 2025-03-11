#1. Olvassuk be a fájlt, táruljuk az adatot ahogy akarjuk
autok = []
with open("markakereskedes.txt", "r") as f:
    for i in f:
        auto = i.strip().split(";")
        autok.append({
            "modell" : auto[0],
            "darab" : int(auto[1]),
            "ar" : int(auto[2])
        })

#2. Hány darab autótípust olvastunk be
print(f"{len(autok)} darab autótípust olvastunk be.")

#3. Hány darab autó van készleten
osszeg = sum(i["darab"] for i in autok)
print(f"{osszeg} darab autó van készleten.")

#4. Mekkora a raktár össértéke?
osszeg = sum(i["ar"] for i in autok)
print(f"{osszeg} Ft a raktár összértéke.")

#5. Listázzuk az 5 000 000 Ft-nál olcsóbb autókat
olcsoautok = []
for i in autok:
    if i["ar"] < 5000000:
        olcsoautok.append(i)

print(f"Az 5 000 000 Ft-nál olcsóbb autók: {olcsoautok}")