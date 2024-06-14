szo1 = input("Első szó: ")
szo2 = input("Második szó: ")

if len(szo1) > len(szo2):
    print("Az első szó több karakterből áll.")
elif len(szo2) > len(szo1):
    print("A második szó több karakterből áll.")
else:
    print("A két szó karakterszáma megegyezik.")