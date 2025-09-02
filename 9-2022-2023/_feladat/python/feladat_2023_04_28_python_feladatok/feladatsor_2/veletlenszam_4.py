import random;
import math;

kor_sugar = random.randint(1,5);
kerulet = math.pow(kor_sugar, 2) * math.pi;
terulet = 2 * kor_sugar * math.pi;

print("Kerülete: {:.2f} ".format(kerulet), "Területe: {:.2f}".format(terulet));