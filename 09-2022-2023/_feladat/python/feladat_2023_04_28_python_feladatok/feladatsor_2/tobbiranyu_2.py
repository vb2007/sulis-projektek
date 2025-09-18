valos_szam_1 = int(input("Adj meg egy valós számot: "));
valos_szam_2 = int(input("Adj meg még egy valós számot: "));

if valos_szam_1 >= valos_szam_2:
    print(f"{valos_szam_1} >= {valos_szam_2}");
elif valos_szam_1 <= valos_szam_2:
    print(f"{valos_szam_1} <= {valos_szam_2}");
elif valos_szam_1 > valos_szam_2:
    print(f"{valos_szam_1} > {valos_szam_2}");
elif valos_szam_1 < valos_szam_2:
    print(f"{valos_szam_1} < {valos_szam_2}");
elif valos_szam_1 == valos_szam_2:
    print(f"{valos_szam_1} = {valos_szam_2}");