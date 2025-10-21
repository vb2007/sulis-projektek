<?php

require("fuggvenyek.php");

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
