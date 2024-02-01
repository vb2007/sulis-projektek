def pozitiv(a,b,c):
    if (a >= 0) and (b >= 0) and (c >= 0):
        return True
    else:
        return False

a = int(input("Adj meg egy számot: "))
b = int(input("Adj meg mégegyet: "))
c = int(input("Adj meg mégegyet: "))

print(pozitiv(a,b,c))