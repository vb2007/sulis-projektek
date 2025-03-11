# Maximumválasztás

## Leíró nyelven

maxert := v[0]<br>
maxind := 0<br>
Ciklus i := 1-től n-1-ig<br>
&emsp;Ha (v[i] > maxert)<br>
&emsp;&emsp;akkor<br>
&emsp;&emsp;&emsp;maxert:=v[i]<br>
&emsp;&emsp;&emsp;maxind:=i<br>
&emsp;Elágazás vége<br>
Ciklus vége<br>

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
