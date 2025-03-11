ev = 1222
talalt = False
count = 0

while (talalt != True and count < 5):
    tipp = int(input("Melyik évben is adták ki az Aranybullát?"))
    if(tipp == ev):
        print("Ez a jó válasz!")
        talalt = True
    elif(tipp > ev):
        print("Nem volt az olyan régen!")
    elif(tipp < ev):
        print("Régebben történt!")
    count += 1

if(count >= 5):
    print(f"A helyes válasz {ev}...")
    exit

if(count < 3):
    print("Ügyes vagy!")