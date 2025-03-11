kulcsok = input("Add meg a kulcsokat: ")
valaszok = input("Add meg a válaszokat: ")

pontszam = 0
for i in range(len(kulcsok)):
    if valaszok[i] == kulcsok[i]:
        pontszam += 2
    elif valaszok[i] == " ":
        pontszam += 0
    else:
        pontszam -= 1

if pontszam < 0:
    pontszam = 0

print(f"{pontszam} pontot ért el!")