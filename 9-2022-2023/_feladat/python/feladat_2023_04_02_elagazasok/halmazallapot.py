ho = int(input("Hány fokos a vized: "))

if ho <= 0:
    print("A víz szilárd")
elif ho >= 0 and ho <= 100:
    print("A víz folyékony")
else:
    print("A víz légnemű")