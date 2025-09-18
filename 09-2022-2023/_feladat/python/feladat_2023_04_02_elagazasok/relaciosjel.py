szam1 = input("Adj meg egy számot: ")
szam2 = input("Adj meg még egy számot: ")

if szam1 != szam2:
    if szam1 > szam2:
        print(szam1, ">", szam2)
    else:
        print(szam1, "<", szam2)
else:
    print(szam1, "=", szam2)