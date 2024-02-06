#függvány amely eldönti, hogy szám-e a prímszám

def primszam(a):
    if a == 1:
        return f"A(z) {a} nem prímszám."
    elif a > 1:
        for i in range(2, a):
            if (a % i) == 0:
                return f"A(z) {a} nem prímszám."
            else:
                return f"A(z) {a} prímszám."

a = int(input("Adj meg egy számot: "))

print(primszam(a))