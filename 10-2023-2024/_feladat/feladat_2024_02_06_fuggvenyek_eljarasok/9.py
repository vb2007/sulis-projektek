#függvény, ami eldönti, hogy a paramétere öttel osztható páratlan szám-e

def ottelOszthatoParatlan(a):
    if (a % 5) == 0 and not (a % 2) == 0:
        return f"A(z) {a} szám osztható 5-tel és páratlan."
    else:
        return f"A(z) {a} szám vagy nem osztható 5-tel, vagy nem páratlan, vagy mindkettő."

a = int(input("Adj meg egy számot: "))

print(ottelOszthatoParatlan(a))