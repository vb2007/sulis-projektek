#3.1
#program, melyben van egy integer, srting és boolean változó
dict = {
    "integer": 1,
    "string": "string",
    "boolean": True
}

print(f"A jelenlegi szótár:\n{dict}")

#a felhasználónak legyen lehetősége hozzáadni egy adatot
positives = ["igen", "yes", "y", "i"]

#3.2: a felhasználó csillaggal jelezze, ha már nem akar több adatot hozzáadni
while True:
    valtoztatas = input("Szerenél hozzáadni egy adatot? (igen/*(=nem)): ")
    if valtoztatas in positives:
        valtoztatasErtek = input("Melyik adatot szeretnéd hozzáadni? (int/str/bool): ")
        match valtoztatasErtek:
            case "int":
                int_ = input("Add meg az integer adat nevét: ")
                dict[int_] = int(input("Add meg az integer adat értékét: "))
            case "str":
                str_ = input("Add meg az string adat nevét: ")
                dict[str_] = input("Add meg a string adat értékét: ")
            case "bool":
                bool_ = input("Add meg az boolean adat nevét: ")
                dict[bool_] = input("Add meg a boolean adat értékét: ")
            case _:
                print("Nem megfelelő érték!")
        # a program írja ki a szótár frissített értékét
        print(f"Az új szótár:\n{dict}")
    else:
        break