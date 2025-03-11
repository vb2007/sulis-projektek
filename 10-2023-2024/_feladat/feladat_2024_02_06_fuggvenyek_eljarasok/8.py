#függvény, amely 16-os számrendszerből 10-esbe vált

def decimalToBase10(a):
    return hex(a)[2:].upper()

a = int(input("Adj meg egy számot: "))

print(f"A(z) {a} szám 16-os számrendszerben: {decimalToBase10(a)}")