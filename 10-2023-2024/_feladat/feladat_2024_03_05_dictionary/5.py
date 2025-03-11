#lista, 8 diák adataival, ahol minden diák egy szótár, és nevük, életkoruk és évfolyamuk van
from random import randint, choice

vezeteknevek = ["Kiss", "Horváth", "Szabó", "Pethő", "Szalai", "Nagy"]
keresztnevek = ["Petra", "Ádám", "Levente", "Zoé", " Hanna" ]
telepulesek = ["Sopron", "Fertőszentmiklós", "Harka", "Kópháza", "Fertőd", "Újkér" ]
utcak = ["Fő", "Kossuth", "Győri", "Petőfi", "Vadvirág", "Iskola"]
osztalyok = ["A", "B", "C", "D"]

diakok = []

for i in range(8):
    diakok.append({
        "nev": f"{choice(vezeteknevek)} {choice(keresztnevek)}",
        "eletkor": randint(14,19),
        "evfolyam": randint(9,12),
        "osztaly" : choice(osztalyok),
        "cim" : {
            "telepules": choice(telepulesek),
            "utca": choice(utcak),
            "hazszam" : randint(1,50)
        }
    })

for i in diakok:
    print(f"Név: {i['nev']}")
    print(f"Életkor: {i['eletkor']}")
    print(f"Évfolyam: {i['evfolyam']}")
    print(f"Osztály: {i['osztaly']}")
    print(f"Lakcím:")
    print(f"  Település: {i['cim']['telepules']}")
    print(f"  Utca: {i['cim']['utca']}")
    print(f"  Házszám: {i['cim']['hazszam']}")