from ast import While


jelszo = str("titok")
talalat = str("")

while talalat != jelszo:
    talalat = str(input("Add meg a jelszót: "))
    if talalat != jelszo:
        print("A jelszó helytelen.")
    else:
        print("A jelszó helyes.")