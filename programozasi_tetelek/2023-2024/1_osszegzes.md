# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]<br>
osszeg := 0<br>
CIKLUS lista minden elem –ére<br>
&emsp;osszeg += elem<br>
CIKLUS vége<br>
KI: osszeg<br>

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]<br>
osszeg = 0<br>
for elem in lista:<br>
&emsp;osszeg += elem<br>
print(osszeg)<br>

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]<br>
osszeg := 0<br>
n:=lista elemszáma<br>
CIKLUS index := 0 –tól n – 1 –ig:<br>
&emsp;osszeg += lista[index]<br>
CIKLUS vége<br>
KI: osszeg<br>

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]<br>
osszeg = 0<br>
for index in range(len(lista)):<br>
&emsp;osszeg += lista[index]<br>
print(osszeg)