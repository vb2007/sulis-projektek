letszam = int(input("Add meg az osztálylétszámot: "))
atlagok = []

for i in range(letszam):
    atlag = float(input("Add meg a félévi átlagokat: "))
    atlagok.append(atlag)

for i in range(letszam):
    jegy = round(atlagok[i])
    print(f"A(z) {i+1}. tanuló év végi jegye: {jegy}")