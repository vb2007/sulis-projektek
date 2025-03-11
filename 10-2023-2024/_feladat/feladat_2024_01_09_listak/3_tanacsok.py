tancosok = [['Katalin', 'Ede'],   
    ['Olga', 'Olivér'],   
    ['Éva', 'Ádám'],   
    ['Bea', 'Béla'],   
    ['Anna', 'Pál']]

print("Mi a neve az első páros fiú táncosának?")
print(tancosok[0][1])
print("\n")

print("Mi a neve az utoljára táncoló lánynak?")
print(tancosok[-1][0])
print("\n")

print("Hány pár vesz részt a versenyen?")
print(len(tancosok))
print("\n")

print("Írjuk ki a lányok neveit a fellépés sorrendjében!")
for lany in tancosok:
    print(lany[0])
print("\n")

print("A fiuk nevű listába gyűjtsük ki a fiúk neveit!")
fiuk = []
for fiu in tancosok:
    fiuk.append(fiu[1])
#print(fiuk)
print("\n")

print("Írjuk ki azoknak a pároknak a nevét, akiknél a nevük kezdőbetűje megegyezik!")
for tancos in tancosok:
    if(tancos[0][0][0] == tancos[1][0][0]):
        print(tancos)
print("\n")