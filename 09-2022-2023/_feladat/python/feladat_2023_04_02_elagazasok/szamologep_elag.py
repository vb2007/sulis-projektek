szam1 = int(input("Adj meg egy egész számot: "));
szam2 = int(input("Adj meg még egy egész számot: "));
muvelet = str(input("Add meg az elvégzendő művelet jelét: "))

osszeg = szam1 + szam2;
kulonbseg = szam1 - szam2;
szorzat = szam1 * szam2;
hanyados = szam1 / szam2;
maradek = szam1 % szam2;

if(muvelet == "+" or muvelet == "-" or muvelet == "*" or muvelet == "/"):
    print("A beírt szám...");
    if(muvelet == "+"):
        print("Összege: ", osszeg);
    elif (muvelet == "-"):
        print("Különbsége: ", kulonbseg);
    elif (muvelet == "*"):
        print("Szorzata: ", szorzat);
    elif (muvelet == "/"):
        print("Hányadosa: ", hanyados);
        print("Maradéka: ", maradek);
else:
    print("Az általad megadott művelet jele nem érvényes.");
    print("Kérlek használd az alábbi műveletek egyikét: + , - , * , /");