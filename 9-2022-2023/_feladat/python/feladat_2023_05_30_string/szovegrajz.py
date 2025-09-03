szo = str(input("Adj meg egy szót: "))
szokoz = 0;
szam = 0;

for j in range(1, len(szo) + 1):
    sor = szo[:j];
    print(sor);

print("----------");

for i in range (len(szo)):
    print(i * " " + szo[i]);