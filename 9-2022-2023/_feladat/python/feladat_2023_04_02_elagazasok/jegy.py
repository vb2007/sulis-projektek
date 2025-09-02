mpont = int(input("Add meg az elérhető pontot: "));
pont = int(input("Add meg az elért pontot: "));

szazalek = int((pont / mpont) * 100);
#print(szazalek);
if szazalek >= 85:
    print("Jegy: 5");
elif szazalek < 85 and szazalek >= 70:
    print("Jegy: 4");
elif szazalek < 70 and szazalek >= 50:
    print("Jegy: 3");
elif szazalek < 50 and szazalek >= 35:
    print("Jegy: 2");
else:
    print("Jegy: 1");