# Minimumválasztás

## Leíró nyelven

minert := v[0]<br>
minind := 0<br>
Ciklus i := 1-től n-1-ig<br>
&emsp;Ha (v[i] < minert)<br>
&emsp;&emsp;akkor<br>
&emsp;&emsp;&emsp;minert:=v[i]<br>
&emsp;&emsp;&emsp;minind:=i<br>
&emsp;Elágazás vége<br>
Ciklus vége<br>

## Példa kód (C#)

```cs
int minert=v[0];
int minind=0;
for(int i=1; i<n; i++)
{
    if(v[i]< minert)
    {
        minert=v[i];
        minind=i;
    }
}
```
