#függvény, amely meghatározza két szám legnagyobb közös osztóját
def legnagyobbKozosOszto(a,b):
    while b > 0:
        a,b = b, a%b

    return a

a = int(input("Add meg az egyik számot: "))
b = int(input("Add meg a másik számot: "))

print(f"A két szám legnagyobb közös osztója: {legnagyobbKozosOszto(a,b)}")