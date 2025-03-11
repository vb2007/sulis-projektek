from random import randint

elemszam = int(input("Add meg egy lista elemszámát: "))
lista = []

for i in range(elemszam):
    n = randint(1,100)
    lista.append(n)

n = 1
for i in lista:
    print(f"{n}. elem: {[i]}")
    n += 1

print(*range(elemszam), sep="; ")