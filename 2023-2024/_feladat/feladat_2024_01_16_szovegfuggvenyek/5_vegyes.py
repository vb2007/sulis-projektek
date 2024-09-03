mondat = str(input("Adj meg egy mondatot: "))

#hány karakterből áll a mondat
print(f"{len(mondat)} karakterből áll a mondat.")

#van-e felkiáltójel, pont, vagy kérdőjel a mondat végén
if mondat.endswith('?'):
    print("Kérdőjele van a mondat végén.")
elif mondat.endswith('.'):
    print("Pont van a mondat végén.")
elif mondat.endswith('!'):
    print("Felkiáltójel van a mondat végén.")
else:
    print("Nincs mondatvégi írásjel a mondat végén.")

#mondat minden második karaktere összefűzve
masodik = []
for i in range(len(mondat))[::2]:
    masodik.append(mondat[i])
print(''.join(map(str, masodik)))

#mondat kiírása visszafele
print(mondat[::-1])

#bekér egy szót és kiírja szerepel-e benne (és ha igen hányszor)
szo = str(input("Adj meg egy szót: "))
if szo in mondat:
    count = mondat.count(szo)
    print(f"A(z) '{szo}' szó {count} alkalommal van benne a mondatban.")