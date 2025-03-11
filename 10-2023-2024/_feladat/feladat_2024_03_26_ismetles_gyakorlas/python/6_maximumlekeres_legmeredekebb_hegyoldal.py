magassagok = [411, 411, 414, 410, 412, 414, 414, 417, 423, 423, 422, 427, 428, 432, 433, 428, 424]

#1. maximum
maximum = magassagok[0]
maximumIndex = 0
for i, magassag in enumerate(magassagok):
    if magassag > maximum:
        maximum = magassag
        maximumIndex = i

indulasOta = maximumIndex * 20

print(f"Az indulás óta {indulasOta} méter távolságra volt a legmagasabb pont, ami {maximum} méter.")

#2. minimum
minimum = magassagok[0]
minimumIndex = 0
for i, magassag in enumerate(magassagok):
    if magassag < minimum:
        minimum = magassag
        minimumIndex = i

indulasOta = minimumIndex * 20

print(f"Az indulás óta {indulasOta} méter távolságra volt a legalacsonyabb pont, ami {minimum} méter.")