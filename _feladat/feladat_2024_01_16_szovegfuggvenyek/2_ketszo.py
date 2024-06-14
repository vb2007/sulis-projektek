szo1 = str(input("Adj meg egy szót: "))
szo2 = str(input("Adj meg mégegyet: "))

#megvizsgálja valamelyik tartralmazza-e a másikat
if szo1 == szo2:
    print(f"{szo1} tartalmazza {szo2}-t.")

#vizsgáld meg, hogy az első szó
#...eleje a másik szóval kezdődik-e?
if szo1[0] == szo2[0]:
    print("Az első szó eleje a másik szó első betűjével kezdődik.")
#...vége a másik szóval kezdődik-e
if szo1[-1] == szo2[-1]:
    print("Az első szó vége a másik szó utolsó betűjével kezdődik.")

if szo1 in szo2:
    print(f"A(z) {szo2.find(szo1) + 1}. karaktertől található meg az első szó a második szóban.")
else:
    print("Az első szó nincs benne a második szóban.")

#írj ki az első szó minden 2. karakterét
print(szo1[1::2])

#írd ki véletlenszerűen az első szó egyik betűjét
from random import choice
random_letter = choice(szo1)
print(random_letter)