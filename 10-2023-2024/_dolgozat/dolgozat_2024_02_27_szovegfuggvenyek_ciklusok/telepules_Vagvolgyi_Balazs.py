#1. másold be a listát és jelenítsd meg hány név szerepel benne
telepulesek = ["Ábrahámhegy", "Badacsonytomaj", "Balatonboglár", "Balatonföldvár", "Balatonfüred", "Balatongyörök", "Balatonlelle", "Balatonrendes", "Gyenesdiás", "Keszthely", "Örvényes", "Paloznak", "Sajkod", "Vonyarcvashegy", "Zánka"]

print(f"{len(telepulesek)} település van a listában.")

#2. írd ki az adatokat fordított sorrendben egymás alá, csupa nagybetűvel
for szo in telepulesek:
    print(szo[::-1].swapcase())

#3. "Balaton" nevű paraméter nélküli eljárás, mely a "Balaton" szavakat tartalmazó neveket
balatonNevek = []
def Balaton():
    for nev in telepulesek:
        if "balaton" in nev.lower():
            balatonNevek.append(nev)
    print(balatonNevek, sep=", ")

#4. jelenítsd meg az előző eljárással a "Balaton" szót tartalmazó településeket
Balaton()

#5.a írd ki programozási tétellel, hogy összesen hány karakterből állnak a nevek
osszeg = 0
for i in telepulesek:
    osszeg += len(i)

print(f"A listában összesen {osszeg} karakter szerepel.")

#5.b településnév beolvasása, majd nevének és helyének kiírása, ha szerepel a listában
keresettTelepules = input("Kérem adjon meg egy településnevet: ")

talalat = False
i = 0

while i < len(telepulesek) and not talalat:
    if telepulesek[i].lower() == keresettTelepules.lower():
        talalat = True
    else:
        i += 1

if talalat:
    print(f"A(z) {keresettTelepules} a(z) {i + 1}. helyen szerepel a listában.")
else:
    print(f"A(z) {keresettTelepules} nem szerepel a listában.")

#5.c a leghosszabb név, és ahány karakterből áll
maximum = telepulesek[0]
for i in telepulesek:
    if len(i) > len(maximum):
        maximum = i

print(f"{maximum} a leghosszabb név ({len(maximum)} karakter)")

#6. véletlen elemválasztás a listából + elem kiírása
from random import choice, randint

randomTelepules = choice(telepulesek)

print(f"A kiválasztott település: {randomTelepules}")

jelszo = randomTelepules[::3] #vedd a string minden 3. karakterét

randomSzam = randint(100,999) #generálj egy 3 jegyű véletlen számot
jelszo = jelszo + str(randomSzam) #és fűzd hozzá

elsoSzo = telepulesek[0]
masodikKarakter = elsoSzo[1]
jelszo = jelszo + masodikKarakter.upper() #lista első elemének második karakterének hozzáfűzése nagybetűs formában

print(f"A generált jelszó: {jelszo}")