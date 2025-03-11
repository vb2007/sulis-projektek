#függvény, ami a megadott számot kiírja kettes számrendszerben

def kettesSzamrendszer(a):
    return bin(a)[2:]

a = int(input("Adj meg egy számot: "))

print(f"A szám kettes számrendszerben: {kettesSzamrendszer(a)}")