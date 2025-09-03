szo = str(input("Adj meg egy szót: "))

#a) Páros karakterek
paros = szo[1::2]
paros_ciklus = 0
print("Páros karakterek: ", paros)

#a) Páratlan karakterek
paratlan = szo[0::2]
paratlan_ciklus = 0
print("Páratlan karakterek: ", paratlan)

#b) Kódolás

kevert_szo = ""

for i in range(1, len(szo)+1):
    if i % 2 == 0:
        kevert_szo = kevert_szo + paratlan[paratlan_ciklus]
        paratlan_ciklus += 1
    else:
        print(paros_ciklus)
        kevert_szo = kevert_szo + paros[paros_ciklus]
        paros_ciklus += 1
        
print("Kevert szo: ", kevert_szo)

#b) Dekódoölás

for i in range(len(kevert_szo)):
    if i % 2 != 0:
        kevert_szo = kevert_szo + paros[paros_ciklus]
        print(str(kevert_szo))