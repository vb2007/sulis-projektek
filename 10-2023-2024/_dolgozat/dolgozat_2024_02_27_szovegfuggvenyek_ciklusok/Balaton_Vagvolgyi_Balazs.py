#1. kérd be a felhasználütül, hány hőmérsékletadatot szeretne eltárolni
homersekletadat = int(input("Kérem adja meg, hány hőmérsékletet szeretne tárolni: "))

#2. kért számú hőmérséklet random generálása (22 és 28 fok között)
from random import randint

homerseklet = []
k = 1
for i in range(homersekletadat):
    i = randint(22, 28)
    homerseklet.append(i)
    print(f"{k}. nap: {i} fok")
    k += 1

#3.a számold ki programozási tétellel, hogy mennyi az átlaghőmérséklet az adott időszakban (1 tizedesjegy pontossággal)
osszeg = 0
for i in homerseklet:
    osszeg += i
atlagHomerseklet = osszeg / len(homerseklet)
atlagHomerseklet = round(atlagHomerseklet, 1)

print(f"A Balaton átlaghőmérséklete: {atlagHomerseklet}")

#3.b egyparaméteres "Hideg" nevű függvény, mely megadja, hogy a megadott szám kisebb vagy egyenlő-e, mint 23 (logikai értéket az vissza)
def Hideg(szam):
    if szam <= 23:
        return True
    else:
        return False

#3.c hányszor volt hideg a balaton vize az adott időszakban a "Hideg" függvény használatával
hideg = 0
for i in homerseklet:
    if Hideg(i) == True:
        hideg += 1

print(f"A Balaton vize {hideg} alkalommal volt hideg.")