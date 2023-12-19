szamok = []
szam = 0
for i in range(10):
    szamok.append(szam)
    szam += 1

for i in szamok:
    print(i, end=",")
print("\n")

for i in szamok:
    print(i, end="\n")
print("\n")

rev_szamok = list(reversed(szamok))
# print(rev_szamok)
for i in rev_szamok:
    print(i, end="\n")

print(szamok[0::2])