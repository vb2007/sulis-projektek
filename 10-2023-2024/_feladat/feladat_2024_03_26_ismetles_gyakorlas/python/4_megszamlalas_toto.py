nyertes = "1X2X2X11XX22XX"
tippek = "112XXX112X12XX"

osszeg = 0
for i in range(len(tippek)):
    if nyertes[i] == tippek[i]:
        osszeg += 2
    else:
        osszeg -= 1

print(f"A totó {osszeg} pontos.")