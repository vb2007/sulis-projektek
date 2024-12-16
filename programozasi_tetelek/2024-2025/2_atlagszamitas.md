# Átlagszámítás

## Leíró nyelven

atl := 0
Ciklus i := 0-tól n-1-ig
&emsp;atl := atl + v[i]
Ciklus vége
atl:=atl

## Példa kód (C#)

```cs
double atl=0;
for(int i=0; i<n; i++)
{
    atl=atl+v[i];
}
atl=atl;
```
