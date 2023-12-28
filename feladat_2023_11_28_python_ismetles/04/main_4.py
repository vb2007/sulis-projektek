#4. Feladat
homerseklet = int(input("Add meg a víz hőmérsékletét: "))

if(homerseklet >= 100):
    print("A víz halmazállapota légnemű.")
elif(homerseklet <= 100 and homerseklet >= 0):
    print("A víz halmazállapota folyékony.")
else:
    print("A víz halmazállapota szilárd.")