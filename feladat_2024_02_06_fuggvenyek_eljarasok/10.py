#függvény, amely a paraméterébe kapott szöveget fordított sorrendben kiírja

def forditottSorrend(szoveg):
    return szoveg[::-1]

szoveg = str(input("Adj meg szöveget: "))

print(f"A szöveg fordított sorrendben: \n{forditottSorrend(szoveg)}")