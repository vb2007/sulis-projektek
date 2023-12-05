#3. Feladat
max_pontszam = int(input("Add meg a maximális elérhető pontszámot: "))

jeles = round(max_pontszam * 0.85)
jo = round(max_pontszam * 0.70)
kozepes = round(max_pontszam * 0.50)
elegseges = round(max_pontszam * 0.35)

elert_pontszam = int(input("Add meg az elért pontszámot: "))

print("Érdemjegy: ")
if elert_pontszam >= jeles:
    print("Jeles")
elif elert_pontszam >= jo:
    print("Jó")
elif elert_pontszam >= kozepes:
    print("Közepes")
elif elert_pontszam >= elegseges:
    print("Elégséges")
else:
    print("Elégtelen")

#print(jeles, jo, kozepes, elegseges)