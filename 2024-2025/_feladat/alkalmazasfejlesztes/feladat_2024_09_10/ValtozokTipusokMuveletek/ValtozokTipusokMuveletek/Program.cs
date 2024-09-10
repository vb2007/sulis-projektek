Console.WriteLine("Változótípusok és méreteik:\n");

Console.WriteLine("\nElőjeles:");
Console.WriteLine($"byte:\t{typeof(byte)}\t{sizeof(byte)}\t{byte.MinValue}\t{byte.MaxValue}");
Console.WriteLine($"short:\t{typeof(short)}\t{sizeof(short)}\t{short.MinValue}\t{short.MaxValue}");
Console.WriteLine($"int:\t{typeof(int)}\t{sizeof(int)}\t{int.MinValue}\t{int.MaxValue}");
Console.WriteLine($"long:\t{typeof(long)}\t{sizeof(long)}\t{long.MinValue}\t{long.MaxValue}");

Console.WriteLine("\nElőjel nélküli:");
Console.WriteLine($"sbyte:\t{typeof(sbyte)}\t{sizeof(sbyte)}\t{sbyte.MinValue}\t{sbyte.MaxValue}");
Console.WriteLine($"ushort:\t{typeof(ushort)}\t{sizeof(ushort)}\t{ushort.MinValue}\t{ushort.MaxValue}");
Console.WriteLine($"uint:\t{typeof(uint)}\t{sizeof(uint)}\t{uint.MinValue}\t{uint.MaxValue}");
Console.WriteLine($"ulong:\t{typeof(ulong)}\t{sizeof(ulong)}\t{ulong.MinValue}\t{ulong.MaxValue}");

Console.WriteLine("\nValós:");
Console.WriteLine($"float:\t{typeof(float)}\t{sizeof(float)}\t{float.MinValue}\t{float.MaxValue}");
Console.WriteLine($"double:\t{typeof(double)}\t{sizeof(double)}\t{double.MinValue}\t{double.MaxValue}");
Console.WriteLine($"decimal:\t{typeof(decimal)}\t{sizeof(decimal)}\t{decimal.MinValue}\t{decimal.MaxValue}");

Console.WriteLine("\nChar típus:");
Console.WriteLine($"char:\t{typeof(char)}\t{sizeof(char)}\t{char.MinValue}\t{char.MaxValue}");

Console.WriteLine("\nString típus:");
Console.WriteLine($"string:\t{typeof(string)}");

Console.WriteLine("\nMűveletek:");

int x1 = 6, y1 = 4; x1 += y1;
Console.WriteLine($"x1: {x1}, y1: {y1}");

int x2 = 6, y2 = 4; x2 *= y2;
Console.WriteLine($"x2: {x2}, y2: {y2}");

int x3 = 6, y3 = 4; double z3 = x3 / y3;
Console.WriteLine($"z3: {z3}");

int x4 = 20, y4 = 6; int z4 = x4 % y4;
Console.WriteLine($"z4: {z4}");

int a5 = 3 * 6 + 2;
Console.WriteLine($"a5: {a5}");

int a6 = 3 + 6 * 2;
Console.WriteLine($"a6: {a6}");

int a7 = 2 + 3 + 4 * 5;
Console.WriteLine($"a7: {a7}");

int x8 = 6; int y8 = x8++;
Console.WriteLine($"x9: {x8}, y8: {y8}");

int x9 = 6; int y9 = ++x9;
Console.WriteLine($"x9: {x9}, y9: {y9}");

int x10 = 5; int y10 = --x10;
Console.WriteLine($"x10: {x10}, y10: {y10}");