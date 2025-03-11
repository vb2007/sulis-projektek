autok = [
    # rendszám, sebesség
    ['ABCD-12', 64],
    ['DBBA-12', 45],
    ['DDCD-72', 57],
    ['ABCD-12', 50],
    ['ABCD-12', 60]
    ]

print("Mekkora volt az első autó sebessége?")
print(autok[0][1])
print("\n")

print("Mi az utolsó autó rendszáma?")
print(autok[-1][0])
print("\n")

print("Hány autó adatait rögzítettük?")
print(len(autok))
print("\n")

print("Írassuk ki az autók sebességeit az áthaladás sorrendjében!")
for auto in autok:
    print(auto[-1])
print("\n")

print("Írjuk ki azoknak az autóknak a rendszámát, amelyek 50-nél gyorsabban mentek!")
for auto in autok:
    if auto[1] > 50:
        print(auto[0])
print("\n")

print("A rendszámok nevű listába gyűjtsük ki az autók rendszámait!")
rendszamok = []
for auto in autok:
    rendszamok.append(auto[0])
#print(rendszamok)
print("\n")