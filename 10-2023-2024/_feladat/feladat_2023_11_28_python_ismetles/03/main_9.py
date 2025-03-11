#9. Feladat
ora = int(input("Add meg az órák számát: "))
perc = int(input("Add meg a percek számát: "))
madoperc = int(input("Add meg a másodpercek számát: "))

print("A napnak a ", ora*60*60 + perc*60, ". másodpercében járunk.")

ejfelelott = int(input("Éjfél óta eltelt idő másdpercben: "))

orak = ejfelelott // 3600
ejfelelott %= 3600
percek = ejfelelott // 60
masodpercek = ejfelelott % 60

if orak > 0:
    print(f"{orak}:{percek:02d}:{masodpercek:02d}")
elif percek > 0:
    print(f"{percek}:{masodpercek:02d}")
else:
    print(f"{masodpercek}")