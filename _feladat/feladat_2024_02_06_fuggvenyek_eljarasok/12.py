#függvény, mely megállapítja, hogy a keresett szövegben hányszor szerepel az "a" karakter-

def aKereses(szoveg):
    count = 0
    for betu in szoveg:
        if "a" == betu:
            count += 1
    
    return count

szoveg = str(input("Adj meg egy szöveget: "))

print(f"A megadott szövegben {aKereses(szoveg)} alkalommal szerepel az \"a\" karakter.")

#feladat 2. része
#---------
#függvény ugyan azzal a névvel, ami megkeresi a megadott szövegben a megadott karaktert
#---------

def aKereses(szoveg, betu):
    count = 0
    for betu in szoveg:
        if betu == szoveg:
            count += 1

    return count

szoveg = str(input("Adj meg egy szöveget: "))
betu = str(input("Adj meg egy karaktert: "))

print(f"A megadott szövegben {aKereses(szoveg)} alkalommal szerepel a(z) \"{betu}\" karakter.")