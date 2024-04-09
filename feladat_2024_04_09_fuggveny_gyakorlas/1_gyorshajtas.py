#1. tegyük az adatokat egy autók nevű listába. az adatok szótárakban legyenek
autok = []
with open ("gyorshajtas.txt", "r") as f:
    for i in f:
        auto = i.strip().split(";")
        autok.append({
            "rendszam" : auto[0],
            "marka" : auto[1],
            "sebesseg" : auto[2]
        })

#2. hány darab autót olvastunk be?
print(f"{len(autok)} darab autót olvastunk be.")

#3. Melyik gépjármű ment a leggyorsabban?
leggyorsabb = max([i["rendszam"] for i in autok])
print(f"A leggyorsabban ment a {leggyorsabb} rendszámú gépjármű.")

#4. Hányan lépték túl az 50 km/h -s határt?
gyorshajtok = [i["sebesseg"] for i in autok if int(i["sebesseg"]) > 50]
gyorshajtokSzama = len(gyorshajtok)
print(f"{gyorshajtokSzama} gépjármű lépték túl az 50 km/h -s határt.")

#5. Kiírja a gyorshajtók rendszámait vesszővel elválasztva.
gyorshajtok = []
for i in autok:
    if int(i["sebesseg"]) > 50:
        gyorshajtok.append(i["rendszam"])
print(f"A gyorshajtók rendzsámai: {','.join([i for i in gyorshajtok])}")