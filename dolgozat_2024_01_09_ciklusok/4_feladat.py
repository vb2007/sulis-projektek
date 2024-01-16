while True:
    osztalyzat = int(input("Milyen jegyet kaptál ma? "))
    if osztalyzat == 1:
        print("Nagyon sajnálom.")
        break
    elif osztalyzat == 2:
        print("Sajnálom.")
        break
    elif osztalyzat == 3:
        print("Átlagos.")
        break
    elif osztalyzat == 4:
        print("Jó.")
        break
    elif osztalyzat == 5:
        print("Kiváló.")
        break
    else:
        print("Hibás adat.")