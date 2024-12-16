# Megszámlálás

## Leíró nyelven

db := 0

Ciklus i := 0-tól n-1-ig

&emsp;Ha (T(v[i]))

&emsp;&emsp;akkor

&emsp;&emsp;&emsp;db:=db+1

&emsp;Elágazás vége

Ciklus vége

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
