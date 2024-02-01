# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]
osszeg := 0
CIKLUS lista minden elem –ére
    osszeg += elem
CIKLUS vége
atlag := osszeg / n
KI: atlag

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
osszeg = 0
for elem in lista:
    osszeg += elem
atlag = osszeg / len(lista)
print(atlag)

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]
osszeg := 0
n:=lista elemszáma
CIKLUS index := 0 –tól n – 1 –ig:
    osszeg += lista[index]
CIKLUS vége
atlag := osszeg / n
KI: atlag

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
osszeg = 0
for index in range(len(lista)):
    osszeg += lista[index]
atlag = osszeg / len(lista)
print(atlag)