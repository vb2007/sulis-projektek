-- 3. feladat
SELECT *
FROM `foci`
ORDER BY `ertek` DESC;

-- 4. feladat
SELECT *
FROM `foci`
WHERE `klub` = "RB Leipzig";

-- 5. feladat
SELECT `nev`, `merkozes_szam`
FROM `foci`
WHERE `lab` = "mindkét";

-- 6. feladat
SELECT `nev`
FROM `foci`
WHERE `klub` LIKE "%1893";

-- 7. feladat
SELECT COUNT(DISTINCT `klub`) AS `db`
FROM `foci`;

-- 8. feladat
SELECT COUNT(*) AS `Középpályás`
FROM `foci`
WHERE `poszt` LIKE '%középpályás%';

-- 9. feladat
SELECT COUNT(*) AS `1997 - 2005`
FROM `foci`
WHERE YEAR(`szuletes`) BETWEEN 1997 AND 2005;

-- 10. feladat
SELECT ROUND(AVG(`gol`)) AS `ADAM`
FROM `foci`
WHERE `nev` LIKE 'Ádám%';

-- 11. feladat
SELECT `nev`, CONCAT(`ertek`, ' m €') AS `Érték`
FROM `foci`
ORDER BY `ertek` DESC
LIMIT 3;

-- 12. feladat
SELECT `nev`, `poszt`,
	IF(`bemzutatkozas` IS NULL, 'Még nem szerepelt', `bemzutatkozas`) AS `debütálás`
FROM `foci`
WHERE (MONTH(`szuletes`) = 5 OR MONTH(`szuletes`) = 11)
	AND YEAR(`szuletes`) BETWEEN 1990 AND 1999
	AND `lab` != 'mindkét'
ORDER BY `poszt` ASC;

-- 13. feladat
SELECT `nev`
FROM `foci`
WHERE `lab` = "mindkét"
ORDER BY `ertek` DESC
LIMIT 1;

-- 14. feladat
SELECT 
	MIN(`szuletes`) AS `legidősebb`,
	MAX(`szuletes`) AS `legfiatalabb`
FROM `foci`;

-- 15. feladat
SELECT CONCAT(SUM(`ertek`) * 1000000, " €") AS `Összérték`
FROM `foci`;

-- 16. feladat
SELECT `poszt`, CONCAT(COUNT(*), " fő") AS `fő`
FROM `foci`
GROUP BY `poszt`
ORDER BY `fő` DESC;

-- 17. feladat
SELECT `lab`, ROUND(AVG(`gol`), 2) AS `gólátlag`
FROM `foci`
WHERE `merkozes_szam` > 0
GROUP BY `lab`
ORDER BY `gólátlag` DESC;

-- 18. feladat
SELECT `klub`, SUM(`merkozes_szam`) AS `mérkőzés`
FROM `foci`
WHERE `klub` IN ("MOL Fehérvár FC", "Budapest Honvéd FC", "Puskás Akadémia FC", "Ferencvárosi TC", "Paksi FC", "Debreceni VSC")
	AND `merkozes_szam` > 0
GROUP BY `klub`
ORDER BY `mérkőzés` DESC
LIMIT 1;

-- 19. feladat
SELECT `nev`, `klub`, CONCAT(ROUND((`gol` / `merkozes_szam`) * 100, 2), " %") AS `gólerőség`
FROM `foci`
ORDER BY `gólerőség` DESC
LIMIT 3;

-- 20. feladat
SELECT *
FROM `foci`
ORDER BY `magassag` ASC
LIMIT 1;