#függvény, amely megadja, hogy a paraméterének hány osztója van

def hanyOsztojaVan(a):
    osztok = []
    for i in range(a):
        if a % (i + 1) == 0:
            osztok.append(i+1)
            
    return osztok

a = int(input("Adj meg egy számot: "))

print(f"A szám osztója: {hanyOsztojaVan(a)}")