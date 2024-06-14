tavak = []

with open("alloviz.txt", "r", encoding="utf-8") as f:
    next(f) #átugorja az első sort
    for i in f:
        to = i.strip().split("\t")
        tavak.append({
            "nev" : str(to[0]),
            "tipus" : str(to[1]),
            "terulet" : float(to[2]),
            "vizgyujto" : int(to[3])
        })

#1. írd ki, hány tó adatai vannak tárolva
print(f"{len(tavak)} tó adatai vannak tárolva.")

#2. magyarország összterületének (93036 km2) hány százalékát fedik le a tavak?
osszterulet = sum(i["terulet"] for i in tavak)
print(f"Magyarország {osszterulet / 93036:.2f} százalékát fedik le a tavak.")

#3. melyik tó rendelkezik a legnagyobb vizgyűjtővel?
legnagyobbVizgyujto = max(tavak, key=lambda i: i["vizgyujto"])
print(f"""A legnagyobb vízgyűjtú területű állóvíz: {legnagyobbVizgyujto['nev']}
    Típusa: {legnagyobbVizgyujto['tipus']}
    Vízfelszíne: {legnagyobbVizgyujto['vizgyujto']}
    Területe: {legnagyobbVizgyujto['terulet']} km2""")

#4. írjuk ki a közepes tavak nevét és típusát a kozepes.txt fájlba
# egy tó akkor közepes, ha legalább 3 és legfeljebb 10 km2
kozepesTavak = []
for i in tavak:
    if i["terulet"] >= 3 and i["terulet"] <= 10:
        kozepesTavak.append(i["nev"] + ";" + i["tipus"] + "\n")

with open ("kozepes.txt", "w", encoding="utf-8") as f:
    f.writelines(kozepesTavak)
