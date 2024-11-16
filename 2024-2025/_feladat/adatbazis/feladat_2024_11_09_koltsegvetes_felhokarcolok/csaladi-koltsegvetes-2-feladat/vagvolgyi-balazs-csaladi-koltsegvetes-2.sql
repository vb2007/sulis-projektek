-- 3. feladat
SELECT `kategoria`, SUM(`mennyiseg`) AS `db`
FROM `kiadasok`
GROUP BY `kategoria`
ORDER BY `db` ASC;

-- 4. feladat
SELECT `nev`, SUM(`egysegar`) AS `koltes`
FROM `kiadasok`
GROUP BY `nev`
ORDER BY `koltes` DESC;

-- 5. feladat
SELECT `nev`, SUM(`mennyiseg`) AS `db`
FROM `kiadasok`
GROUP BY `nev`
ORDER BY `nev` DESC;

-- 6. feladat
SELECT `nev`, `kategoria`, SUM(`mennyiseg`) AS `db`
FROM `kiadasok`
GROUP BY `nev`, `kategoria`
ORDER BY `nev` DESC;

-- 7. feladat
SELECT `kategoria`, MIN(`egysegar`) AS `minimum_ar`
FROM `kiadasok`
GROUP BY `kategoria`
ORDER BY `minimum_ar` ASC;

-- 8. feladat
SELECT `kategoria`, ROUND(AVG(`egysegar`), 1) AS `koltes`
FROM `kiadasok`
GROUP BY `kategoria`
ORDER BY `kategoria` ASC;

-- 9. feladat
SELECT `kategoria`, `egysegar` AS `koltes`
FROM `kiadasok`
ORDER BY `koltes` DESC
LIMIT 1;

-- 10. feladat
SELECT `nev`,
    MIN(`egysegar`) AS `legolcsobb_koltes`,
    MAX(`egysegar`) AS `legdragabb_koltes`
FROM `kiadasok`
GROUP BY `nev`
ORDER BY `nev` DESC;

-- 11. feladat
SELECT `nap`, `kategoria`, SUM(`mennyiseg`) AS `mennyiseg`
FROM `kiadasok`
GROUP BY `nap`, `kategoria`
ORDER BY `mennyiseg` DESC;

-- 12. feladat
SELECT `nev`, `kategoria`, SUM(`egysegar`) AS `koltes`
FROM `kiadasok`
GROUP BY `nev`, `kategoria`;

-- 13. feladat
SELECT `kategoria`, SUM(`egysegar` * `mennyiseg`) AS `koltes`
FROM `kiadasok`
WHERE `nev` = "Bence"
GROUP BY `kategoria`
ORDER BY `koltes` ASC;

-- 14. feladat
SELECT `nev`, CONCAT(SUM(`egysegar` * `mennyiseg`), " Ft") AS `koltes`
FROM `kiadasok`
WHERE `kategoria` = "élelmiszer"
GROUP BY `nev`;

-- 15. feladat
SELECT `nev`
FROM `kiadasok`
WHERE `kategoria` = "közlekedés"
ORDER BY SUM(`egysegar` * `mennyiseg`) DESC
LIMIT 1;