string s = "citrom";
string s2 = "fa";
string s3 = "tigris";
string s4 = "almafa";

#region hossz
//Szöveg hossza: Length tulajdonsággal kérdezhető le
int hossz = s.Length;
Console.WriteLine("{0} szó hossza: {1}", s, hossz);
hossz = s2.Length;
Console.WriteLine($"{s2} szó hossza: {hossz}");
Console.WriteLine("{0} szó hossza: {1}", s3, s3.Length);
#endregion

#region indexelés
/* A szöveg karaktereit indexeléssel lehet elérni. A szöveg legelső karaktere a 0. indexen van.
 * Az index mindig azt mutatja, hogy a szöveg kezdetétől hány karaktert mozdultunk el.
 * Egy 6 karakter hosszú string-nél az indexek 0 és 5 közötti egész értéket vehetnek fel.
 * c i t r o m
 * 0 1 2 3 4 5
 */

Console.WriteLine($"{s} szó 0. karaktere: {s[0]}");
Console.WriteLine($"{s} szó 6. karaktere: {s[6]}"); //Hiba, a szón kívülre mutat az index
Console.WriteLine($"{s} szó -1. karaktere: {s[-1]}"); //Hiba, a szón kívülre mutat az index 

Console.WriteLine($"{s} szó karakterei:");
for (int i = 0; i < s.Length; i++)
{
   Console.WriteLine(s[i]);
}
Console.WriteLine($"{s3} szó karakterei visszafelé:");
for (int i = s3.Length - 1; i >= 0; i--)
{
   Console.WriteLine(s3[i]);
}

foreach (var item in s)
{
   Console.WriteLine(item);
}

Console.WriteLine($"{s} szó utolsó karaktere: {s[^1]}");
// Hibás hivatkozás pl.: s[^0], s[^-1]

Console.WriteLine($"{s3} szó első 3 karaktere: {s3[0..3]}");
Console.WriteLine($"{s} szó 2. és 3. karaktere: {s[1..3]}");
Console.WriteLine($"{s} szó az első 3 karakter nélkül: {s[3..]}");
Console.WriteLine($"{s3} szó utolsó 3 karakter nélkül: {s3[0..(s3.Length - 3)]}");
Console.WriteLine($"{s3} szó utolsó 3 karakter nélkül: {s3[0..^3]}");
Console.WriteLine($"{s3} szó utolsó 3 karakter nélkül: {s3[..^3]}");
string ss = s3[..];
Console.WriteLine(ss);
#endregion

#region pozíció keresés
/* Egy karakter vagy szöveg megkeresése a szövegben: IndexOf
 * Ha megtalálható a keresett rész a szövegben, akkor az első előfordulás indexét adja vissza, 
 * különben -1 –et.
 */

int poz = s.IndexOf('t');
Console.WriteLine($"{s} szóban a 't' karakter helye: {poz} ");
poz = s.IndexOf("it");
Console.WriteLine($"{s} szóban az \"it\" szöveg helye: {poz} ");
Console.WriteLine($"{s} szóban az 'A' karakter helye: {s.IndexOf('A')} ");
Console.WriteLine($"{s3} szóban az 'i' karakter első előfordulása: {s3.IndexOf('i')} ");
Console.WriteLine($"{s3} szóban az 'i' karakter utolsó előfordulása: {s3.LastIndexOf('i')} ");
poz = s4.IndexOf('a');
Console.WriteLine($"{s4} szóban a 2. 'a' karakter előfordulása: {s4.IndexOf('a', poz + 1)}");
#endregion

#region szövegrész másolása
/* Egy szöveg részének kimásolása: Substring
 * Ha csak 1 számot kap, akkor a kezdő indexet adtuk meg, és az indextől a szó végéig másol.
 * 2 szám esetén az első paraméter lesz a kezdő index, a második érték pedig azt adja meg, hogy hány karaktert kell kimásolni.
 * Figyelni kell arra, hogy tényleg legyen még annyi karakter a szóban, ahány karaktert ki akarunk másolni, 
 * különben futási hiba lép fel.
 */
s4 = s.Substring(3);
Console.WriteLine($"{s} szóból a 3. indextől kezdve a szó végéig való másolás eredménye: {s4}");
s4 = s.Substring(2, 3);
Console.WriteLine($"{s} szóból a 2. indextől kezdve 3 karakter másolásának eredménye: {s4}");
//s4 = s.Substring(2, 6); //Futás idejű hiba
//s4 = s.Substring(10); //Futás idejű hiba
#endregion

#region szövegrész törlés
/* Egy szöveg részének törlése: Remove
 * Nem az eredeti string-ben töröl, hanem a visszaadott értékben!
 * Ha az eredeti string-ben akarsz törölni, akkor másold vissza rá az értéket!
 * Ha csak 1 számot kap, akkor a kezdő indexet adtuk meg, és az indextől a szó végéig töröl. 
 * 2 szám esetén pedig az első paraméter lesz a kezdő index, a második érték pedig azt adja meg, 
 * hogy hány karaktert kell törölni.
 * Figyelni kell arra, hogy tényleg legyen még annyi karakter a szóban, ahány karaktert ki akarunk törölni, 
 * különben futási hiba lép fel.
 */

string s5 = s.Remove(3);
Console.WriteLine($"{s} szó végét töröljük a 3. indextől kezdve: {s5}");
s5 = s.Remove(2, 3);
Console.WriteLine($"{s} szóból törlünk a 2. indextől kezdve 3 karatert: {s5}");
s5 = s;
Console.WriteLine($"{s5} eredetileg");
s5 = s5.Remove(2, 3);
Console.WriteLine($"a felesleg törölve belőle: {s5}");
#endregion

