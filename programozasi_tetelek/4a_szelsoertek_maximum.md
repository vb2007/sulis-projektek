# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]
max := lista[0]
CIKLUS lista minden elem –ére
    HA elem > max:
        max:=elem
    HA vége
CIKLUS vége
KI: max

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
max = lista[0]
for elem in lista:
    if elem > max:
        max = elem
print(max)

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7]
max := lista[0]
max_index := 0
n:=lista elemszáma
CIKLUS index := 1 –tól n – 1 –ig :
    HA lista[index] > max:
        max := lista[index]
        max_index := index
    HA vége
CIKLUS vége
KI: max
KI: max_index + 1

## Példa kód:
lista = [1, 2, 5, 6, 7]
max = lista[0]
max_index = 0
for index in range(1, len(lista)):
    if lista[index] > max:
        max = lista[index]
        max_index = index
print(max, max_index + 1)