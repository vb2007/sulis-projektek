# Lineáris keresés

## Leíró nyelven

i:=-1<br>
sorsz:=-1<br>
van:=hamis<br>
Ciklus amíg (-van és i<n-1)<br>
&emsp;i:=i+1<br>
&emsp;Ha (T(v[i]))<br>
&emsp;&emsp;akkor<br>
&emsp;&emsp;&emsp;van:=igaz<br>
&emsp;&emsp;&emsp;sorsz:=i<br>
&emsp;&emsp;Elágazás vége<br>
Ciklus vége<br>

## Példa kód (C#)

```cs
int i=-1;
int sorsz=-1;
bool van=false;
while(!van && i<n-1)
{
    i++;
    if(T(v[i]))
    {
        van=true;
        sorsz=i;
    }
}
```
