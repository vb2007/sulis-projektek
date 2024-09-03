rekeszek = int(input("Adja meg a rendelt rekeszek darabszámát (5-20): "))
almak = int(input("Adja meg a mai napon leszüretelt almák darabszámot (100-200): "))

if not (5 <= rekeszek <= 20) or not (100 <= almak <= 200): #tudom a feladat nem kérte, de na...
    print("A bemenet érvénytelen!")
else:
    maxRekeszek = almak // 12

    if maxRekeszek >= rekeszek:
        print("A rendelt mennyiség teljesíthető.")
    else:
        print(f"A rendelt mennyiség nem teljesíthető, max. {maxRekeszek} rekeszt lehet értékesíteni.")