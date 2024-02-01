# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]
darab := 0
CIKLUS lista minden elem –ére
    HA T(elem):
        darab += 1
    HA vége
CIKLUS vége
KI: darab

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
darab = 0
for elem in lista:
    if elem%2 == 0:
darab += 1
print(darab)

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]
darab := 0
n:=lista elemszáma
CIKLUS index := 0 –tól n – 1 –ig:
    HA T(elem):
        darab += 1
    HA vége
CIKLUS vége
KI: darab

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
darab = 0
for index in range(len(lista)):
    if lista[index]%2 == 0:
darab += 1
print(darab)