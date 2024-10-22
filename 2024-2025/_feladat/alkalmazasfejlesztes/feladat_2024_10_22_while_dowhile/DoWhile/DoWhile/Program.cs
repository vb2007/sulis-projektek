#region 1. Feladat
Random rnd = new Random();

int dobas1;
int i1 = 0;
//do while-al
do
{
    dobas1 = rnd.Next(1, 7);
    Console.WriteLine(dobas1);
    i1++;
} while (dobas1 != 6);

Console.WriteLine($"{i1}. dobásra sikerült 6-ost dobi.");

//while-al
int dobas12 = rnd.Next(1, 7);
int i12 = 0;
while (dobas12 != 6)
{
    dobas12 = rnd.Next(1, 7);
    Console.WriteLine(dobas12);
    i12++;
}

Console.WriteLine($"{i12}. dobásra sikerült 6-ost dobi.");
#endregion

#region 2. Feladat
int dobas21;
int dobas22;
int i2 = 0;
do
{
    dobas21 = rnd.Next(1, 7);
    dobas22 = rnd.Next(1, 7);
    Console.WriteLine($"{dobas21}; {dobas22}");
    i2++;
} while (dobas21 != dobas22);

Console.WriteLine($"{i2}. dobásra sikerült ugyan olyan értéket dobni.");
#endregion

#region 3. Feladat
int dobas31;
int dobas32;
int dobas33;
int i3 = 0;
do
{
    dobas31 = rnd.Next(1, 7);
    dobas32 = rnd.Next(1, 7);
    dobas33 = rnd.Next(1, 7);
    Console.WriteLine($"{dobas31}; {dobas32}; {dobas33}");
    i3++;
} while (dobas31 != 6 && dobas32 != 6 && dobas33 != 6);

Console.WriteLine($"{i3}. dobásra sikerült legalább egy 6-ost dobni.");
#endregion

#region 4. Feladat
int dobas41;
int dobas42;
int dobas43;
int i4 = 0;
do
{
    dobas41 = rnd.Next(1, 7);
    dobas42 = rnd.Next(1, 7);
    dobas43 = rnd.Next(1, 7);
    Console.WriteLine($"{dobas41}; {dobas42}; {dobas43}");
    i4++;
} while (dobas41 < 5 || dobas42 < 5 || dobas43 < 5);

Console.WriteLine($"{i4}. dobásra lett mindegyik érték legalább 5.");
#endregion

#region 5. Feladat
int dobas51;
int dobas52;
int dobas53;
int i5 = 0;
do
{
    dobas51 = rnd.Next(1, 7);
    dobas52 = rnd.Next(1, 7);
    dobas53 = rnd.Next(1, 7);
    Console.WriteLine($"{dobas51}; {dobas52}; {dobas53}");
    i5++;
}
while (dobas51 % 3 != 0 || dobas52 % 3 != 0 || dobas53 % 3 != 0);

Console.WriteLine($"{i5}. dobásra lett mindegyik érték 3-mal osztható.");
#endregion

#region 6. Feladat
int dobas61;
int dobas62;
int dobas63;
int i6 = 0;
do
{
    dobas61 = rnd.Next(1, 7);
    dobas62 = rnd.Next(1, 7);
    dobas63 = rnd.Next(1, 7);
    Console.WriteLine($"{dobas61}; {dobas62}; {dobas63}");
    i6++;
} while (dobas61 != dobas62 && dobas62 != dobas63 && dobas61 != dobas63);

Console.WriteLine($"{i6}. dobásra lett legalább 2 kockán ugyanaz az érték.");
#endregion

#region 7. Feladat
int dobas71;
int dobas72;
int dobas73;
int i7 = 0;
do
{
    dobas71 = rnd.Next(1, 7);
    dobas72 = rnd.Next(1, 7);
    dobas73 = rnd.Next(1, 7);
    Console.WriteLine($"{dobas71}; {dobas72}; {dobas73}");
    i7++;
} while (dobas71 == dobas72 || dobas72 == dobas73 || dobas71 == dobas73);

Console.WriteLine($"{i7}. dobásra lett mindhárom kockán különböző az érték.");
#endregion