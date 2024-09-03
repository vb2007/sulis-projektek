i_use = str(input("Adj meg egy szöveget/szavat: ").lower)
arch = str(input("Adj meg egy szöveget/szavat: ").lower)
btw = str(input("Adj meg egy szöveget/szavat: ").lower)

#benne van-e a második szóban az első szó
if arch in i_use:
    i_use = i_use.replace(arch, btw)
    print(f"Az első szövegben/szóban lévő második szó ({arch}) cseréje történt meg a harmadik ({btw}) szóra.")
    print(f"Végeredmény {i_use}")
else:
    print(f"A második ({arch}) szó/szöveg nem található meg az első ({i_use}) szóban/szövegben.")

    
#benne van-e a harmadik szóban az első szó
if btw in i_use:
    i_use = i_use.replace(btw, arch)
    print(f"Az első szövegben/szóban lévő harmadik szó ({btw}) cseréje történt meg a második ({arch}) szóra.")
    print(f"Végeredmény {i_use}")
else:
    print(f"A harmadik ({btw}) szó/szöveg nem található meg az első ({i_use}) szóban/szövegben.")

