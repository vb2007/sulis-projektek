#függvény, ami kiszámítja a téglalap területét
def teglalapTerulet(a,b):
    k = a*b
    return k

a = int(input("Add meg a téglalap a oldalát: "))
b = int(input("Add meg a téglalap b oldalát: "))

print("A téglalap területe: ", teglalapTerulet(a,b))