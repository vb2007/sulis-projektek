meccsek = [[1,1],[4,1],[6,3],[5,4],[1,5],[1,0],[4,1],[3,2],[2,2]]

szeria = 0
kezdet = None
for i, m in enumerate(meccsek):
    if m[0] > m[1]:
        szeria += 1
        if szeria == 3:
            kezdet = i
            break
    else:
        szeria = 0

print(f"Az első nyerő széria a {kezdet}. héten kezdődött.")