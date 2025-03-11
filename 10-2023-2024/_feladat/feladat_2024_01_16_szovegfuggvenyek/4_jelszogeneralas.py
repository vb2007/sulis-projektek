fullname = str(input("Add meg a teljes neved (<vezetéknév> <keresztnév>): "))
favanimal = str(input("Add meg a kedvenc állatod: "))
dateofbirth = str(input("Add meg a születésed évét: "))

names = fullname.split(" ")
lastname = names[0]
firstname = names[-1]

#vezetéknév utolsó 3 karakterének használata
lastname2 = lastname[-3:]

#keresztnévből minden páratlan karakter jobbról egybefűzve
firstname2 = ""
for i in range(len(firstname) -1, -1, -2):
    firstname2 += firstname[i]

#véletlenszám generálás 50 és 99 között
import random
randomnumber = random.randint(50, 99)

#2 középső karakter kiszedése
favanimal = favanimal[:len(favanimal)//2] + favanimal[(len(favanimal)//2)+2:]
favanimal2 = favanimal.upper()

#születési évből első 2 karakter kiírása
dateofbirth2 = dateofbirth[:2]

print(lastname2, firstname2, favanimal2, dateofbirth2, sep="")