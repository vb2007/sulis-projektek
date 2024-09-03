jelszo = "titok"
talalt = False

while (talalt == False):
    talalat = str(input("Mi a jelszó? "))
    if (talalat != jelszo):
        print("Nem.")
    else:
        print("Óóó, de ügyes vagy!")
        talalt = True
        