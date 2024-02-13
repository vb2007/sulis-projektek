#függvény, amely megmondja az éjfél óta eltelt percek alapján, hogy délelőtt, vagy délután van

def delelottDelutan(perc):
    ora = perc // 60

    if ora >= 12: #feltéve, hogy 12 óra már délután
        napszak = "délután"
    else:
        napszak = "délelőtt"
    
    ora = (ora % 12) + 1

    return napszak

perc = int(input("Add meg az éjfél óta eltelt percek számát: "))

print(f"Jelenleg {delelottDelutan(perc)} van.")