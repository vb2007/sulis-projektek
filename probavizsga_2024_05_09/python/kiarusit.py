def Akcios_ar(eredeti_ar, learazas):
    ar = eredeti_ar * learazas / 100
    akcios_ar = eredeti_ar - ar

    return round(akcios_ar)

print("Akciós ár kiszámítása")
for i in range(5):
    eredeti_ar = int(input("Ár: "))
    learazas = int(input("Százalék: "))

    if Akcios_ar(eredeti_ar, learazas) < 5000:
        print(f"Az akciós ár: {Akcios_ar(eredeti_ar, learazas)} Ft. Extra jó ajánlat.")
    else:
        print(f"Az akciós ár: {Akcios_ar(eredeti_ar, learazas)} Ft.")