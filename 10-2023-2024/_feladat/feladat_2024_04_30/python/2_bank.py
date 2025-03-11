def betetSzamitas(betet, futamido):
    if futamido > 12:
        kamat = betet * 0.12
    else:
        kamat = betet * 0.05

    kamat = format(kamat, ".2f")
    #vagy round(kamat, 2), de akkor csak egy nulla jelenik meg.
    return kamat

for i in range(4):
    betet = int(input("Adja meg a betenni kívánt összeget: "))
    futamido = int(input("Adja meg betét futamidejét (hónapban): "))
    print(f"A betett összeg után {betetSzamitas(betet, futamido)} Ft betéti kamat jár.")