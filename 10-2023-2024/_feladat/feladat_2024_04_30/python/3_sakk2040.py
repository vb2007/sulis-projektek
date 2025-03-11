eredmenyek = []
with open("eredmenyek.txt", "r", encoding="utf-8") as f:
    for i in f:
        #i = i.strip()
        eredmenyek.append(i.strip())

feherNyeresek = 0
for i in eredmenyek:
    if i == "FH":
        feherNyeresek += 1

feketeNyeresek = 0
for i in eredmenyek:
    if i == "FK":
        feketeNyeresek += 1

dontetlenek = 0
for i in eredmenyek:
    if i == "XX":
        dontetlenek += 1


with open("pontozotabla.txt", "w", encoding="utf-8") as f:
    f.write("A 2040-es sakkolimpián a következő eredmények születtek:\n")
    f.write(f"Az olimpián összesen {len(eredmenyek)} partit játszottak a versenyzők egymással.\n")
    f.write("Ezek lebontása a következő:\n")
    f.write(f"Fehér színben játszva összesen {feherNyeresek} partit nyertek.\n")
    f.write(f"Fekete színben játszva összesen {feketeNyeresek} partit nyertek.\n")
    f.write(f"Döntetlent pedig összesen {dontetlenek} esetben játszottak.")

    print("Az állományba történt kiíratás megtörtént.")
