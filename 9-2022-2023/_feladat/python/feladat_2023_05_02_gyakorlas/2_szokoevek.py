ev_1 = int(input("Adj meg egy évszámot: "));
ev_2 = int(input("Adj meg még egy évszámot: "));

kezdo_index = ev_1;

if kezdo_index  % 4 == 0 and (kezdo_index % 100 != 0 or kezdo_index % 400 == 0):
    while kezdo_index < ev_2:
        print(kezdo_index);
        kezdo_index += 1;
else:
    print("Nincs szökőév a megadott tartományban.");