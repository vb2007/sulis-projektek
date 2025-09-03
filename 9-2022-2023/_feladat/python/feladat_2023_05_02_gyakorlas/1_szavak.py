szo_1 = str(input("Adj meg egy szót: "));
szo_2 = str(input("Adj meg még egy szót: "));

szo_1_hossz = len(szo_1);
szo_2_hossz = len(szo_2);

if szo_1_hossz > szo_2_hossz:
    print("Az első szó hosszabb.");
elif szo_2_hossz > szo_1_hossz:
    print("A második szó hosszabb.");
elif szo_1_hossz == szo_2_hossz:
    print("A két szó egyenlő hosszú.");
else:
    print("Az általad megadott értékek érvénytelenek.");