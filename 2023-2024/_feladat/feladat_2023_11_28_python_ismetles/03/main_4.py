#4. Feladat
import math

x = int(input("Adj meg egy számot: "))

print("Négyzete: ", x**2)
print("Köbe: ", x**2)

print("Négyzete (máshogy): ", math.pow(x, 2))
print("Köbe (máshogy): ", math.pow(x, 3))

y = int(input("Add meg mennyivel akarod hatványozni: "))

print("Álatad beírt kitevővel hatványozott számod értéke: ", x**y)