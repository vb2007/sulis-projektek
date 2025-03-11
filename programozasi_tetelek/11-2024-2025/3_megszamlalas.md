# Megszámlálás

## Leíró nyelven

db := 0<br>
Ciklus i := 0-tól n-1-ig<br>
&emsp;Ha (T(v[i]))<br>
&emsp;&emsp;akkor<br>
&emsp;&emsp;&emsp;db:=db+1<br>
&emsp;Elágazás vége<br>
Ciklus vége<br>

## Példa kód (C#)

```cs
int db=0;
for(int i=0; i<n; i++)
{
    if(T(v[i]))
    {
        db++;
    }
}
```
