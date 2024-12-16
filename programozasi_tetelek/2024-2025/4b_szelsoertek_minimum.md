# Minimumválasztás

## Leíró nyelven

minert := v[0]
minind := 0
Ciklus i := 1-től n-1-ig
&emsp;Ha (v[i] < minert)
&emsp;&emsp;akkor
&emsp;&emsp;&emsp;minert:=v[i]
&emsp;&emsp;&emsp;minind:=i
&emsp;Elágazás vége
Ciklus vége

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
