#függvény, mely meghatározza az ax2+bx+c=0 másodfokú függvény megoldását

def masodfokuFuggveny(a,b,c):
    diszkriminans = b**2 - 4 * a * c
    x1 = (-b + diszkriminans) / (2*a)
    x2 = (-b - diszkriminans) / (2*a)

    return x1, x2

a = int(input("Add meg a függvény a értékét: "))
b = int(input("Add meg a függvény b értékét: "))
c = int(input("Add meg a függvény c értékét: "))

print(f"A másodfokú függvény megoldása: {masodfokuFuggveny(a,b,c)}")