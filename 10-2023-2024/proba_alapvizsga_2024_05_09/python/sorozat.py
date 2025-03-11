n = int(input("Számjegyek száma (pozitív egész): "))

sorozat = "01" * (n // 2) + "0" * (n % 2)

print("A jelsorozat: ", sorozat)