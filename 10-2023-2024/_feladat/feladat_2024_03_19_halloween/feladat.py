#1. olvasd be a fájlokat egy listába, melynek elemei dict típusúak
import csv

edessegek = []

with open("edesseg.csv", "r", encoding="utf-8") as f:
  reader = csv.reader(f, delimiter=";")
  next(reader)
  for i in reader:
    edessegek.append({
        "nev" : i[0],
        "darab" : int(i[1]),
        "tipus" : i[2]
    })

#2. jelenítsd meg a képernyőn az adatokat
print(edessegek)

#3. számold meg, hogy összesen mennyi édességet gyűjtöttek össze a diákok
osszeg = 0
for i in edessegek:
    osszeg += int(i["darab"])

print(f"Összesen {osszeg} darab edességet gyűjtöttek össze.")

#4. válogasd ki azoknak a tanulóknak a nevét, akik csak csokoládét gyűjtöttek
csokoladetGyujtok = []
for i in edessegek:
    if i["tipus"] == "csokoládé":
        csokoladetGyujtok.append(i["nev"])

with open("csoki.txt", "w", encoding="utf-8") as f:
    for i in csokoladetGyujtok:
        f.write(i + "\n")

#print(csokoladetGyujtok)

#5. számold meg, hogy egy gyerek átlagosan hány édességet gyűjtött össze
osszeg = 0
for i in edessegek:
    osszeg += int(i["darab"]) / len(edessegek)

print(f"Egy gyerek átlagosan {osszeg} darab edességet gyűjtött.")

#6. számold meg, hányan gyűjtöttek csokoládét és cukorkát is
osszeg = 0
for i in edessegek:
    if i["tipus"] == "mindkettő":
        osszeg += 1

print(f"{osszeg} gyerek gyűjtött csokoládét és cukorkát is.")

#7. ki gyűjtött a legtöbb édességet? írd ki a nevét, hány édességet és mit gyűjtött össze
nyertes = max(edessegek, key=lambda x: x["darab"])

print(f"A nyertes {nyertes['nev']}, aki {nyertes['darab']} darab edességet gyűjtött össze {nyertes['tipus']} típusból.")

#8. olvass be egy nevet, és írd ki hogy részt vett-e az eseményen. és ha igen, akkor mennyi édességet gyűjtött össze
nev = input("Add meg egy diák nevét: ")

for i in edessegek:
    if i["nev"] == nev:
        print(f"{nev} részt vett az eseményen, és {i['darab']} darab edességet gyűjtött össze.")
        break

#9. olvass be egy számot, és döntsd el, hogy volt-e olyan diák, aki legalább ennyi édességet gyűjtött össze
darab = int(input("Add meg egy darabszámot: "))

for i in edessegek:
    if i["darab"] >= darab:
        print(f"Van olyan versenyző, aki legalább {darab} darab edességet gyűjtött össze.")

#10. számold ki azoknak a diákoknak az összes és átlagos telejsítményét, akik csak cukorkát gyűjtöttek
osszeg = 0
for i in edessegek:
    if i["tipus"] == "cukorka":
        osszeg += int(i["darab"])
atlag = osszeg / len(edessegek)

print(f"A cukorkát gyűjtő diákok össztelejsítménye {osszeg}, az átlagos telejsítmény pedig {atlag}.")