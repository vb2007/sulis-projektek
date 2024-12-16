# Lineáris keresés

## Leíró nyelven

i:=-1

sorsz:=-1

van:=hamis

Ciklus amíg (-van és i<n-1)

&emsp;i:=i+1

&emsp;Ha (T(v[i]))

&emsp;&emsp;akkor

&emsp;&emsp;&emsp;van:=igaz

&emsp;&emsp;&emsp;sorsz:=i

&emsp;&emsp;Elágazás vége

Ciklus vége

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
