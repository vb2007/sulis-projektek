#függvény, amely kiírja az éjfél óta eltelt időt óra:perc:másodperc formátumban

def ejfelOta(masodperc):
    orak = masodperc // 3600
    hatralevoMasodpercek = masodperc % 3600
    percek = hatralevoMasodpercek // 60
    masodpercek = hatralevoMasodpercek % 60

    return f"{orak:02d}:{percek:02d}:{masodpercek:02d}"

masodperc = int(input("Add meg az éjfél óta eltelt másodperceket: "))

print(f"Éjfél óta ennyi idő telt el: {ejfelOta(masodperc)}")