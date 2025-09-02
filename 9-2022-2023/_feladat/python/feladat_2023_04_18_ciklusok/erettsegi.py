evszam = int("1222")
tipp = int("0")
talalat = int("0")

while evszam != tipp:
    tipp = int(input("Add meg az Aranybulla kiadásának évét: "))
    talalat = talalat + 1
    if tipp > evszam:
        print("Ez korábban történt.")
    elif tipp < evszam:
        print("Ez később történt.")
    else:
        print("Az évszám pontos.")
if talalat <= 2:
    print("Ügyes voltál!")
#else:
#    print("Hülye vagy.")