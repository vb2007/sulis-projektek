from operator import le


szo = input("Adj meg egy szót: ");


#index szerinti
for betu in szo:
    print(betu);

print("---------")

#ertek szerinti
for i in range (len(szo)):
    print(szo[i]);