a = float(input("Adj meg egy pozitív valós számot: "))
b = float(input("Még egyet: "))
c = float(input("Még egyet: "))

if a < b + c and b < a + c and c < a + b:
    print("Szerkesztehtő háromszög.")
else:
    print("Nem szerkeszthető háromszög.")