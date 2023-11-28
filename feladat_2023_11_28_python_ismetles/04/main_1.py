#1. Feladat
szam1 = int(input("Adj meg egy számot: "))
szam2 = int(input("Mégegyet: "))

if(szam1 == szam2):
    print(f"{szam1} = {szam2}")
elif(szam1 > szam2):
    print(f"{szam1} > {szam2}")
elif(szam1 < szam2):
    print(f"{szam1} < {szam2}")