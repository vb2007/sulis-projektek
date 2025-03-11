# Eldöntés

## Leíró nyelven

i:=-1<br>
van:=hamis<br>
Ciklus amíg (-van és i<n-1)<br>
&emsp;i:=i+1<br>
&emsp;Ha (T(v[i]))<br>
&emsp;&emsp;akkor<br>
&emsp;&emsp;&emsp;van:=igaz<br>
&emsp;Elágazás vége<br>
Ciklus vége<br>

## Példa kód (C#)

```cs
int i=-1;
bool van=false;
while(!van && i<n-1)
{
    i++;
    if(T(v[i]))
    {
        van=true;
    }
}
```
