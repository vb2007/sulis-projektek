#függvény, mely paraméterként megkap egy ÉV:HÓNAP:NAP:ÓRA:PERC stringet, majd abból kiszámolja, hogy az adott év hány százaléka telt el
from datetime import datetime

def stringSzetvalasztas(ido):
    ev = int(ido.split(":")[0])
    honap = int(ido.split(":")[1])
    nap = int(ido.split(":")[2])
    ora = int(ido.split(":")[3])
    perc = int(ido.split(":")[4])

    return ev, honap, nap, ora, perc

def elteltEv(ev, honap, nap, ora, perc):
    datum = datetime(ev, honap, nap, ora, perc)
    evKezdete = datetime(ev, 1, 1, 0, 0)
    evVege = datetime(ev, 12, 31, 23, 59)

    if datum < evKezdete or datum > evVege:
        return "Helytelen dátum!"
    
    #szökőévet csekkol
    if datetime.is_leap(ev) and honap < 3:
        osszMasodpercek = 366 * 24 * 60 * 60
    else:
        osszMasodpercek = 365 * 24 * 60 * 60
    
    eltelt = (datum - evKezdete).osszMasodpercek()

    return eltelt / osszMasodpercek * 100

ido = input("Adj meg egy dátumot ÉV:HÓNAP:NAP:ÓRA:PERC formátumban: ")

ev, honap, nap, ora, perc = stringSzetvalasztas(ido)

if elteltEv(ev, honap, nap, ora, perc) == "Helytelen dátum!":
    print("Helytelen dátum!")
else:
    print(f"Az év {elteltEv()}%-a telt el.")