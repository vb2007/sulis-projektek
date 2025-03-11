import random, math

affermatives = ["igen", "i", "yes", "y"]
negatives = ["nem", "n", "no"]

choose = str(input("Megadod a kocka élét? [i/n]: "))
if choose in affermatives:
    el = random.randint(10,50)
elif choose in negatives:
    el = int(input("Akkor add meg a kocka élét: "))
else:
    print("Érvénytelen válasz.")

felszin = 6 * el ** 2
terfogat = el ** 3
lapatlo = el * math.sqrt(2)
testatlo = el * math.sqrt(3)

print(f"Felszín: {felszin}")
print(f"Térfogat: {terfogat}")
print(f"Lapátló: {lapatlo}")
print(f"Testátló: {testatlo}")