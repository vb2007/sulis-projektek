#1. példa
#csomagok.txt fájl sorai egész számokat tartalmaznak
#ha műveletet szeretnénk későbbiekben végezni a számokkal, akkor a listába már szám típussá konvertálva tegyük bele

#fájlbeolvasás soronként

lista=[]
f=open("csomagok.txt")
sor=f.readline().strip()

while sor!="":
    lista.append(int(sor))
    sor=f.readline().strip()
f.close()

print(lista) #kiírja a listát, amely a fájl sorait tartalmazza

#2. példa
# fájlbeolvasás kontextusmenedzserrel- előnye, hogy a kontextusmenedzser automatikusan lezárja a fájlt
# ugyanazt a listát kapjuk, mint az előző példában

""" Megjegyzés: A kontextus menedzser egy olyan eszköz, amely automatikusan gondoskodik arról, hogy a fájlokat megfelelően megnyissuk és bezárjuk, még akkor is, ha hiba lép fel a kód végrehajtása közben. Ezáltal elkerülhetővé válik a fájlok kézi bezárása, és biztosítható, hogy erőforrásaink helyesen kezeljük. """
lista2 = []
with open('csomagok.txt') as forrásfájl:
    for sor in forrásfájl:
        lista2.append( int(sor.strip()) )



#Érdekesség: if használata print utasításban
print(lista)
print(lista2)
print('Megegyezik a két lista' if lista == lista2 else 'A két lista nem egyforma.')
print(f'A két lista {"" if lista == lista2 else "nem "}egyforma.')


