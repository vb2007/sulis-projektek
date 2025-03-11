#minden első érték a kék kockáé, és minden második a pirosé
dobasok = [1, 5, 6, 4, 5, 5, 2, 1, 5, 6, 3, 1, 4, 5, 2, 6, 4, 1, 3, 2]

#1. játék
vizszintesenJobbra = 0
fuggolegesenFelfele = 0

for i in dobasok[0::2]:
    vizszintesenJobbra += i

for i in dobasok[1::2]:
    fuggolegesenFelfele += i

print(f"A bábú vízszintesen edidig jutott: {vizszintesenJobbra}")
print(f"A bábú fuggolegesen felfele jutott: {fuggolegesenFelfele}")

#2. játék
osszeg = 0
for i in range(0, len(dobasok), 2):
    a = dobasok[i]
    b = dobasok[i+1]

    if a > b:
        osszeg += a
    else:
        osszeg += b

print(f"A bábú eddig jutott: {osszeg}")