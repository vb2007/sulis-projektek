# Érték szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7, 9]<br>
max := lista[0]<br>
CIKLUS lista minden elem –ére<br>
&emsp;HA elem > max:<br>
&emsp;&emsp;max:=elem<br>
&emsp;HA vége<br>
CIKLUS vége<br>
KI: max<br>

## Példa kód:
lista = [1, 2, 5, 6, 7, 9]<br>
max = lista[0]<br>
for elem in lista:<br>
&emsp;if elem > max:<br>
&emsp;&emsp;max = elem<br>
print(max)<br>

# Index szerint
<hr>

## Leíró nyelven:
lista =[1, 2, 5, 6, 7]<br>
max := lista[0]<br>
max_index := 0<br>
n:=lista elemszáma<br>
CIKLUS index := 1 –tól n – 1 –ig :<br>
&emsp;HA lista[index] > max:<br>
&emsp;&emsp;max := lista[index]<br>
&emsp;&emsp;max_index := index<br>
&emsp;HA vége<br>
CIKLUS vége<br>
KI: max<br>
KI: max_index + 1<br>

## Példa kód:
lista = [1, 2, 5, 6, 7]<br>
max = lista[0]<br>
max_index = 0<br>
for index in range(1, len(lista)):<br>
&emsp;if lista[index] > max:<br>
&emsp;&emsp;max = lista[index]<br>
&emsp;&emsp;max_index = index<br>
print(max, max_index + 1)