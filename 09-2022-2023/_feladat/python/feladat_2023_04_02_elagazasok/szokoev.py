ev = int(input("Adj meg egy évszámot: "))

#ev % 4 == 0   --> Ha az év osztható 4-gyel...
#ev % 100 != 0   --> Ha az év nem osztható 100-zal...
#(or) ev % 400 == 0   --> Ha az év osztható 400-zal...
#(osztások maradék nélkül   --> == 0)
if ev % 4 == 0 and (ev % 100 != 0 or ev % 400 == 0):
    print("Ez az év szökőév.")
else:
    print("Ez az év nem szökőév.")