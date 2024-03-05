#egy macska nevét és korát eltárolja egy szótárba
nev = input("Add meg a macska nevét: ")
kor = int(input("Add meg a macska életkorát: "))

macska = {
    "nev": nev,
    "kor": kor
}

#a felhasználó meg tudja változtatni az egyik tárolt adatot
positives = ["igen", "yes", "y", "i"]
# negatives = ["nem", "no", "n"]

valtoztatas = input("Változtatni szeretnéd a macska egyik adatát? (igen/nem): ")
if valtoztatas in positives:
    valtoztatasErtek = input("Melyik adatot szeretnéd változtatni? (nev/kor): ")
    if valtoztatasErtek == "nev":
        print(f"A macsaka neve jelenleg: {nev}")
        nev = input("Add meg a macska új nevét: ")
        macska["nev"] = nev
    if valtoztatasErtek == "kor":
        print(f"A macsaka életkor jelenleg: {kor}")
        kor = int(input("Add meg a macska új életkorát: "))
        macska["kor"] = kor

print(f"A macska adatai:\n{macska}")