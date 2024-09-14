
Random r = new (); //véletlen szám generátor

#region Abszolútérték
//Console.Write("Kérem adjon meg egy számot: ");
//int szam = int.Parse(Console.ReadLine());
//int abszolut = Math.Abs(szam);
//Console.WriteLine("A szám abszolút értéke: " + abszolut);
#endregion

#region Hatványozás x^y
//Console.Write("Kérem adjon meg egy számot: ");
//int x = Convert.ToInt32(Console.ReadLine());
//Console.Write("Kérem adjon meg egy kitevőt: ");
//int y = int.Parse(Console.ReadLine());
//double eredmeny = Math.Pow(x, y);
//Console.WriteLine("A hatvány értéke: {0} {1} {2}", eredmeny,x,y);
#endregion

#region Gyökvonás
//Console.Write("Kérem adjon meg egy számot: ");
//int a = int.Parse(Console.ReadLine());
//Console.WriteLine($"A beolvasott szám gyöke: {Math.Sqrt(a).ToString("#0.#0")}");
#endregion

Console.WriteLine("PI értéke: " + Math.PI);


#region Egész véletlenszám generálás
int x1 = r.Next(); //nem negatív egész szám
int x2 = r.Next(10); //0..9 r.Next(n) 0..n-1 pozitív véletlenszámot generál
int x3 = r.Next(-50, 10); //-50..9  r.Next(ah,fh) ah..fh-1 véletlenszámot generál
Console.WriteLine($"Első véletlenszám: {x1}\nmásodik véletlenszám: {x2}\nharmadik véletlenszám: {x3}");
#endregion



#region Valós véletlenszám generálás
double y1 = r.NextDouble(); //0 és 1 közötti valós véletlenszámot generál
							//feladat: [5,12] közötti valós számot generálunk
double y2 = r.NextDouble() * (12 - 5) + 5;
//általános képlet [ah,fh] --> r.NextDouble()*(fh-ah)+ah
//r.NextDouble() --> [0,1] közötti
//r.NextDouble()*(fh-ah)  --> [0,fh-ah] közötti
//r.NextDouble()*(fh-ah)+ah --> [ah,fh] közötti
Console.WriteLine("Az első valós véletlenszám: {0}\na második valós véletlenszám: {1}", y1, y2);
#endregion