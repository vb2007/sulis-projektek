szoveg = input("Adj meg egy több szóvól álló szöveget: ");

print("Szöveg visszafelé: ", szoveg[::-1]);

print("Szöveg szóközög nélkül: ", szoveg.replace(" ", ""));

eredmeny = " ".join(szoveg.split());
print("Sok szóköz lecserélve egyre: ", eredmeny);