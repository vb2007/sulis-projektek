# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]<br>
darab := 0<br>
CIKLUS lista minden elem –ére<br>
&emsp;HA T(elem):<br>
&emsp;&emsp;darab += 1<br>
&emsp;HA vége<br>
CIKLUS vége<br>
KI: darab<br>

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]<br>
darab = 0<br>
for elem in lista:<br>
&emsp;if elem%2 == 0:<br>
&emsp;&emsp;darab += 1<br>
print(darab)<br>

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]<br>
darab := 0<br>
n:=lista elemszáma<br>
CIKLUS index := 0 –tól n – 1 –ig:<br>
&emsp;HA T(elem):<br>
&emsp;&emsp;darab += 1<br>
&emsp;HA vége<br>
CIKLUS vége<br>
KI: darab<br>

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]<br>
darab = 0<br>
for index in range(len(lista)):<br>
&emsp;if lista[index]%2 == 0:<br>
&emsp;&emsp;darab += 1<br>
print(darab)