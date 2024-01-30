def pozitiv(a,b,c):
    if (a % 2 == 0) and (b % 2 == 0) and (c % 2 == 0):
        print(f"Mind a három szám ({a},{b},{c}) pozitív.")
    else:
        print("Nem pozitív mind a három szám.")

a = int(input("Adj meg egy számot: "))
b = int(input("Adj meg mégegyet: "))
c = int(input("Adj meg mégegyet: "))

pozitiv(a,b,c)