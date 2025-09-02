nev = str(input("Adj meg egy nevet: "));
if len(nev) > 0:
    utolsoKarakter = nev[len(nev) - 1];
    print(f"Az utolsó karakter: {utolsoKarakter}");
else:
    print("A változó üres, kérlek próbáld újra.");