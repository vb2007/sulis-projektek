int x = 10;
int y = 23;

//Relációs operátorok
//Console.WriteLine($"x>y (nagyobb) {x > y}");
//Console.WriteLine($"x>=y (nagyobb vagy egyenlő) {x >= y}");
//Console.WriteLine($"x==y (egyenlő) {x == y}");
//Console.WriteLine($"x!=y (nem egyenlő) {x != y}");
//Console.WriteLine($"x<=y (kisebb vagy egyenlő) {x <= y}");
//Console.WriteLine($"x<y (kisebb) {x < y}");


#region Logikai operátorok
bool a = true;
bool b = false;
//Console.WriteLine($"a értéke: {a} tagadása: {!a}"); // ! - nem (tagadás)
//Console.WriteLine($"b értéke: {b} tagadása: {!b}");
#endregion


#region És && - akkor igaz, ha mindkét oldalán a kifejezés igaz
//Console.WriteLine($"a és a: {a && a}");
//Console.WriteLine($"a és b: {a && b}");
//Console.WriteLine($"b és a: {b && a}");
//Console.WriteLine($"b és b: {b && b}");
#endregion


#region Vagy || - akkor igaz, ha valamelyik oldalán a kifejezés igaz
//Console.WriteLine($"a vagy a: {a || a}");
//Console.WriteLine($"a vagy b: {a || b}");
//Console.WriteLine($"b vagy a: {b || a}");
//Console.WriteLine($"b vagy b: {b || b}");
#endregion


#region De Morgan-azonosságok
//!(a || b) == !a && !b
//!(a && b) == !a || !b
#endregion


#region Elágazások
Console.WriteLine($"Az x páros: {x % 2 == 0}");
Console.WriteLine($"Az y páros: {y % 2 == 0}");


if (x > 0)
{
    Console.WriteLine("Az x értéke pozitív");
}
else
{
    Console.WriteLine("Az x értéke nem pozitív");
}


if (x < 0)
{
    Console.WriteLine("Az x értéke negatív");
}
else if (x > 0)
{
    Console.WriteLine("Az x értéke pozitív");
}
else
{
    Console.WriteLine("Az x értéke 0");
}

//if (x > 0)
//{
//    if (x % 2 == 0)
//    {
//        Console.WriteLine("x 2-vel osztható pozitív szám");
//    }
//    else
//    {
//        Console.WriteLine("x 2-vel nem osztható pozitív szám");
//    }
//}
//else
//{
//    Console.WriteLine("x nem pozitív szám");
//}

#endregion