def oszthato(szam):
    if (szam % 2 == 0) and (szam % 3 == 0):
        return True
    else:
        return False

szam = int(input("Adj meg egy számot: "))

print(oszthato(szam))