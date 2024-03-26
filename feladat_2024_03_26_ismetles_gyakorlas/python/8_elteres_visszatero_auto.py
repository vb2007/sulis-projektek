rendszamok = ['BCDE-23', 'BCDD-44', 'BCDE-24', 'BCDE-12', 'BCDD-32', 'BCDE-24', 'BCDE-26', 'BCDD-24', 'BCDD-46']

latott = []
visszatert = []
for i in rendszamok:
    if i in latott:
        visszatert.append(i)
    else:
        latott.append(i)

print(f"Az alábbi auutók tértek vissza: {visszatert}")