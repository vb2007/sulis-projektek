# 1. beolvasás, kiírás hány elem van a listában

eloadok = []
with open ("eloado.txt", "r", encoding="utf-8") as file:
    for sor in file:
        eloadok.append(sor.strip())

print(f"A listában: {len(eloadok)} elem van.")

# 2. értékek kiírása betűrendben, egymás alá, csupa nagybetűvel

abcEloadok = eloadok
abcEloadok.sort(key=str.lower)

print(abcEloadok)

# 3. 