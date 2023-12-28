fok = int(input("Add meg a víz hőmérsékletét: "))

if(fok >= 100):
    print("A víz halmazállapota légnemű.")
elif(fok >= 0 and fok < 100):
    print("A víz halmazállapota folyékony.")
else:
    print("A víz halmazállapota szilárd.")