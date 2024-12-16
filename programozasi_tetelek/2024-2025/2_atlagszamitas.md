# Átlagszámítás

## Leíró nyelven

atl := 0<br>
Ciklus i := 0-tól n-1-ig<br>
&emsp;atl := atl + v[i]<br>
Ciklus vége<br>
atl:=atl<br>

## Példa kód (C#)

```cs
double atl=0;
for(int i=0; i<n; i++)
{
    atl=atl+v[i];
}
atl=atl;
```
