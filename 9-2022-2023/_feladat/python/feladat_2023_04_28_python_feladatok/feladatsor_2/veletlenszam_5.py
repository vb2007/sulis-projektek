import random;

foldrenges = random.randint(1,12);
print(foldrenges);

if foldrenges == 1:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Mikrorengés");
elif foldrenges == 2:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Rendkívül gyenge");
elif foldrenges == 3:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Nagyon gyenge");
elif foldrenges == 4 or foldrenges == 5:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Gyenge");
elif foldrenges == 6 or foldrenges == 7:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Közepes");
elif foldrenges == 8:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Erős");
elif foldrenges == 9 or foldrenges == 10:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Igen erős");
elif foldrenges == 11:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Nagyon erős");
elif foldrenges == 12:
    print(f"Ez egy {foldrenges} erejű rengés. Hatása: Rendkívüli erejű rengés");