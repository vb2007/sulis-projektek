#-----------
#1. feladat

sugár = 1
suGár = 22
print(sugár, suGár)

#-----------
#2. feladat

#for = 2
#A Python alapszavai nem lehetnek változónevek, ha megpróbáljuk, mi történik?
#   Nem fog lefutni a kód, mert a "for" egy függvény és nem lehet változónév

#-----------
#3. feladat

#1adat, = 2
If = 2
#La Pos = 2
#ellen? = 2
#l!sta = 2
(alma) = 2
#try = 2
#Kö_rte = 2
#+adat = 2
#_print # = 2
#_, _ = 2
#Q, X% = 2

#Mind szabálytalan? Próbáljuk ki, adjunk nekik értéket!
#   Nem, a If = 2, a (alma) = 2 műdöhet

#-----------
#4. feladat

x = 42
print("Értéke:", x)
x = "almafa"
print("Értéke:", x)

#-----------
#5. feladat

#valami -= 3
valami =- 3
valami -= 3
print(valami)
#A print(valami) mit írna ki? Miért nem működik az első utasítás?
#   -6 -ot (a hibás értékvonás nélkül). Azért nem működött, mert nem lehet értéket kivonni egy olyan változóból, ami még nem létezik
#Mennyi lesz az eredmény, ha az utolsó utasítást többször kiadjuk?
#   Annyiszor -3 lesz kivonva az értékből, ahányszor ismételjük a sort.

#-----------
#6. feladat
szélesség = 8
magasság = hosszúság = szélesség + 2

print("A téglatest térfogata: ", szélesség * hosszúság * magasság)

#-----------
#7. feladat
alma,fa = 4,5
print(alma, fa)
#Nem jelez hibát! Mi a magyarázat erre?
#   Mert létrehoztunk egy alma és egy fa változót, és az egyiknek 4-es értéket, a másiknak meg 5-ös értéket adtunk

#-----------
#8. feladat
_=2
_ +=_
_ *=_
print(_)
#Vajon mit fog kiírni a print(_) parancs?
#   16-ot

#-----------
#9. feladat
mese = "Egyszer volt, hol nem volt"
#Egészítsük ki a jobb oldalt úgy, hogy kiíráskor minden szó új sorba kerüljön!
mese = "\nEgyszer\nvolt,\nhol\nnem\nvolt"

#-----------
#10. feladat
#Szeretnénk ezt a két sort kiíratni egyetlen print utasítással:
print("Egy sor.\nKét sor.")

#-----------
#11. feladat
árlista = 'Alma\t200 Ft\nSzilva\t650 Ft\nDió\t999 Ft'
print(árlista)

#-----------
#12. feladat
#Hogyan lehet megoldani azt, hogy egy adat kiírása után biztosan legyen két üres sor??
#   A print("")-be írunk két \n -t

#-----------
#13. feladat
#Egészítsük ki fenti utasítást úgy, hogy a neveket egymás alá írja ki egy üres sor kihagyásával!
print('Sándor\n', 'József\n', 'Benedek')

#-----------
#14. feladat
x = input('Mit ismételgessek? ')
print(x, x, x, x, x, x, sep='\n')
#Mi a sep módosításának hatása?
#   Az x-eket egy \n-el elszeparálja

#-----------
#15. feladat
kérdés = 'Mekkora az oldal hossza?'
hossz = input(kérdés)
#Próbáljuk ki, melyik ad hibaüzenetet!
#   mindegyik, mert string a beviteli adat típusa, azt pedg nem lehet int-hez hozzáadni
print(hossz + 8)
print(hossz - 8)
print(hossz / 8)