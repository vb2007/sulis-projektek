# 1. beolvasás, kiírás hány elem van a listában

eloadok = []
with open ("eloado.txt", "r", encoding="utf-8") as file:
    for sor in file:
        eloadok.append(sor.strip())

print(f"A listában: {len(eloadok)} elem van.")

# 2. értékek kiírása betűrendben, egymás alá, csupa nagybetűvel

abcSorrend =  set(eloadok)

for szo in sorted(abcSorrend):
    print(szo.upper())

# 3. kérj be egy nevet, nézd meg, hogy benne van-e a listában

keresettNev = input("Add meg egy előadó nevét: ")
keresettNev = keresettNev.lower()

talalt = False
for i in eloadok:
    if i.lower() == keresettNev:
        talalt = True
        break

if talalt:
    print("Benne van a listában.")
else:
    print("Nincs benne a listában.")

# 4. kérje be a felhasználótól hanyadik előadóra kíváncsi, majd írja ki a nevét, és hogy az hány karakterből áll

keresettNev = int(input(f"Hanyadik előadóra vagy kíváncsi (1. - {len(eloadok)}.): ")) - 1

if keresettNev > len(eloadok) or keresettNev < 0:
    print("Érvénytelen érték")
else:
    print(f"Az előadó neve: {eloadok[keresettNev]}")
    print(f"És ez {len(eloadok[keresettNev])} karakterből áll.")

# 5. függvény, amely meghatározza, hogy S, T, vagy R-re végződik-e a megadott név

def STR(nev):
    if nev[-1] == "s" or nev[-1] == "t" or nev[-1] == "r":
        return True
    else:
        return False

nev = input("Adj meg egy nevet: ")
nev = nev.lower()
STR(nev)

if STR(nev):
    print(f"A megadott név S-re, T-re, vagy R-re végződik.")
else: 
    print(f"A megadott név nem S-re, T-re, vagy R-re végződik.")

# 6. hány olyan név van, ami STR-re végződik

count = 0
for i in eloadok:
    if STR(i):
        count += 1
        print(i)

print(f"{count} név végződik S-re, T-re, vagy R-re.")

# 7. külön listába gyűjti az STR-re végződő neveket, majd kiírja őket egymás mellé, vesszővel elválasztva

strEloadok = []
for i in eloadok:
    if STR(i):
        strEloadok.append(i)

print(strEloadok)

# 8. számolja ki a nevek átlag hosszúságát és írja ki 2 tizedes jegy hosszúsággal
