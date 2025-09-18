import random;
import math;

also_hatar = int(input("Add meg egy intervallum alsó határát: "));
felso_hatar = int(input("Add meg egy intervallum felső határát: "));

veletlen_1 = random.randint(also_hatar, felso_hatar);
veletlen_2 = random.randint(also_hatar, felso_hatar);

if veletlen_1 == veletlen_2:
    negyzet_kerulete = 4 * veletlen_1;
    negyzet_terulete = veletlen_1 * veletlen_2;
    print(f"A négyzet... \n Kerülete: {negyzet_kerulete} \n Területe: {negyzet_terulete}")
else:
    teglalap_kerulete = 2 * (veletlen_1 + veletlen_2);
    teglalap_terulete = veletlen_1 * veletlen_2;
    print(f"A téglalap... \n Kerülete: {teglalap_kerulete} \n Területe: {teglalap_terulete}")