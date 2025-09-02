from __future__ import print_function

ho = int(input("Add meg egy hónap számát: "))

if ho >= 0 and ho <= 3:
    print("Tavasz")
elif ho >= 4 and ho <= 6:
    print("Nyár")
elif ho >= 6 and ho <= 9:
    print("Ősz")
elif ho >= 9 and ho >= 12:
    print("Tél")