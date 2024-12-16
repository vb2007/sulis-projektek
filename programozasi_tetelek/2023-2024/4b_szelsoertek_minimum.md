# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7]<br>
min := lista[0]<br>
CIKLUS lista minden elem –ére<br>
&emsp;HA elem < min:<br>
&emsp;&emsp;min:=elem<br>
&emsp;HA vége<br>
CIKLUS vége<br>
KI: min<br>

## Példa kód:
lista = [1, 2, 5, 6, 7]<br>
min = lista[0]<br>
for elem in lista:<br>
&emsp;if elem < min:<br>
&emsp;&emsp;min = elem<br>
print(min)<br>

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7]<br>
min := lista[0]<br>
min_index := 0<br>
n:=lista elemszáma<br>
CIKLUS index := 1 –tól n – 1 –ig :<br>
&emsp;HA lista[index] < min:<br>
&emsp;&emsp;min := lista[index]<br>
&emsp;&emsp;min_index := index<br>
&emsp;HA vége<br>
CIKLUS vége<br>
KI: min<br>
KI: min_index + 1<br>

## Példa kód:
lista = [1, 2, 5, 6, 7]<br>
min = lista[0]<br>
min_index = 0<br>
for index in range(1, len(lista)):<br>
&emsp;if lista[index] < min:<br>
&emsp;&emsp;min = lista[index]<br>
&emsp;&emsp;min_index = index<br>
print(min, min_index + 1)