#region szöveg beszúrása
/* Szöveg beszúrása: Insert
 * Az első paramétere az index, ahonnan kezdődve be szeretnénk szúrni a szöveget, 
 * a második paramétere pedig a beszúrandó szöveg.
 * Figyelni kell arra, hogy csak elérhető indexű helyre szúrhatunk be, vagy a szöveg végére!             * 
 */

string s6 = s.Insert(2, "ca");
Console.WriteLine($"{s} szóba a 2. indextől kezdve beszúrva a \"ca\" szó: {s6}");
s6 = s.Insert(s.Length, s2);
Console.WriteLine($"{s} szó végére beszúrva {s2} szó: {s6}");
s6 = s + s2; //Megegyezik az s6 = s.Insert(s.Length, s2); művelettel
Console.WriteLine($"{s} szó végére beszúrva {s2} szó: {s6}");
//s6 = s.Insert(10, "!!!"); //Futás idejű hiba
#endregion

#region szövegrész lecserélése
/* Szövegrész lecserélése: Replace
 * Az első paramétere az a szöveg, amit le szeretnénk cserélni, 
 * a második paramétere pedig az a szöveg, amire cserélni szeretnénk. 
 * Lehet karaktert karakterre, vagy szöveget szövegre cserélni. 
 * Minden előfordulást lecserél.
 */

string s7 = s3.Replace('i', 'a');
Console.WriteLine($"{s3} szóban az 'i' karakterek cseréje 'a' karakterre: {s7}");
s7 = s3.Replace("i", "iii");
Console.WriteLine($"{s3} szóban az \"i\" szövegrész cseréje \"iii\" szövegrészre: {s7}");
s7 = s3.Replace('a', 'i');
Console.WriteLine($"{s3} szóban az 'a' karakterek cseréje 'i' karakterre: {s7}");
s7 = "Alma a fa alatt";
Console.WriteLine($"\"{s7}\" szöveg szóközmentesítve: {s7.Replace(" ", "")}");
#endregion

#region nagybetűsítés, kisbetűsítés, karaktervizsgálat
/* Szöveg nagybetűsítése: ToUpper()              
 * Szöveg kisbetűsítése: ToLower()
 * Karakter nagybetűsítése: char.ToUpper()
 * Karakter kisbetűsítése: char.ToLower()
 * 
 * Szöveg egy karakterének megvizsgálása, hogy nagybetűs-e: IsUpper
 * Szöveg egy karakterének megvizsgálása, hogy kisbetűs-e: IsLower
 * Szöveg egy karakterének megvizsgálása, hogy szám-e: IsNumber vagy IsDigit
 * Szöveg egy karakterének megvizsgálása, hogy betű-e: IsLetter
 * Szöveg egy karakterének megvizsgálása, hogy whitespace-e: IsWhiteSpace
 * Szöveg egy karakterének megvizsgálása, hogy szám vagy szöveg-e: IsLetterOrDigit
 * Mindig egy feltétel részeként vizsgáljuk.
 */

string s8 = s.ToUpper();
Console.WriteLine($"{s} szó nagybetűsítve: {s8}");
string s9 = s8.ToLower();
Console.WriteLine($"{s8} szó kisbetűsítve: {s9}");
string s10 = "\t\n   " + 6 + " " + s + s2.ToUpper() + " " + s3 + "!!!\t\n";
Console.WriteLine($"Eredeti szöveg: {s10}");
for (int i = 0; i < s10.Length; i++)
{
   if (char.IsUpper(s10[i]))
   {
       Console.Write(char.ToLower(s10[i]));
   }
   else
   {
       Console.Write(char.ToUpper(s10[i]));
   }
}
Console.WriteLine();
for (int i = 0; i < s10.Length; i++)
{
   if (char.IsNumber(s10[i]))
   {
       Console.WriteLine($"{s10[i]}: szám");
   }
   else if (char.IsLetter(s10[i]))
   {
       Console.WriteLine($"{s10[i]}: betű");
   }
   else if (char.IsWhiteSpace(s10[i]))
   {
       Console.WriteLine($"{s10[i]}: whitespace");
   }
   else if (!char.IsLetterOrDigit(s10[i]))
   {
       Console.WriteLine($"{s10[i]}: speciális karakter");
   }
}

#endregion

#region String.Format
/* C: pénz
 * D: decimális
 * E: exponenciális
 * F: fixpontos
 * G: általános szám formátum
 * N: szám formátum, minden szám típuson alkalmazható
 * P: százalék
 * X: hexadecimális
 */

string sf = String.Format("2*5={0,6} 1/3={1:F2}", 2 * 5, 1.0 / 3);
Console.WriteLine(sf);
Console.WriteLine(String.Format("{0:C}", 6000));
Console.WriteLine(String.Format("{0:C0}", 6000));
Console.WriteLine(String.Format("{0:D6}", 6000));
Console.WriteLine(String.Format("{0:P}", 0.8));
Console.WriteLine(String.Format("{0:P0}", 0.8));
Console.WriteLine(String.Format("{0:X}", 254));
Console.WriteLine(String.Format("|{0,12}|{1,-12}|", s3, s));

int hatezer = 6000;
double egyharmad = 1.0 / 3;
Console.WriteLine($"Hatezer: {hatezer:N3}");
Console.WriteLine($"1/3: {egyharmad:N3}");
#endregion
