# Maximumválasztás

## Leíró nyelven

maxert := v[0]
maxind := 0
Ciklus i := 1-től n-1-ig
&emsp;Ha (v[i] > maxert)
&emsp;&emsp;akkor
&emsp;&emsp;&emsp;maxert:=v[i]
&emsp;&emsp;&emsp;maxind:=i
&emsp;Elágazás vége
Ciklus vége

## Példa kód (C#)

```cs
int maxert=v[0];  
int maxind=0;  
for(int i=1; i<n; i++)
{
    if(v[i]> maxert)  
    {
        maxert=v[i];
        maxind=i;
    }
}
```
