#beolvassa az allatok.txt fájlt, amiben a kulcs és az érték " - " -vel van elválasztva, majd eltárolja őket egy szótárban
with open("allatok.txt", "r") as f:
    allatok = {}
    for sor in f:
        kulcs, ertek = sor.split(" - ")
        allatok[kulcs] = ertek

#kérje be a felhasználótól egy új állat adatait, és adja hozzá a szótárhoz és a fájlhoz őket, ha még nem szerepelnek benne
positives = ["igen", "yes", "y", "i"]

while True:
    valtoztatas = input("Szerenél hozzáadni egy új adatot? (igen/*(=nem)): ")
    if valtoztatas in positives:
        valtoztatasErtekNev = input("Add meg a kulcs nevét: ")
        if valtoztatasErtekNev in allatok:
            print(f"A {valtoztatasErtekNev} már szerepel a szótárban!")
        else:
            valtoztatasErtekErtek = input("Add meg a kulcs értékét: ")
            allatok[valtoztatasErtekNev] = valtoztatasErtekErtek
            with open("allatok.txt", "a") as f:
                f.write(f"\n{valtoztatasErtekNev} - {valtoztatasErtekErtek}")
            print(f"A {valtoztatasErtekNev} hozzá lett adva a szótárhoz!")
            print(f"Szótár az új értékkel:\n{allatok}")
    else:
        break