szazalek = int(input("Hány százalékos lett a dolgozat? (0-100): "))

pontszam = round(szazalek / 100 * 80, 2)
print(f"A tanló {pontszam} pontot ért el.")

if szazalek < 40:
    erdemjegy = "Elégtelen"
elif szazalek < 55:
    erdemjegy = "Elégséges"
elif szazalek < 70:
    erdemjegy = "Közepes"
elif szazalek < 80:
    erdemjegy = "Jó"
else:
    erdemjegy = "Jeles"

print(f"A tanuló az alábbi érdemjegyet kapja: {erdemjegy}")