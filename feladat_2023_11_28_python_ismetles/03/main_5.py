#5. Feladat
import math
hossz1 = int(input("Téglalap egyik oldalának hossza: "))
hossz2 = int(input("Téglalap másik oldalának hossza: "))

print("Kerülete: ", 2*(hossz1 + hossz2))
print("Területe: ", hossz1 * hossz2)

sugar = int(input("Add meg egy körnek a sugarát: "))

print("Kerülete ", 2 * sugar * math.pi)
print("Területe ", sugar**2 * math.pi)