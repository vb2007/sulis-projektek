<?php

require("fuggvenyek.php");

//Egyszerű függvények

//1. feladat
echo hetNapja(1) . "\n";
echo hetNapja(5) . "\n";
echo hetNapja(11) . "\n";

//2. feladat
echo napSorszama("hétfő") . "\n";
echo napSorszama("péntek") . "\n";
echo napSorszama("asd") . "\n";

//3. feladat
var_dump(parosE(5)) . "\n";
var_dump(parosE(8)) . "\n";

//4. feladat
var_dump(paratlanE(5)) . "\n";
var_dump(paratlanE(8)) . "\n";

//5. feladat
var_dump(oszthatoE(5, 5)) . "\n";
var_dump(oszthatoE(5, 8)) . "\n";

//6. feladat
var_dump(negativE(-3)) . "\n";
var_dump(negativE(96)) . "\n";

//7. feladat
echo szignum(-863) . "\n";
echo szignum(0) . "\n";
echo szignum(1024) . "\n";

//8. feladat
echo datumIdo("óra") . "\n";
echo datumIdo("perc") . "\n";
echo datumIdo("másodperc") . "\n";
echo datumIdo("év") . "\n";
echo datumIdo("hónap") . "\n";
echo datumIdo("nap") . "\n";

//Függvények tömbökön

//1. feladat
echo utolso([5, 11, 76, 3]) . "\n";

//2. feladat
echo osszeg([5, 11, 76, 3]) . "\n";

//3. feladat
echo szorzat([5, 11, 76, 3]) . "\n";

//4. feladat
echo parosDb([]) . "\n";
echo parosDb([5,11,76,3]) . "\n";
echo parosDb([37,74,3,71,54]) . "\n";
