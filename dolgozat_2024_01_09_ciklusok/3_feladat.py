from random import randint

i = 1
while i <= 5:
    a = randint(1, 10)
    k = 4*a
    t = a**2
    print(f"{i}. négyzet oldala={a}, kerülete={k}, területe={t}")
    i += 1