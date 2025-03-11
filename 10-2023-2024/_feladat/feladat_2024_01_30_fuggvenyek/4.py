def intervallumosszeg(a,b):
    if b < a:
        return "Az a értéknek nagyobbnak kell lennie."

    osszeg = 0    
    for i in range(a, b+1):
        osszeg += i
    
    return osszeg

a = int(input("Add meg a lista kezdő intervallumát: "))
b = int(input("Add meg a lista záró intervallumát: "))

print(intervallumosszeg(a,b))