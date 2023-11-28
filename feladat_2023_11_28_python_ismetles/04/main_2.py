#2. Feladat
szam_1 = int(input("Adj meg egy számot: "))
szam_2 = int(input("Mégegyet: "))
muvelet = str(input("Add meg az elvégzendő műveletet (+ - * /)"))

if(muvelet == "+"):
    print("Összegük: ", szam_1, " + ", szam_2, " = ", szam_1 + szam_2)
elif(muvelet == "-"):
    print("Különbségük: ", szam_1, " - ", szam_2,  " = ", szam_1 - szam_2)
elif(muvelet == "*"):
    print("Szorzatuk: ", szam_1, " * ", szam_2, " = ", szam_1 * szam_2)
elif(muvelet == "/"):
    print("Hányadosuk maradékkal: ", round(szam_1 / szam_2, 2), "Maradék: ", szam_1 % szam_2)
else:
    print("Nem érvényes művelet.")