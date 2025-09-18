#Ezt még nem sikerült befejezni

max_pont = int(65);
elert_pont = int(input("Add meg az elért pontszámot: "));

szazalek = int((elert_pont / max_pont) * 100);

if szazalek >= 85:
    print(f"{szazalek} százalék. Jeles.");
if szazalek <= 85 and szazalek >= 70:
    print(f"{szazalek} százalék. Jó.");
if szazalek <= 70 and szazalek <= 69:
    print(f"{szazalek} százalék. Közepes.");
if szazalek <= 69 and szazalek <= 55:
    print(f"{szazalek} százalék. Elégséges.");
if szazalek <= 55 and szazalek <= 70:
    print(f"{szazalek} százalék. Jeles.");