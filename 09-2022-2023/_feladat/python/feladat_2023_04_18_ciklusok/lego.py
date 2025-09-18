elem = int(input("Add meg hány Lego elem van a adobozban: "))
magassag = 0 #össz magasság
aktMagassag = 2 #akt. magasság
i = 1

while magassag <= elem and elem > 2:
    print(i, "-", aktMagassag)
    if i == 1:
        aktMagassag = 5
    else:
        aktMagassag =  aktMagassag + 3
    magassag = magassag + aktMagassag
    i = i + 1
