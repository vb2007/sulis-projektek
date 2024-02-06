#függvény, amely megmondja, hogy a paramétere prímtényezői között hány darap kettes van

def primtenyezobenLevoKettesek(a):
    count = 0
    while a % 2 == 0:
        a = a // 2
        count += 1
    
    return count

a = int(input("Adj meg egy számot: "))

print(f"A szám prímtényezői között {primtenyezobenLevoKettesek(a)} darab kettes van.")