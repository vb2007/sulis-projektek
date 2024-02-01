# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7]
min := lista[0]
CIKLUS lista minden elem –ére
    HA elem < min:
        min:=elem
    HA vége
CIKLUS vége
KI: min

## Példa kód:
lista = [1, 2, 5, 6, 7]
min = lista[0]
for elem in lista:
    if elem < min:
        min = elem
print(min)

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7]
min := lista[0]
min_index := 0
n:=lista elemszáma
CIKLUS index := 1 –tól n – 1 –ig :
    HA lista[index] < min:
        min := lista[index]
        min_index := index
    HA vége
CIKLUS vége
KI: min
KI: min_index + 1

## Példa kód:
lista = [1, 2, 5, 6, 7]
min = lista[0]
min_index = 0
for index in range(1, len(lista)):
    if lista[index] < min:
        min = lista[index]
        min_index = index
print(min, min_index + 1)