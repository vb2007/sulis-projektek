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
SELECT COUNT(DISTINCT `megnevezes`) AS `kulonbozo_darab`
FROM `kiadasok`;

-- 9. feladat
SELECT AVG(`egysegar`) AS `atlagos_egysegar`
FROM `kiadasok`;

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
SELECT COUNT(*) AS `bence_db`
FROM `kiadasok`
WHERE `nev` = "Bence";

-- 14. feladat
SELECT `megnevezes`, `egysegar` AS `fizetett`
FROM `kiadasok`
WHERE `nev` = "Emese"
ORDER BY `fizetett` ASC;

-- 15. feladat
SELECT SUM(`egysegar`) AS `koltott`
FROM `kiadasok`
WHERE `nev` = "Emese";

-- 16. feladat
SELECT `megnevezes`, `kategoria`, `egysegar` AS `koltes`
FROM `kiadasok`
ORDER BY `koltes` DESC;

-- 17. feladat
SELECT `nev`, `megnevezes`
FROM `kiadasok`
ORDER BY `egysegar` DESC
LIMIT 5;

-- 18. feladat
SELECT `nev`, `megnevezes`, `egysegar`
FROM `kiadasok`
ORDER BY `egysegar` DESC
LIMIT 1;
