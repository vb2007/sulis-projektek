import math

avg = float(input("Add meg a félévi prog átlagod: "))

up_round_avg = math.ceil(avg)
down_round_avg = math.floor(avg)
round_avg = round(avg)

print(f"Év végi jegy, ha a tanár jóindulatú: {up_round_avg}")
print(f"Év végi jegy, ha a tanár nagyon szigorú: {down_round_avg}")
print(f"Év végi jegy, ha a tanár matematikailag helyesen kerekít: {round_avg}")