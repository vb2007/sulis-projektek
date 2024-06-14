def Belepes(becenev):
    becenev = becenev.lower()
    if "marci" in becenev or "icram" in becenev:
        return False
    else:
        return True

jatekosok = 0
while jatekosok < 5:
    jatekos = input(f"{jatekosok + 1}. játékos: ")
    if Belepes(jatekos):
        print(f"Szia, {jatekos}!")
        jatekosok += 1
    else:
        print("Bocs, Marci!")