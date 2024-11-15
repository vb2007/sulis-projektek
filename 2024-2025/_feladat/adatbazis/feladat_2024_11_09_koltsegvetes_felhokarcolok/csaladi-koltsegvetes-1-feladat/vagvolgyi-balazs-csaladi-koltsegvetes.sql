-- 3. feladat
SELECT *
FROM `KIADASOK`;

-- 4. feladat
SELECT DISTINCT `kategoria`
FROM `kiadasok`;

-- 5. feladat
SELECT SUM(`egysegar`) AS `osszkoltseg`
FROM `kiadasok`;

-- 6. feladat
SELECT COUNT(`mennyiseg`) AS `vett_mennyiseg`
FROM `kiadasok`;

-- 7. feladat
SELECT SUM(`mennyiseg`) AS `termekek_szama`
FROM `kiadasok`;

-- 8. feladat
-- SELECT DISTINCT COUNT(`megnevezes`) AS `kulonbozo_darab`
-- FROM `kiadasok`;

-- 9. feladat

-- 10. feladat
SELECT `egysegar` AS `legolcsobb`
FROM `kiadasok`
ORDER BY `egysegar` ASC
LIMIT 1;

-- 11. feladat
SELECT `egysegar` AS `legdragabb`
FROM `kiadasok`
ORDER BY `egysegar` DESC
LIMIT 1;

-- 12. feladat
SELECT `megnevezes`
FROM `kiadasok`
WHERE `nev` = "Bence";

-- 13. feladat

-- 14. feladat

-- 15. feladat

-- 16. feladat

-- 17. feladat

-- 18. feladat
