import time;

film_1 = str(input("1. film címe: "));
hossz_1 = int(input("Add meg a hosszát percben: "));
film_2 = str(input("2. film címe: "));
hossz_2 = int(input("Add meg a hosszát percben: "));
film_3 = str(input("3. film címe: "));
hossz_3 = int(input("Add meg a hosszát percben: "));

hossz_1 = time.strftime("A film %H óra %M perces.", time.gmtime(hossz_1));
print(hossz_1);