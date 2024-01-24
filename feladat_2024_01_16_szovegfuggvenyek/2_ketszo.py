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
if szo2[-1] == szo2[-1]:
    print("Az első szó vége a másik szó utolsó betűjével kezdődik.")