#1. olvasd be az adatokat, és tárold el egy szótár típusú listában
nevsor = []
with open("nevsor.txt", 'r') as f:
    next(f)
    for i in f:
        szavak = i.strip().split(";")
        nevsor.append({
            "nev": str(szavak[0]),
            "kor" : float(szavak[1]),
            "nem" : str(szavak[2])
        })

#2. hány jelentkezőt olvastunk be?
print(f"2. feladat: {len(nevsor)} jelentkező van.")

#3. ki a legfiatalabb jelentkező
legfiatalabbJelentkezo = min(nevsor, key=lambda i: i["kor"])
print(f"3. feladat: {legfiatalabbJelentkezo['nev']}, {legfiatalabbJelentkezo['kor']} éves, {legfiatalabbJelentkezo['nem']}")

#4. irassuk ki, hogy hány kiskorú (18 alatti) jelentkezett a versenyre
kiskorujJelentkezo = 0
for i in nevsor:
    if i["kor"] <= float(18):
        kiskorujJelentkezo += 1

print(f"4. feladat: 18 éven aluliak {kiskorujJelentkezo}-an vannak.")

#5. írj egy eljárást, ami kilistázza a nők nevét egymás mellé, vesszővel elválasztva
def noiJelentkezok():
    nok = []
    for i in nevsor:
        if i["nem"] == "nő":
            nok.append(i["nev"])
    print("5. feladat:", ", ".join(nok))

noiJelentkezok()