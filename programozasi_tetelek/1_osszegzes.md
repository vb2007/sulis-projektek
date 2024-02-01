# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]<br>
osszeg := 0<br>
CIKLUS lista minden elem –ére<br>
&nbsp;osszeg += elem<br>
CIKLUS vége<br>
KI: osszeg<br>

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
osszeg = 0
for elem in lista:
    osszeg += elem
print(osszeg)

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]
osszeg := 0
n:=lista elemszáma
CIKLUS index := 0 –tól n – 1 –ig:
    osszeg += lista[index]
CIKLUS vége
KI: osszeg

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]
osszeg = 0
for index in range(len(lista)):
    osszeg += lista[index]
print(osszeg)