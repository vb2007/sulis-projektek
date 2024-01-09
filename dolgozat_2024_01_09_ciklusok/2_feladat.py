# s = megtett út
# v = sebesség
# t = idő

s_km = int(input("Hány km-re lakik? "))
v_mps = int(input("Milyen sebességgel (méter/másodperc) megy az autója? "))

s_m = s_km * 1000
t_mp = s_m / v_mps
t_perc = t_mp / 60

print(f"Autóval {round(t_perc, 2)} perc alatt ér haza.")