#1. olvasd be a neveket, és tárold el listában (első sor kivételével)
nevek = []
with open("nevek.txt", "r", encoding="utf-8") as file:
    next(file)
    for sor in file:
        nevek.append(sor.strip())

#2. kiírja, hány elem van a listában
print(f"A listában: {len(nevek)} elem van.")

#3. "K" betűvel kezdődő nevek megjelenítése egymás mellett, vesszővel elválasztva
print("K betűvel kezdődő nevek: ")
for nev in nevek:
    if nev[0] == "K":
        print(nev, end=", ")

#4. "hanyan" nevű eljárás, megmegmondja hány bizonyos keresztnevű diák van
def hanyan(keresztnev):
    szam = 0
    for nev in nevek:
        nev = nev.lower()
        if nev.split()[1] == keresztnev.lower():
            szam += 1
    return szam

keresztnev = input("\nAdd meg egy keresztnevet: ")
print(f"A listában {hanyan(keresztnev)} db {keresztnev} nevű diák van.")

#5. a "hanyan" eljárással kiírja, hogy hány "Csaba" van a listában
print(f"A listában {hanyan('Csaba')} db Csaba nevű diák van.")

#6. beolvas egy nevet, majd kiírja, hogy szerepel-e az adott név a listában (és ha igen, akkor a lista hanyadik eleme)
keresettNev = input("\nAdd meg egy nevet: ")
talalat = False
for nev in nevek:
    if nev == keresettNev:
        talalat = True

if talalat:
    print(f"A {keresettNev} név szerepel a listában.")
    print(f"A {keresettNev} név a lista {nevek.index(keresettNev)+1}. eleme.")
else:
    print(f"A {keresettNev} név nem szerepel a listában.")

#7. kiírja a legrövidebb tanuló nevét, és hogy az a név hány karakterből áll
print(f"A lista legrövidebb eleme: {min(nevek, key=len)}, mely {len(min(nevek, key=len))} karakterből áll.")

#8. egy "vezeteknev" lista, melyben a vezetéknevek szerepelnek csupa nagybetűvel
vezeteknevek = []
for nev in nevek:
    nev = nev.upper()
    vezeteknevek.append(nev.split()[0])

#9. kiírja, átlagosan hány karakterből állnak a lista elemei
hossz = sum(len(i) for i in vezeteknevek)
darab = len(vezeteknevek)
atlagHossz = round(hossz / darab)
print(f"A lista átlagosan {atlagHossz} karakterből áll.")

#10. egy "visszafele" lista, mely tartalmazza a lista összes elemét visszafele
nevekVisszafele = []
for nev in nevek:
    nevekVisszafele.append(nev[::-1])

#11. -- nem lehet megcsinálni, más feladatból lett átmásolva

#12. az első olyan versenyző kiválasztása, akinek a neve legalább 17 karakterből áll
i = 0
while(i <= len(nevek)):
        if len(nevek[i]) >= 17:
            print(f"Az első olyan versenyző, aki legalább 17 karakterből áll: {nev}")
        i += 1

#print(nevekVisszafele)
#print(vezeteknevek)
#print(nevek)
