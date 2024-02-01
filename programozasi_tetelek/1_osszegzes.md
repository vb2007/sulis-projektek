# Érték szerint
<hr>

## Leíró nyelven:
<p>lista =[1, 2, 5, 6, 7, 9]</p>
<p>osszeg := 0</p>
<p>CIKLUS lista minden elem –ére</p>
<p>    osszeg += elem</p>
<p>CIKLUS vége</p>
<p>KI: osszeg</p>

## Példa kód:
<p>lista = [1, 2, 5, 6, 7, 9]</p>
<p>osszeg = 0</p>
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